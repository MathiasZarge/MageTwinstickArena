using System;
using System.Drawing;

namespace MageTwinstick
{
    //type of PowerUp
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
<<<<<<< HEAD
        //removes itself at Collision with player
        public override void OnCollision(GameObject other)
        {
            if(other is Player)
            {
                GameWorld.ObjectsToRemove.Add(this);
            }
=======

        public override void OnCollision(GameObject other)
        {
            throw new System.NotImplementedException();
>>>>>>> refs/remotes/origin/master
        }
    }
}