using System.Drawing;

namespace MageTwinstick
{

    class MovingObject : GameObject
    {
        protected float speed;

        public MovingObject(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed) 
            : base(imagePath, startPos, display, animationSpeed)
        {
        }

        public override void OnCollision(GameObject other)
        {
            throw new System.NotImplementedException();
        }
    }
}