using System.Drawing;

namespace MageTwinstick
{
    abstract class Unit : MovingObject
    {
        private int _health;

        protected int health
<<<<<<< HEAD
        {
            get { return _health; }
            set { _health = value; }
        }

        protected Unit(float speed,int health, string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)

      
            : base(speed, imagePath, startPos, display, animationSpeed)
        {
            _health = health;
        }

=======
        {
            get { return _health; }
            set { _health = value; }
        }

        public Unit(float speed,int health, string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
            : base(speed, imagePath, startPos, display, animationSpeed)
        {
            _health = health;
        }

>>>>>>> refs/remotes/origin/master
       public abstract void Attack();
    }
}