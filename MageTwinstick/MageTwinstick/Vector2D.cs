using System;
using System.Drawing;

namespace MageTwinstick
{
    class Vector2D
    {
        //
        public float X { get; set; }
        public float Y { get; set; }

        //
        public Vector2D (float x, float y)
        {
            X = x;
            Y = y;
        }
    
        //
        public Vector2D Subtract(Vector2D vec)
        {
            Vector2D newVec = new Vector2D(vec.X - this.X, vec.Y - this.Y);

            return newVec;
        }

        //
        private float Length()
        {
            return (float)Math.Sqrt((this.X * this.X) + (this.Y * this.Y));
        }

        //Normalizes the vector
        public void Normalize()
        {
            float length = Length();

            this.X = this.X / length;
            this.Y = this.Y / length;
        }
    }
}