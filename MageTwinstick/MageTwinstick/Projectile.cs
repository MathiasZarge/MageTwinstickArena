using System.Drawing;

namespace MageTwinstick
{
    class Projectile : MovingObject
    {
        //fileds
        private Vector2D velocity; // Filed to store the velocity

        public Projectile(float speed, string imagePath, Vector2D startPos, Rectangle display, float animationSpeed) : base(speed, imagePath, startPos, display, animationSpeed)
        {
            //make a unit vector for the direction of the mouse
            velocity = Position.Subtract(new Vector2D(Mouse.X,Mouse.Y));
            velocity.Normalize();
        }

        public override void Update(float fps)
        {
            //Move the projectile on the directino of the unit vector
            Position.X += (1/fps)*(velocity.X*speed);
            Position.Y += (1/fps)*(velocity.Y*speed);

            //Check if the projectile is outside the frame
            if (Position.X < display.Top -100 | Position.Y < display.Left -100 | Position.X > display.Right +100 | Position.Y > display.Bottom + 100)
            {
                //If it is, remove the object
                GameWorld.ObjectsToRemove.Add(this);
            }

            //Run bare update
            base.Update(fps);
        }

        public override void OnCollision(GameObject other)
        {
            //if the collided object is an enemy, remove this object and remove helth from the enemy
            if (other is Enemy)
            {
                GameWorld.ObjectsToRemove.Add(this);
                Enemy e = other as Enemy;;
                e.Health --;
            }
        }
    }
}