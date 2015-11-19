using System.Drawing;

namespace MageTwinstick
{
    abstract class Unit : MovingObject
    {
        /// <summary>
        /// float for the units health
        /// </summary>
        public float Health { get; set; }

     /// <summary>
     /// Unit Constructor
     /// </summary>
     /// <param name="speed">The units movement speed</param>
     /// <param name="health">The units starting health</param>
     /// <param name="imagePath">Image path for the sprite</param>
     /// <param name="startPos">The Units starting position</param>
     /// <param name="display">The display rectangle</param>
     /// <param name="animationSpeed">The speed of the animation</param>
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