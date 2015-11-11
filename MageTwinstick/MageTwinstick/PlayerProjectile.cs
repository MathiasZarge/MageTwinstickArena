using System.Drawing;

namespace MageTwinstick
{
    class PlayerProjectile : Projectile
    {
        public PlayerProjectile(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
            : base(imagePath, startPos, display, animationSpeed)
        {
        }
    }
}