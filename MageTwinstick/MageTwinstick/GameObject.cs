using System.Collections.Generic;
using System.Drawing;

namespace MageTwinstick
{
    /// <summary>
    /// Superclass for anything that exsist in the GameWorld
    /// </summary>
    abstract class GameObject
    {
        //fields
        protected Image sprite; //!< Image sprite for the GameObject
        protected Rectangle display; //!< Rectangle for the display
        protected List<Image> animationFrames; //!< List of images for animated objects
        protected float currentFrameIndex;//!< the current Frame in the animation 
        protected float animationSpeed;//!< the speed of the animation
        private RectangleF collisionBox;//!< the collider rectangle
        
        //Properteis
        //Auto properties for the values
        /// <summary>
        /// 2D Vector for the GameObject  position
        /// </summary>
        public Vector2D Position { get; set; }
        /// <summary>
        /// Rectanglge for the GameObjects collider
        /// </summary>
        public RectangleF CollisionBox
        {
            get
            {
                collisionBox =  new RectangleF(Position.X, Position.Y, sprite.Width, sprite.Height);
                return collisionBox;
            }
        }

        /// <summary>
        /// GameObject Constructor
        /// </summary>
        /// <param name="imagePath">Image path for the sprite</param>
        /// <param name="startPos">The starting position of the GameObject</param>
        /// <param name="display">Rectangle for the diplay</param>
        /// <param name="animationSpeed">Animation speed for animated objects</param>
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
        /// <summary>
        /// draws the graphics in the GameWorld
        /// </summary>
        /// <param name="dc">GDI+ class for drawing the sprite</param>
        public virtual void Draw(Graphics dc)
        {
            //Draws the sprite
            dc.DrawImage(sprite, Position.X, Position.Y, sprite.Width, sprite.Height);
        }
        /// <summary>
        /// updates the information in the GameObject
        /// </summary>
        /// <param name="fps">Fps used to update based on time</param>
        public virtual void Update(float fps)
        {
            CheckCollision();
        }
        /// <summary>
        /// Animates the sprite on the GameObject
        /// </summary>
        /// <param name="fps">Fps used to update based on time</param>
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
        /// <summary>
        /// Checks for collision with other GameObjects
        /// </summary>
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
        /// <summary>
        /// Checks for collision with a specific GameObject
        /// </summary>
        /// <param name="other">The other GameObject</param>
        /// <returns></returns>
        public bool IsCollidingWith(GameObject other)
        {
            //Return wether two collisionboxes are collising
            return collisionBox.IntersectsWith(other.CollisionBox);
        }

        /// <summary>
        /// Abstract method for functionality when colliding with a specific GameObject
        /// </summary>
        /// <param name="other">The other GameObject</param>
        public abstract void OnCollision(GameObject other);
    }
}