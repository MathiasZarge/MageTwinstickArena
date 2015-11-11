using System.Drawing;

namespace MageTwinstick
{
    class MeleeEnemy : Enemy
    {
        public MeleeEnemy(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
            : base(imagePath, startPos, display, animationSpeed)
        {
        }
    }
}