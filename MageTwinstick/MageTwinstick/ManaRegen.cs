using System.Drawing;

namespace MageTwinstick
{
    class ManaRegen : PowerUp
    {
        public ManaRegen(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
            : base(imagePath, startPos, display, animationSpeed)
        {
        }
    }
}