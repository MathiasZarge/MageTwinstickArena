using System.Drawing;

namespace MageTwinstick
{
    class ManaRegen : PowerUp
    {
        /// <summary>
        /// Constructer for manaregen
        /// </summary>
        /// <param name="imagePath">Path tot he sprite</param>
        /// <param name="startPos">Start position</param>
        /// <param name="display">displayrectangle</param>
        /// <param name="animationSpeed">animationspeed</param>
        public ManaRegen(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
            : base(imagePath, startPos, display, animationSpeed)
        {
        }

        /// <summary>
        /// Collision trigger
        /// </summary>
        /// <param name="other">Other gameobject</param>
        public override void OnCollision(GameObject other)
        {
            // Apply effect to the collided gameobject
            ApplyEffect(other);

            base.OnCollision(other);
        }

        /// <summary>
        /// Ally effect tot other player
        /// </summary>
        /// <param name="other">Other gameobject</param>
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