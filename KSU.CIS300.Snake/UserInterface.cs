/* UserInterface.cs
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
    public partial class UserInterface : Form
    {

        // FIELDS ///


        /// <summary>
        /// Calculated size of square (a node on the graph).
        /// </summary>
        private int _squareWidth;


        /// <summary>
        /// Width & height of game in # of nodes.
        /// </summary>
        private int _size;


        /// <summary>
        /// Game object.
        /// </summary>
        private Game _game;



        /// <summary>
        /// Snake color.
        /// </summary>
        private SolidBrush _bodyBrush = new SolidBrush(Color.Purple);



        /// <summary>
        /// Food color.
        /// </summary>
        private SolidBrush _foodBrush = new SolidBrush(Color.Red);


        /// <summary>
        /// Snake squares outline.
        /// </summary>
        private Pen _pen = new Pen(Color.Black, 2);


        /// <summary>
        /// Cancels or stops StartMoving method in Game class.
        /// </summary>
        private CancellationTokenSource _cancelSource = new CancellationTokenSource();
















        /// METHODS ///


        /// <summary>
        /// The constructor.
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();

        }



        /// <summary>
        /// Creates new game.
        /// </summary>
        /// <param name="size"> The size. </param>
        /// <param name="speed"> The speed. </param>
        private void NewGame(int size, int speed)
        {


            /// STOPS OLD GAME ///

            _cancelSource.Cancel();




            /// INITIALIZE GAME ///

            _size = size;

            _game = new Game(_size, speed, uxIsAI.Checked);




            /// SET UP GUI ///

            uxPictureBox.Width = 600;
            uxPictureBox.Height = 600;


            Size theSize = new Size();

            theSize.Width = 616;
            theSize.Height = 663;

            Size = theSize;

            _squareWidth = 600 / _size;


            uxScore.DataBindings.Clear();

            uxScore.DataBindings.Add("Text", _game, "Score");







            /// SET UP PROGRESS & CANCEL TOKEN ///

            Progress<SnakeStatus> progress = new Progress<SnakeStatus>();

            progress.ProgressChanged += new EventHandler<SnakeStatus>(CheckProgress);

            _cancelSource = new CancellationTokenSource();





            /// START MOVING ///

            _game.StartMoving(progress, _cancelSource.Token);
        }



        /// <summary>
        /// Helper method for NewGame.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="status"> The status. </param>
        private void CheckProgress(object sender, SnakeStatus status)
        {

            Refresh();
            if (status == SnakeStatus.Collision)
            {
                MessageBox.Show("Game over!");
            }
            else if (status == SnakeStatus.Win)
            {
                MessageBox.Show("Game Completed!");
            }
        }













        /// EVENT HANDLERS ///


        /// <summary>
        /// Draw all graphics.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxPictureBox_Paint(object sender, PaintEventArgs e)
        {

            if(_game != null)
            {

                Graphics theGraphics = e.Graphics;


                List<GameNode> snakePathList = _game.GetSnakePath();



                int loops = snakePathList.Count;

                for (int i = 0; i < loops; i++)
                {

                    /// GET COORDINATES ///

                    int x = snakePathList[i].X;

                    int y = snakePathList[i].Y;




                    /// MAKE RECTANGLE ///

                    Rectangle newRec = new Rectangle();

                    Point newPoint = new Point();

                    newPoint.X = x * _squareWidth;
                    newPoint.Y = y * _squareWidth;

                    newRec.Location = newPoint;
                    newRec.Width = _squareWidth;
                    newRec.Height = _squareWidth;

                    theGraphics.FillRectangle(_bodyBrush, newRec);

                    theGraphics.DrawRectangle(_pen, newRec);

                }





                /// DRAW FOOD ///

                GameNode foodNode = _game.GetFood();

                if (foodNode != null)
                {
                    Rectangle foodRec = new Rectangle();

                    Point newPoint = new Point();

                    newPoint.X = foodNode.X * _squareWidth;
                    newPoint.Y = foodNode.Y * _squareWidth;

                    foodRec.Location = newPoint;
                    foodRec.Width = _squareWidth;
                    foodRec.Height = _squareWidth;

                    theGraphics.FillEllipse(_foodBrush, foodRec);


                }

            }






        }


        /// <summary>
        /// Key held down event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInterface_KeyDown(object sender, KeyEventArgs e)
        {
            Keys keyPressed = e.KeyCode;


            if (keyPressed == Keys.Up)
            {
                _game.MoveUp();
            }

            if (keyPressed == Keys.Down)
            {
                _game.MoveDown();
            }

            if (keyPressed == Keys.Left)
            {
                _game.MoveLeft();
            }

            if (keyPressed == Keys.Right)
            {
                _game.MoveRight();
            }



            uxPictureBox.Refresh();





        }





        /// <summary>
        /// Enables arrow keys.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInterface_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;

        }



        /// <summary>
        /// Easy game button event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxEasyGame_Click(object sender, EventArgs e)
        {

            if (uxIsAI.Checked)
            {
                NewGame(10, (int)uxAISpeedNumUD.Value);
            }
            else
            {
                NewGame(10, 250);
            }

        }



        /// <summary>
        /// Normal game button event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNormalGame_Click(object sender, EventArgs e)
        {
            if (uxIsAI.Checked)
            {
                NewGame(20, (int)uxAISpeedNumUD.Value);
            }
            else
            {
                NewGame(20, 150);
            }


        }




        /// <summary>
        /// Hard game button event handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxHardGame_Click(object sender, EventArgs e)
        {
            if (uxIsAI.Checked)
            {
                NewGame(30, (int)uxAISpeedNumUD.Value);
            }
            else
            {
                NewGame(30, 100);
            }



        }

        
    }
}
