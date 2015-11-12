using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

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
        //Auto properties for the values
        public Vector2D Position { get; set; }
        public RectangleF CollisionBox { get; }

        //Constructer
        public GameObject(string imagePath, Vector2D startPos, Rectangle display, float animationSpeed)
        {
            //Assigning the values to the fields
            this.Position = startPos;
            this.display = display;
            this.animationSpeed = animationSpeed;

            //Spit the inputted imagepaths to we can have animations
            string[] imagePaths = imagePath.Split(';');
            //Initate the list ´to we can use it
            animationFrames = new List<Image>();

            //Add each image to the list from the paths in the paths array
            foreach (string path in imagePaths)
            {
                animationFrames.Add(Image.FromFile(path));
            }
            //Set the sprite to the first fram in the animation
            sprite = animationFrames[0];
        }

        //Methods
        public virtual void Draw(Graphics dc)
        {
            //Draws the sprite
            dc.DrawImage(sprite, Position.X, Position.Y, sprite.Width, sprite.Height);
        }

        public virtual void Update(float fps)
        {
            CheckCollision();
        }

        public virtual void UpdateAnimation(float fps)
        {
            //make a factor based on the fps
            float factor = 1 / fps;

            //set the current fram of the animation depending on the speed an the factor
            currentFrameIndex += factor * animationSpeed;

            //Reset the animation if it is done
            if (currentFrameIndex >= animationFrames.Count)
            {
                currentFrameIndex = 0;
            }

            //Apply the current frame to the sprite
            sprite = animationFrames[(int)currentFrameIndex];
        }

        public void CheckCollision()
        {
            //Check if the current object is colliding with any one of the object currently in the list
            foreach (GameObject go in GameWorld.Objects)
            {
                //Dont check it self
                if (go != this)
                {
                    // if it is colliding with some thing
                    if (IsCollidingWith(go))
                    {
                        OnCollision(go);
                    }
                }
            }
        }

        public bool IsCollidingWith(GameObject other)
        {
            //Return wether two collisionboxes are collising
            return collisionBox.IntersectsWith(other.CollisionBox);
        }

        //abstract method for functionality when colliding
        public abstract void OnCollision(GameObject other);
    }
}