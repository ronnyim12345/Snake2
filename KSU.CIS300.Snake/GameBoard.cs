/* GameBoard.cs
 * Author: Ronny Im
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KSU.CIS300.Snake
{
    public class GameBoard
    {



        /// PROPERTIES ///

        /// <summary>
        /// Return the node with the food.
        /// </summary>
        public GameNode Food { get; set; }



        /// <summary>
        /// Stores all nodes.
        /// </summary>
        public GameNode[,] Grid { get; private set; }


        /// <summary>
        /// Head of snake.
        /// </summary>
        public GameNode Head { get; set; }


        /// <summary>
        /// Tail of snake.
        /// </summary>
        public GameNode Tail { get; set; }


        /// <summary>
        /// Size of snake.
        /// </summary>
        public int SnakeSize { get; private set; }








        /// FIELDS ///


        /// <summary>
        /// Dimensions(n) of the board.
        /// </summary>
        private int _size;



        /// <summary>
        /// All 4 possible directions to make it easier to find adj. nodes to search.
        /// </summary>
        private Direction[] _aiDirection = new Direction[4]
        {
            Direction.Up, 
            Direction.Left,
            Direction.Right, 
            Direction.Down
        };



        /// <summary>
        /// Array containing left & right directions.
        /// </summary>
        private Direction[] _leftRight = new Direction[2]
        {
            Direction.Left,
            Direction.Right,
        };
    


        /// <summary>
        /// Array containing up & down directions.
        /// </summary>
        private Direction[] _upDown = new Direction[2]
        {
            Direction.Up,
            Direction.Down,
        };
    


        /// <summary>
        /// Utilized in AddFood method to place food in random location.
        /// </summary>
        private static Random _random = new Random();
















        /// METHODS ///


        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="size"> Size of board. </param>
        public GameBoard(int size)
        {


            /// SET SIZE ///

            _size = size;




            /// MAKE BOARD ///

            Grid = new GameNode[_size, _size];


            for(int i=0; i < _size; i++)
            {
                for(int j=0; j < _size; j++)
                {
                    Grid[i, j] = new GameNode(i, j);

                }

            }



            /// PUT HEAD & TAIL AT CENTER ///

            int center = _size / 2;

            if(center != 0)
            {
                Head = Grid[center, center];
                Tail = Grid[center, center];

                Grid[center, center].Data = GridData.SnakeHead;

            }

            SnakeSize = 2;




            /// ADD FOOD ///

            AddFood();


        }



        /// <summary>
        /// Randomly places food.
        /// </summary>
        public void AddFood()
        {

            int x;

            int y;

            
            do
            {
                x = _random.Next(0, _size);

                y = _random.Next(0, _size);

            } while (Grid[x, y].Data != GridData.Empty);


            Grid[x, y].Data = GridData.SnakeFood;

            Food = Grid[x, y];




        }



        /// <summary>
        /// Return the next node if heading in that direction.
        /// </summary>
        /// <param name="dir"> The direction. </param>
        /// <param name="current"> The node. </param>
        /// <returns> The next node. </returns>
        public GameNode GetNextNode(Direction dir, GameNode current)
        {
            int x = current.X;
            int y = current.Y;

            try
            {
                if (dir == Direction.Up)
                {
                    y--;

                    return Grid[x, y];

                }


                if (dir == Direction.Down)
                {
                    y++;

                    return Grid[x, y];

                }


                if (dir == Direction.Left)
                {
                    x--;

                    return Grid[x, y];

                }



                if (dir == Direction.Right)
                {
                    x++;

                    return Grid[x, y];

                }


                return current;


            }
            catch
            {
                return null;

            }





        }



        /// <summary>
        /// Main logic on how it moves through board.
        /// </summary>
        /// <param name="dir"> The direction. </param>
        /// <returns> The status. </returns>
        public SnakeStatus MoveSnake(Direction dir)
        {
            
            GameNode nextNode = GetNextNode(dir, Head);



            /// COLLISION HAPPENED ///

            if (nextNode == null)
            {
                return SnakeStatus.Collision;

            }



            /// INVALID DIRECTION ///

            if(nextNode.SnakeEdge == Head)
            {
                return SnakeStatus.InvalidDirection;
            }



            /// HIT BODY ///

            if (nextNode.Data == GridData.SnakeBody)
            {
                return SnakeStatus.Collision;
            }




            /// MOVE SNAKE ///

            nextNode.Data = GridData.SnakeHead;

            Head.Data = GridData.SnakeBody;

            Head.SnakeEdge = nextNode;



            /// EATING FOOD ///
            
            if(nextNode == Food)
            {
                SnakeSize++;

                if(_size * _size == SnakeSize)
                {
                    return SnakeStatus.Win;
                }



                AddFood();

                Head = nextNode;

                return SnakeStatus.Eating;
            }





            /// CUT TAIL ///
            
            if(Head != Tail)
            {
                Tail.Data = GridData.Empty;


                GameNode tempEdge = Tail.SnakeEdge;

                Tail.SnakeEdge = null;

                Tail = tempEdge;

            }



            /// SET THE NEW HEAD ///

            Head = nextNode;

            return SnakeStatus.Moving;
        }



        /// <summary>
        /// List of game nodes of the snake (starts from tail).
        /// </summary>
        /// <returns> The list. </returns>
        public List<GameNode> GetSnakePath()
        {
            List<GameNode> allSnakeNodes = new List<GameNode>();


            GameNode pointerNode = Tail;



            while(pointerNode != null)
            {
                allSnakeNodes.Add(pointerNode);

                pointerNode = pointerNode.SnakeEdge;

            }



            return allSnakeNodes;




        }






        /// <summary>
        /// My Hamiltonian AI.
        /// </summary>
        /// <returns> Directions queue. </returns>
        public Queue<Direction> myHamiltonianAI()
        {

            /// CREATE MY ARRAY ///

            GameNode[,] myArray = new GameNode[_size, _size];

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    myArray[i, j] = new GameNode(i, j);

                }

            }



            /// MAKE INITIAL PATH ///


            // KEY CHART TABLE //

            // Empty = left
            // SnakeBody = up
            // SnakeFood = right
            // SnakeHead = down





            int centerX = Head.X;
            int centerY = Head.Y;


            /// LEFT ///

            myArray[centerX, centerY].SnakeEdge = myArray[centerX - 1 , centerY];
            myArray[centerX, centerY].Data = GridData.Empty;






            /// DOWN ///

            myArray[centerX - 1, centerY].SnakeEdge = myArray[centerX - 1, centerY + 1];
            myArray[centerX - 1, centerY].Data = GridData.SnakeHead;





            /// RIGHT ///

            myArray[centerX - 1, centerY + 1].SnakeEdge = myArray[centerX, centerY + 1];
            myArray[centerX - 1, centerY + 1].Data = GridData.SnakeFood;





            /// UP ///

            myArray[centerX, centerY + 1].SnakeEdge = myArray[centerX, centerY];
            myArray[centerX, centerY + 1].Data = GridData.SnakeBody;







            /// HAMILTONIAN //


            GameNode pointerNode = myArray[centerX, centerY];


            while (true)
            {

                int i = 0;


                /// LEFT ///

                if (pointerNode.Data == GridData.Empty && pointerNode.Y != 0)
                {

                    GameNode aboveNode = myArray[pointerNode.X, pointerNode.Y - 1];
                    GameNode diagNode = myArray[pointerNode.X - 1, pointerNode.Y - 1];

                    if(aboveNode.SnakeEdge == null && diagNode.SnakeEdge == null)
                    {
                        /// CHANGE POINTER NODE ///

                        pointerNode.SnakeEdge = aboveNode;
                        pointerNode.Data = GridData.SnakeBody;


                        /// CHANGE ABOVE NODE ///

                        aboveNode.SnakeEdge = diagNode;
                        aboveNode.Data = GridData.Empty;


                        /// CHANGE DIAG NODE ///

                        diagNode.SnakeEdge = myArray[pointerNode.X - 1, pointerNode.Y];
                        diagNode.Data = GridData.SnakeHead;

                        i++;

                    }


                }





                /// UP ///

                if (pointerNode.Data == GridData.SnakeBody && pointerNode.X != _size-1)
                {

                    GameNode rightNode = myArray[pointerNode.X + 1, pointerNode.Y];
                    GameNode diagNode = myArray[pointerNode.X + 1, pointerNode.Y - 1];

                    if (rightNode.SnakeEdge == null && diagNode.SnakeEdge == null)
                    {
                        /// CHANGE POINTER NODE ///

                        pointerNode.SnakeEdge = rightNode;
                        pointerNode.Data = GridData.SnakeFood;


                        /// CHANGE RIGHT NODE ///

                        rightNode.SnakeEdge = diagNode;
                        rightNode.Data = GridData.SnakeBody;


                        /// CHANGE DIAG NODE ///

                        diagNode.SnakeEdge = myArray[pointerNode.X, pointerNode.Y - 1];
                        diagNode.Data = GridData.Empty;

                        i++;

                    }


                }





                /// RIGHT ///

                if (pointerNode.Data == GridData.SnakeFood && pointerNode.Y != _size-1)
                {
                    GameNode lowerNode = myArray[pointerNode.X, pointerNode.Y + 1];
                    GameNode diagNode = myArray[pointerNode.X + 1, pointerNode.Y + 1];

                    if (lowerNode.SnakeEdge == null && diagNode.SnakeEdge == null)
                    {
                        /// CHANGE POINTER NODE ///

                        pointerNode.SnakeEdge = lowerNode;
                        pointerNode.Data = GridData.SnakeHead;


                        /// CHANGE LOWER NODE ///

                        lowerNode.SnakeEdge = diagNode;
                        lowerNode.Data = GridData.SnakeFood;


                        /// CHANGE DIAG NODE ///

                        diagNode.SnakeEdge = myArray[pointerNode.X + 1, pointerNode.Y];
                        diagNode.Data = GridData.SnakeBody;

                        i++;

                    }
                }






                /// DOWN ///

                if (pointerNode.Data == GridData.SnakeHead && pointerNode.X != 0)
                {
                    GameNode leftNode = myArray[pointerNode.X - 1, pointerNode.Y];
                    GameNode diagNode = myArray[pointerNode.X - 1, pointerNode.Y + 1];

                    if (leftNode.SnakeEdge == null && diagNode.SnakeEdge == null)
                    {
                        /// CHANGE POINTER NODE ///

                        pointerNode.SnakeEdge = leftNode;
                        pointerNode.Data = GridData.Empty;


                        /// CHANGE LEFT NODE ///

                        leftNode.SnakeEdge = diagNode;
                        leftNode.Data = GridData.SnakeHead;


                        /// CHANGE DIAG NODE ///

                        diagNode.SnakeEdge = myArray[pointerNode.X, pointerNode.Y + 1];
                        diagNode.Data = GridData.SnakeFood;

                        i++;

                    }
                }





                if(i == 0)
                {
                    pointerNode = pointerNode.SnakeEdge;


                    if (pointerNode == myArray[centerX, centerY])
                    {
                        break;
                    }

                }




            }






            /// MAKE THE QUEUE ///



            Queue<Direction> theQueue = new Queue<Direction>();


            do
            {

                /// LEFT ///

                if(pointerNode.Data == GridData.Empty)
                {
                    theQueue.Enqueue(Direction.Left);

                }


                /// UP ///

                if (pointerNode.Data == GridData.SnakeBody)
                {
                    theQueue.Enqueue(Direction.Up);

                }



                /// RIGHT ///

                if (pointerNode.Data == GridData.SnakeFood)
                {
                    theQueue.Enqueue(Direction.Right);

                }


                /// DOWN ///

                if (pointerNode.Data == GridData.SnakeHead)
                {
                    theQueue.Enqueue(Direction.Down);

                }



                pointerNode = pointerNode.SnakeEdge;




            } while (pointerNode != myArray[centerX, centerY]);


            return theQueue;



        }














        /// PERFECT AI ///


        /// <summary>
        /// Reverses the given path from the dest to the head.
        /// </summary>
        /// <param name="path"> The path. </param>
        /// <param name="dest"> The destination. </param>
        /// <returns> List of dir. that leads from head to dest. </returns>
        private List<Direction> BuildPath(Dictionary<GameNode, (GameNode, Direction)> path, GameNode dest)
        {




            throw new NotImplementedException();
        }



        /// <summary>
        /// Finds shortest path from head to dest.
        /// </summary>
        /// <param name="dest"> The destination. </param>
        /// <returns> List of dir. that leads from head to dest. </returns>
        public List<Direction> FindShortestAiPath(GameNode dest)
        {



            throw new NotImplementedException();
        }


        /// <summary>
        /// Finds Hamiltonian path
        /// </summary>
        /// <returns> Queue of dir. that leads from head to dest. </returns>
        public Queue<Direction> FindLongestAiPath()
        {

            throw new NotImplementedException();
        }





    }
}
