using System;
using System.Drawing;
using System.Net.Configuration;

namespace MageTwinstick
{
    class Vector2D
    {
        //Properties for X and Y coordinates.
        /// <summary>
        /// autoproperty for the X value
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// autoproperty for the Y value
        /// </summary>
        public float Y { get; set; }

        //Creates a vector from two floats representing x and y.
        public Vector2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        //Finds the difference between one position and another by creating a vector between them.
        public Vector2D Subtract(Vector2D vec)
        {
            // subtracts the two positions from each other
            Vector2D newVec = new Vector2D(vec.X - this.X, vec.Y - this.Y);

            // returns the new vector
            return newVec;
        }

        //Calculates the lenght of a vector.
        private float Length()
        {
            // returns the length of the vector
            return (float)Math.Sqrt((this.X * this.X) + (this.Y * this.Y));
        }

        //Normalizes the vector.
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