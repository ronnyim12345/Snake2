/* Game.cs
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KSU.CIS300.Snake
{

    /// <summary>
    /// The direction enum.
    /// </summary>
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right,
        None

    }



    /// <summary>
    /// The status enum.
    /// </summary>
    public enum SnakeStatus
    {
        Moving,
        InvalidDirection,
        Eating,
        Collision,
        Win

    }




    /// <summary>
    /// The Game class.
    /// </summary>
    public class Game : INotifyPropertyChanged
    {



        /// FIELDS ///


        /// <summary>
        /// Player's points.
        /// </summary>
        private int _score;


        /// <summary>
        /// Milliseconds per tick.
        /// </summary>
        private int _delay;


        /// <summary>
        /// If game is controlled by AI.
        /// </summary>
        private bool _isAI;



        /// <summary>
        /// Stores AI path if enabled.
        /// </summary>
        private Queue<Direction> _aiPath;




        




        /// PROPERTIES ///


        /// <summary>
        /// Whether game is currently being played.
        /// </summary>
        public bool Play { get; set; }



        /// <summary>
        /// Stores the score.
        /// </summary>
        public int Score 
        {
            get
            {
                return _score;

            }
            set
            {

                if(value != _score)
                {

                    _score = value;

                    OnPropertyChanged("Score");

                }




            }
        }



        /// <summary>
        /// Ref to the game board object that contains the logic for movement.
        /// </summary>
        public GameBoard Board { get; private set; }


        /// <summary>
        /// Size of game.
        /// </summary>
        public int Size { get; private set; }



        /// <summary>
        /// Last direction moved.
        /// </summary>
        public Direction LastDirection { get; set; }



        /// <summary>
        /// Most recent dir. reported by UI.
        /// </summary>
        public Direction KeyPress { get; private set; }



        /// <summary>
        /// The status.
        /// </summary>
        public SnakeStatus Status { get; private set; }



        /// <summary>
        /// Needed as part of interface.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;









        // METHODS ///


        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="size"> The size. </param>
        /// <param name="speed"> The speed. </param>
        /// <param name="isAI"> Whether its AI. </param>
        public Game(int size, int speed, bool isAI)
        {

            /// INITIALIZE BOARD ///

            Size = size;

            Board = new GameBoard(Size);

            Score = 2;

            Play = true;



            /// MOVE SNAKE UP ONE ///

            Board.MoveSnake(Direction.Up);





            /// SET DELAY ///

            _delay = speed;




            /// IS AI ENABLED ? ///

            _isAI = isAI;

            if (_isAI)
            {
                _aiPath = Board.myHamiltonianAI();

            }





        }



        /// <summary>
        /// Game clock.
        /// </summary>
        /// <param name="progress"> The progress. </param>
        /// <param name="cancelToken"> Cancel request. </param>
        /// <returns> A task. </returns>
        public async Task StartMoving(IProgress<SnakeStatus> progress, CancellationToken cancelToken)
        {

            while (Play && !cancelToken.IsCancellationRequested)
            {

                /// AI: DEQUEUES KEYPRESS ///

                if (_isAI)
                {
                    KeyPress = _aiPath.Dequeue();

                }





                SnakeStatus newStat = Board.MoveSnake(KeyPress);

                progress.Report(newStat);



                /// SNAKE COLLIDED ///

                if(newStat == SnakeStatus.Collision)
                {
                    Play = false;

                }


                /// SNAKE'S STILL MOVING ///

                if(newStat == SnakeStatus.Moving)
                {
                    LastDirection = KeyPress;

                }



                /// SNAKE'S EATING ///
                
                if(newStat == SnakeStatus.Eating)
                {
                    Score++;

                }



                /// SNAKE MOVED INVALID-LY ///
                
                if(newStat == SnakeStatus.InvalidDirection)
                {
                    SnakeStatus newStat2 = Board.MoveSnake(LastDirection);

                    progress.Report(newStat2);


                    if (newStat2 == SnakeStatus.Collision)
                    {
                        Play = false;

                    }

                    if (newStat2 == SnakeStatus.Eating)
                    {
                        Score++;

                    }


                }




                /// YOU WON ///
                
                if(newStat == SnakeStatus.Win)
                {
                    Score++;

                    Play = false;


                }




                /// AI: ADDS KEYPRESS BACK TO QUEUE ///

                if (_isAI)
                {
                    _aiPath.Enqueue(KeyPress);

                }





                /// SET TICK ///
                
                await Task.Delay(_delay);


            }

            

        }



        /// <summary>
        /// Calls property changed event.
        /// </summary>
        /// <param name="propertyName"> The property name. </param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }


        /// <summary>
        /// Gets list of nodes of the snake (starts from tail).
        /// </summary>
        /// <returns> The list. </returns>
        public List<GameNode> GetSnakePath()
        {
            return Board.GetSnakePath();

        }



        /// <summary>
        /// Gets the food node.
        /// </summary>
        /// <returns> Food node. </returns>
        public GameNode GetFood()
        {
            GameNode foodNode = Board.Food;


            if(foodNode.Data != GridData.SnakeFood)
            {
                return null;
                
            }




            return Board.Food;
        }








        /// KEY PRESSES ///


        /// <summary>
        /// Sets key press up.
        /// </summary>
        public void MoveUp()
        {
            KeyPress = Direction.Up;
        }


        /// <summary>
        /// Sets key press down.
        /// </summary>
        public void MoveDown()
        {
            KeyPress = Direction.Down;
        }


        /// <summary>
        /// Sets key press left.
        /// </summary>
        public void MoveLeft()
        {
            KeyPress = Direction.Left;
        }



        /// <summary>
        /// Sets key press right.
        /// </summary>
        public void MoveRight()
        {
            KeyPress = Direction.Right;
        }









    }
}
