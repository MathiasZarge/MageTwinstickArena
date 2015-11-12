using System.Drawing;

namespace MageTwinstick
{
    class Unit : MovingObject
    {
        protected int health;
        //Properties for Health 
        public int Health { get; set; }

        public Unit(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
            : base(imagePath, startPos, display, animationSpeed)
        {
        }
        public virtual void Attack()
        {

        }
    }
}