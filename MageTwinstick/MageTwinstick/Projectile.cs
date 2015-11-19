using System.Drawing;

namespace MageTwinstick
{
    /// <summary>
    /// Projectile used in the Players Attack method
    /// </summary>
    class Projectile : MovingObject
    {
        /// <summary>
        /// Fields.
        /// </summary>
        private Vector2D velocity; //<! Filed to store the velocity.
        /// <summary>
        /// Projectile constructor
        /// </summary>
        /// <param name="speed">The Objects speed</param>
        /// <param name="imagePath">The Path For the image sprite</param>
        /// <param name="startPos">Starting Position</param>
        /// <param name="display">Display Rectangle</param>
        /// <param name="animationSpeed">Speed of the animation</param>
        public Projectile(float speed, string imagePath, Vector2D startPos, Rectangle display, float animationSpeed) : base(speed, imagePath, startPos, display, animationSpeed)
        {
            //Makes a unit vector for the direction of the mouse.
            velocity = Position.Subtract(new Vector2D(Mouse.X,Mouse.Y));
            velocity.Normalize();
        }
        /// <summary>
        /// Override for the update function, runs every Update
        /// </summary>
        /// <param name="fps">current frames per second</param>
        public override void Update(float fps)
        {
            //Move the projectile in the direction of the unit vector.
            Position.X += (1/fps)*(velocity.X*speed);
            Position.Y += (1/fps)*(velocity.Y*speed);

            //Check if the projectile is outside the frame.
            if (Position.X < display.Top -100 | Position.Y < display.Left -100 | Position.X > display.Right +100 | Position.Y > display.Bottom + 100)
            {
                //If it is, remove the object.
                GameWorld.ObjectsToRemove.Add(this);
            }

            //Run base update.
            base.Update(fps);
        }
        /// <summary>
        /// On Collision with another GameObject
        /// </summary>
        /// <param name="other">the other GameObject</param>
        public override void OnCollision(GameObject other)
        {
            //If the collided object is an enemy, remove this object and remove helth from the enemy.
            if (other is Enemy)
            {
                GameWorld.ObjectsToRemove.Add(this);
                (other as Enemy).Health --;
            }
        }
    }
}