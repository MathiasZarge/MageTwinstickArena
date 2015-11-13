using System.Drawing;

namespace MageTwinstick
{
    class Projectile : MovingObject
    {
        public Projectile(double angle, float speed, string imagePath, Vector2D startPos, Rectangle display, float animationSpeed) : base(speed, imagePath, startPos, display, animationSpeed)
        {
            this.angle = angle;
        }

        public override void Update(float fps)
        {
            Position.Y ++;
            base.Update(fps);
        }

        public override void OnCollision(GameObject other)
        {
            if (other is Enemy)
            {
                GameWorld.ObjectsToRemove.Add(this);
                Enemy e = other as Enemy;;
                e.Health --;
            }
        }
    }
}