using System.Drawing;

namespace MageTwinstick
{
    class HealthRegen : PowerUp
    {
        public HealthRegen(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
            : base(imagePath, startPos, display, animationSpeed)
        {
        }
    }
}