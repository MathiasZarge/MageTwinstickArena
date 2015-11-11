using System.Drawing;

namespace MageTwinstick
{
    class Player : Unit
    {
        public Player(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed) 
            : base(imagePath, startPos, display, animationSpeed)
        {
        }
    }
}