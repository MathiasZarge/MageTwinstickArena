using System.Drawing;

namespace MageTwinstick
{
    class HealthRegen : PowerUp
    {
        public HealthRegen(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
            : base(imagePath, startPos, display, animationSpeed)
        {
        }

        public override void OnCollision(GameObject other)
        {
            ApplyEffect(other);

            base.OnCollision(other);
        }

        public void ApplyEffect(GameObject other)
        {
            if (other is Player)
            {
                if ((other as Player).Health < 50)
                {
                    (other as Player).Health += 50;
                }
                else
                {
                    (other as Player).Health = 100;
                }
            }
        }
    }
}