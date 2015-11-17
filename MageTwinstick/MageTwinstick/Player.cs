using System;
using System.Drawing;
using System.Windows.Forms;
using RandGame;

namespace MageTwinstick
{
    class Player : Unit
    {
        //Properties
        public double Mana { get; set; }
       /// <summary>
       /// Player Constructor
       /// </summary>
       /// <param name="speed"></param>
       /// <param name="health"></param>
       /// <param name="imagePath"></param>
       /// <param name="startPos"></param>
       /// <param name="display"></param>
       /// <param name="animationSpeed"></param>
        public Player(float speed, int health, string imagePath, Vector2D startPos, Rectangle display, float animationSpeed) : base(speed, health, imagePath, startPos, display, animationSpeed)
        {
            Mana = 100;
        }

        /// <summary>
        /// move the character in the direction of the keys
        /// </summary>
        /// <param name="fps"></param>
        public override void Update(float fps)
        {
            if (Keyboard.IsKeyDown(Keys.W))
            {
                Position.Y -= 1 / fps * speed;
            }
            if (Keyboard.IsKeyDown(Keys.A))
            {
                Position.X -= 1 / fps * speed;
            }
            if (Keyboard.IsKeyDown(Keys.S))
            {
                Position.Y += 1 / fps * speed;
            }
            if (Keyboard.IsKeyDown(Keys.D))
            {
                Position.X += 1 / fps * speed;
            }

            if (Mana < 100)
            {
                Mana += 1/fps*10f;
            }

            base.Update(fps);
        }
        /// <summary>
        /// Detects Collision with other GameObject objects
        /// </summary>
        /// <param name="other"></param>
        public override void OnCollision(GameObject other)
        {
            
        }
        /// <summary>
        /// draws the Graphics in the GameWorld
        /// </summary>
        /// <param name="dc"></param>
        public override void Draw(Graphics dc)
        {
            //make a vector with origin in the center of the sprite
            Vector2D playerCenter = new Vector2D(Position.X + sprite.Width / 2f, Position.Y + sprite.Height / 2f);
            //subtract that vector with the mouse position
            Vector2D vec = playerCenter.Subtract(new Vector2D(Mouse.X, Mouse.Y));
            //normalize that vector
            vec.Normalize();

            //calulate the angle form the normalized vector
            angle = Math.Atan2(vec.Y, vec.X) * 180 / Math.PI;

            //Change the origin on the coordinate system to the center of the sprite
            dc.TranslateTransform(Position.X + sprite.Width / 2f, Position.Y + sprite.Height / 2f);
            //Rotate the coordinate system the desired degrees
            dc.RotateTransform((float)angle + 90);
            //Draw the sprite
            dc.DrawImage(sprite, 0 - sprite.Width / 2, 0 - sprite.Height / 2, sprite.Width, sprite.Height);
            //Reset the graphics
            dc.ResetTransform();
        }
        /// <summary>
        /// attacks by adding a projetcile in front of the player
        /// </summary>
        public override void Attack()
        {
            if (Mana >= 5)
            {
                //make a vector with origin in the center of the sprite
                Vector2D playerCenter = new Vector2D(Position.X + sprite.Width/2, Position.Y + sprite.Height/2);
                //subtract that vector with the mouse position
                Vector2D vec = playerCenter.Subtract(new Vector2D(Mouse.X, Mouse.Y));
                //normalize that vector
                vec.Normalize();

                //place the projectile in front of the player
                GameWorld.ObjectsToAdd.Add(new Projectile(700, @"Images\Player\Spell.png",
                    new Vector2D(Position.X + vec.X*25, Position.Y + vec.Y*25), display, 1));
                Mana -= 5;
            }
        }
    }
}