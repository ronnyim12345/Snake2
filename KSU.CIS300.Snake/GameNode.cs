/* GameNode.cs
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
    /// <summary>
    /// GridData enum.
    /// </summary>
    public enum GridData
    {
        Empty,
        SnakeHead,
        SnakeBody,
        SnakeFood

    }


    /// <summary>
    /// The GameNode Class.
    /// </summary>
    public class GameNode
    {


        /// PROPERTIES ///

        /// <summary>
        /// Y-coordinate for this node.
        /// </summary>
        public int Y { get; set; }



        /// <summary>
        /// X-coordinate for this node.
        /// </summary>
        public int X { get; set; }




        /// <summary>
        /// Information of this node.
        /// </summary>
        public GridData Data { get; set; }




        /// <summary>
        /// Connection in the graph to another GameNode (tail to head)
        /// </summary>
        public GameNode SnakeEdge { get; set; }








        /// METHODS ///

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="x"> X-coordinate. </param>
        /// <param name="y"> Y-coordinate. </param>
        public GameNode(int x, int y)
        {
            X = x;
            Y = y;
        }


        /// <summary>
        /// Custom ToString method.
        /// </summary>
        /// <returns> x and y coord. </returns>
        public override string ToString()
        {
            return X.ToString() + ", " + Y.ToString();

        }



    }
}
