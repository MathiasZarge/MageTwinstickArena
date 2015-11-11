using System.Drawing;

namespace MageTwinstick
{
    class EnemyProjectile : Projectile
    {
        public EnemyProjectile(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
            : base(imagePath, startPos, display, animationSpeed)
        {
        }
    }
}