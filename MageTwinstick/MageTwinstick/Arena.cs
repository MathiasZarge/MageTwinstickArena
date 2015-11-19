using System.Drawing;

namespace MageTwinstick
{
    class Arena : GameObject
    {
        public Arena(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed) 
            : base(imagePath, startPos, display, animationSpeed)
        {
            
        }

        public override void OnCollision(GameObject other)
        {
            
        }
    }
}