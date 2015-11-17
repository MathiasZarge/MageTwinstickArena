using System.Drawing;

namespace MageTwinstick
{
    abstract class Unit : MovingObject
    {
        public double Health { get; set; }

     /// <summary>
     /// Unit Constructor
     /// </summary>
     /// <param name="speed"></param>
     /// <param name="health"></param>
     /// <param name="imagePath"></param>
     /// <param name="startPos"></param>
     /// <param name="display"></param>
     /// <param name="animationSpeed"></param>
        public Unit(float speed,int health, string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
            : base(speed, imagePath, startPos, display, animationSpeed)
        {
            Health = health;
        }

        /// <summary>
        /// Abstract function Attack
        /// </summary>
       public abstract void Attack();
    }
}