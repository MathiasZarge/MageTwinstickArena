using System;
using System.Drawing;

namespace MageTwinstick
{
    class Vector2D
    {
        private float x;
        private float y;

        public float X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public float Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public Vector2D(PointF position)
        {
            this.x = position.X;
            this.y = position.Y;
        }
        public Vector2D (float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public Vector2D()
        {

        }
        public Vector2D Subtract(Vector2D vec)
        {
            Vector2D newVec = new Vector2D();
            newVec.X = vec.X - this.x;
            newVec.Y = vec.Y - this.y;

            return newVec;
        }
        private float Length()
        {
            return (float)Math.Sqrt((this.x * this.x) + (this.y * this.y));
        }
        public void Normalize()
        {
            float length = Length();

            this.x = this.x / length;
            this.y = this.y / length;
        }
    }
}