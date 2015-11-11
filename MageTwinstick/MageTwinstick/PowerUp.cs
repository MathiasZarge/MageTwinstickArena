using System;
using System.Drawing;

namespace MageTwinstick
{
<<<<<<< HEAD
    //type of PowerUp
=======
    //Type of PowerUp
>>>>>>> origin/master
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
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
        //removes itself at Collision with player
        public override void OnCollision(GameObject other)
        {
            if(other is Player)
            {
                GameWorld.ObjectsToRemove.Add(this);
            }
=======
>>>>>>> PowerUpOnCollision

        public override void OnCollision(GameObject other)
        {
            throw new System.NotImplementedException();
<<<<<<< HEAD
=======
>>>>>>> refs/remotes/origin/master
>>>>>>> PowerUpOnCollision
=======
        //Removes itself when colliding with the player
        public override void OnCollision(GameObject other)
        {
            if(other is Player)
            {
                GameWorld.ObjectsToRemove.Add(this);
            }
>>>>>>> origin/master
        }
    }
}