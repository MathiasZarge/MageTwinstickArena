using System.Drawing;

namespace MageTwinstick
{
    class Player : Unit
    {
        
        public Player(float speed, int health, string imagePath, Vector2D startPos, Rectangle display, float animationSpeed) : base(speed, health, imagePath, startPos, display, animationSpeed)
        {
        }

        public override void Attack()
        {
            throw new System.NotImplementedException();
        }
    }
}