using System.Drawing;

namespace MageTwinstick
{
    class Projectile : MovingObject
    {
        public Projectile(float speed, string imagePath, Vector2D startPos, Rectangle display, float animationSpeed) : base(speed, imagePath, startPos, display, animationSpeed)
        {
        }
    }
}