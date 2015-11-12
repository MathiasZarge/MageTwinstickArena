using System.Drawing;

namespace MageTwinstick
{
    class EnemyProjectile : Projectile
    {
        public EnemyProjectile(float speed, string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
            : base(speed, imagePath, startPos, display, animationSpeed)
        {
        }
    }
}