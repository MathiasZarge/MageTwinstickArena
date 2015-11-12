using System;
using System.Drawing;

namespace MageTwinstick
{

    //type of PowerUp

    //Type of PowerUp

    enum PowerUpType
    {
        Freeze, HealthRegen, ManaRegen
    }
    class PowerUp : GameObject
    {
        //constructor for PowerUp
        public PowerUp(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
            : base(imagePath, startPos, display, animationSpeed)
        {
        }

        //removes itself at Collision with player
        public override void OnCollision(GameObject other)
        {
            if (other is Player)
            {
                GameWorld.ObjectsToRemove.Add(this);
            }
        }
    }
}