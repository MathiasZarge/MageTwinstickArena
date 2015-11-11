using System.Collections.Generic;
using System.Drawing;

namespace MageTwinstick
{
    abstract class GameObject
    {
        //fields
        protected Image sprite;
        protected Rectangle display;
        protected List<Image> animationFrames;
        protected float currentFrameIndex;
        private RectangleF collisionBox;

        //Properteis
        public Vector2D Position { get; set; }
        public RectangleF CollisionBox { get; }

        //Constructer
        public GameObject(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
        {
            
        }
    }
}