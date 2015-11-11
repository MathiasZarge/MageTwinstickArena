using System.Drawing;

namespace MageTwinstick
{
    enum PowerUpType
    {
        Freeze, HealthRegen, ManaRegen
    }
    class PowerUp : GameObject
    {
        public PowerUp(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
            : base(imagePath, startPos, display, animationSpeed)
        {
        }
    }
}