using System.Drawing;

namespace MageTwinstick
{
    class Enemy : Unit
    {
        public Enemy(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed) 
            : base(imagePath, startPos, display, animationSpeed)
        {
        }
    }
}