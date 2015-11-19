using System;
using System.Drawing;

namespace MageTwinstick
{

    //type of PowerUp
    class PowerUp : GameObject
    {
        /// <summary>
        /// Constructer for Powerup
        /// </summary>
        /// <param name="imagePath">Path tot he sprite</param>
        /// <param name="startPos">Start position</param>
        /// <param name="display">displayrectangle</param>
        /// <param name="animationSpeed">animationspeed</param>
        public PowerUp(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
            : base(imagePath, startPos, display, animationSpeed)
        {
        }

        /// <summary>
        /// Oncollision trigger
        /// </summary>
        /// <param name="other">Other gameobject</param>
        public override void OnCollision(GameObject other)
        {
            // if the other object is player
            if (other is Player)
            {
                // add this object to remove list
                GameWorld.ObjectsToRemove.Add(this);
            }
        }
    }
}