using System.Drawing;

namespace MageTwinstick
{
    class PlayerProjectile : Projectile
    {
        public PlayerProjectile(float speed, string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
            : base(speed, imagePath, startPos, display, animationSpeed)
        {
        }
    }
}