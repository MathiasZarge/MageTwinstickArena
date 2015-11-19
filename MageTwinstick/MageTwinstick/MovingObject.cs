using System.Drawing;

namespace MageTwinstick
{
    /// <summary>
    /// superclass for any object that moves
    /// </summary>
    abstract class MovingObject : GameObject
    {
        protected float speed;//<! field for the speed of the gamobject 
        protected double angle;//<! the angle of rotation

        /// <summary>
        /// constructer for movingobject
        /// </summary>
        /// <param name="speed">the movementspeed of the object</param>
        /// <param name="imagePath">Path to the sprite</param>
        /// <param name="startPos">Position to place the sprite</param>
        /// <param name="display">The displayrectangle</param>
        /// <param name="animationSpeed">animatinospeed</param>
        public MovingObject(float speed, string imagePath, Vector2D startPos, Rectangle display, float animationSpeed) 
            : base(imagePath, startPos, display, animationSpeed)
        {
            this.speed = speed;
        }
    }
}