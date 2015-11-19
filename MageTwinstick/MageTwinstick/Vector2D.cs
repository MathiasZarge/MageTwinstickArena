using System;
using System.Drawing;

namespace MageTwinstick
{
    /// <summary>
    /// used for finding distances and directions of gamobjects
    /// </summary>
    class Vector2D
    {
        /// <summary>
        /// autoproperty for the X value
        /// </summary>
        public float X { get; set; }
        
        /// <summary>
        /// autoproperty for the Y value
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Creates a vector from two floats representing x and y.
        /// </summary>
        /// <param name="x">float for x</param>
        /// <param name="y">float for y</param>
        public Vector2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Finds the difference between one position and another by creating a vector between them.
        /// </summary>
        /// <param name="vec">vector between two positions</param>
        /// <returns></returns>
        public Vector2D Subtract(Vector2D vec)
        {
            // subtracts the two positions from each other
            Vector2D newVec = new Vector2D(vec.X - this.X, vec.Y - this.Y);

            // returns the new vector
            return newVec;
        }

        /// <summary>
        /// Calculates the lenght of a vector.
        /// </summary>
        /// <returns></returns>
        private float Length()
        {
            // returns the length of the vector
            return (float)Math.Sqrt((this.X * this.X) + (this.Y * this.Y));
        }

        /// <summary>
        /// Normalizes the vector.
        /// </summary>
        public void Normalize()
        {
            // sets the length via the Lentgth() method
            float length = Length();

            // makes the unit vector
            this.X = this.X / length;
            this.Y = this.Y / length;
        }
    }
}