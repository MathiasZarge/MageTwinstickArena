using System.Drawing;

namespace MageTwinstick
{
    class PowerUp : GameObject
    {
        public PowerUp(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
            : base(imagePath, startPos, display, animationSpeed)
        {
        }
    }
}