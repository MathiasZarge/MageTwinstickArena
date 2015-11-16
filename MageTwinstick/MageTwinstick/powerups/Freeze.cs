using System.Drawing;

namespace MageTwinstick
{
    class Freeze : PowerUp
    {
        public Freeze(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
            : base(imagePath, startPos, display, animationSpeed)
        {
        }
    }
}