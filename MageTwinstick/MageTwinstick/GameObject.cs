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
        protected float animationSpeed;
        private RectangleF collisionBox;

        //Properteis
        public Vector2D Position { get; set; }
        public RectangleF CollisionBox { get; }

        //Constructer
        public GameObject(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
        {
            this.Position = startPos;
            this.display = display;
            this.animationSpeed = animationSpeed;

            string[] imagePaths = imagePath.Split(';');
            animationFrames = new List<Image>();

            foreach (string path in imagePaths)
            {
                animationFrames.Add(Image.FromFile(path));
            }
            sprite = animationFrames[0];
        }

        //Methods

    }
}