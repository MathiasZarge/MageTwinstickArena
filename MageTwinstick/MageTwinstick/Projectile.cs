using System.Drawing;

namespace MageTwinstick
{
    class Projectile : MovingObject
    {
        /// <summary>
        /// Fields.
        /// </summary>
        private Vector2D velocity; //<! Filed to store the velocity.

        public Projectile(float speed, string imagePath, Vector2D startPos, Rectangle display, float animationSpeed) : base(speed, imagePath, startPos, display, animationSpeed)
        {
            //Makes a unit vector for the direction of the mouse.
            velocity = Position.Subtract(new Vector2D(Mouse.X,Mouse.Y));
            velocity.Normalize();
        }

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