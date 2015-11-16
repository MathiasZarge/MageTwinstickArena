using System.Drawing;

namespace MageTwinstick
{

    abstract class MovingObject : GameObject
    {
        protected float speed;
        protected double angle;

        public MovingObject(float speed, string imagePath, Vector2D startPos, Rectangle display, float animationSpeed) 
            : base(imagePath, startPos, display, animationSpeed)
        {
            this.speed = speed;
        }
    }
}