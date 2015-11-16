using System.Drawing;

namespace MageTwinstick
{
    abstract class Unit : MovingObject
    {
        public double Health { get; set; }

     
        public Unit(float speed,int health, string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
            : base(speed, imagePath, startPos, display, animationSpeed)
        {
            Health = health;
        }


       public abstract void Attack();
    }
}