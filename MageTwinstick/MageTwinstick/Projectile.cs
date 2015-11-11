using System.Drawing;

namespace MageTwinstick
{
    class Projectile : GameObject
    {
        public Projectile(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
            : base(imagePath, startPos, display, animationSpeed)
        {
        }
    }
}