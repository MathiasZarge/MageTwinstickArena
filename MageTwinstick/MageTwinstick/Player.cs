using System.Drawing;
using System.Windows.Forms;
using RandGame;

namespace MageTwinstick
{
    class Player : Unit
    {
        
        public Player(float speed, int health, string imagePath, Vector2D startPos, Rectangle display, float animationSpeed) : base(speed, health, imagePath, startPos, display, animationSpeed)
        {
        }

        public override void Update(float fps)
        {
            if (Keyboard.IsKeyDown(Keys.W))
            {
                Position.Y -= 1/fps*speed;
            }
            if (Keyboard.IsKeyDown(Keys.A))
            {
                Position.X -= 1/fps*speed;
            }
            if (Keyboard.IsKeyDown(Keys.S))
            {
                Position.Y += 1/fps*speed;
            }
            if (Keyboard.IsKeyDown(Keys.D))
            {
                Position.X += 1/fps*speed;
            }

            base.Update(fps);
        }

        public override void Attack()
        {
            throw new System.NotImplementedException();
        }
    }
}