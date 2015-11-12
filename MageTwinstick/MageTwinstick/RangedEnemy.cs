using System.Drawing;

namespace MageTwinstick
{
    class RangedEnemy:Enemy
    {
        public RangedEnemy(float speed, int health, string imagePath, Vector2D startPos, Rectangle display, float animationSpeed) : base(speed, health, imagePath, startPos, display, animationSpeed)
        {
        }
    }
}