using System.Drawing;

namespace MageTwinstick
{
    class ManaRegen : PowerUp
    {
        public ManaRegen(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
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
                if ((other as Player).Mana < 50)
                {
                    (other as Player).Mana += 50;
                }
                else
                {
                    (other as Player).Mana = 100;
                }
            }
        }
    }
}