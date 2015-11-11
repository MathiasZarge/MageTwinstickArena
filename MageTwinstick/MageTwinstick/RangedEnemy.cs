using System.Drawing;

namespace MageTwinstick
{
    class RangedEnemy:Enemy
    {
        public RangedEnemy(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
            : base(imagePath, startPos, display, animationSpeed)
        {
        }
    }
}