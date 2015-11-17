using System;
using System.Drawing;
using System.Windows.Forms;
using RandGame;

namespace MageTwinstick
{
    class Player : Unit
    {
        //Properties
        public double Mana { get; set; } // Auto property for mana
        public float Score { get; set; } = 0; // Auto property for score 

        public Player(float speed, int health, string imagePath, Vector2D startPos, Rectangle display, float animationSpeed) : base(speed, health, imagePath, startPos, display, animationSpeed)
        {
            Mana = 100; // Set the starting mana to 100
        }

        // move the character in the direction of the keys
        public override void Update(float fps)
        {
            //Check if the key is pressed and the sprote is within the display rectangle
            if (Keyboard.IsKeyDown(Keys.W) && Position.Y > display.Top)
            {
                Position.Y -= 1 / fps * speed;
            }
            //Check if the key is pressed and the sprote is within the display rectangle
            if (Keyboard.IsKeyDown(Keys.A) && Position.X > display.Left)
            {
                Position.X -= 1 / fps * speed;
            }
            //Check if the key is pressed and the sprote is within the display rectangle minus the sprite 
            if (Keyboard.IsKeyDown(Keys.S) && Position.Y < display.Bottom - sprite.Height)
            {
                Position.Y += 1 / fps * speed;
            }
            //Check if the key is pressed and the sprote is within the display rectangle minus the sprite
            if (Keyboard.IsKeyDown(Keys.D) && Position.X < display.Right - sprite.Width)
            {
                Position.X += 1 / fps * speed;
            }

            if (Mana < 100) // If mana is less than 100
            {
                Mana += 1/fps*10f; // regenerate mana at a set rate, depending on fps
            }

            base.Update(fps);
        }

        public override void OnCollision(GameObject other)
        {
            
        }

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