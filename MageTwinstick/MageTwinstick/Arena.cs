using System.Drawing;

namespace MageTwinstick
{
    /// <summary>
    /// Background
    /// </summary>
    class Arena : GameObject
    {
        /// <summary>
        /// Constructor for Arean class
        /// </summary>
        /// <param name="imagePath">The path for the sprite</param>
        /// <param name="startPos">The position to place the sprite at</param>
        /// <param name="display">Displayrectangle</param>
        /// <param name="animationSpeed">animationspeed</param>
        public Arena(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed) 
            : base(imagePath, startPos, display, animationSpeed)
        {
            
        }

        /// <summary>
        /// Collision, nothing happens
        /// </summary>
        /// <param name="other">other gameobject</param>
        public override void OnCollision(GameObject other)
        {
            
        }
    }
}