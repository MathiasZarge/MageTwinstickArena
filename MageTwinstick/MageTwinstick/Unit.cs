using System.Drawing;

namespace MageTwinstick
{
    class Unit : MovingObject
    {
        public Unit(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
            : base(imagePath, startPos, display, animationSpeed)
        {
        }
    }
}