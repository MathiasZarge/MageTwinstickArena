using System.Drawing;

namespace MageTwinstick
{
    abstract class Unit : MovingObject
    {
        private int _health;

        protected int health
        {
            get { return _health; }
            set { _health = value; }
        }

        protected Unit(float speed,int health, string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)

      
            : base(speed, imagePath, startPos, display, animationSpeed)
        {
            _health = health;
        }

       public abstract void Attack();
    }
}