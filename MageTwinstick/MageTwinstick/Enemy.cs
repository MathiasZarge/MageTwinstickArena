using System;
using System.Drawing;

namespace MageTwinstick
{
    internal class Enemy : Unit
    {



        public float attackTimer;
        public float coolDown;
        private Player player;


        //Methods to be used in attack  
        public Enemy(float speed, int health, string imagePath, Vector2D startPos, Rectangle display,
            float animationSpeed, float attackTimer, float coolDown, Player player)
            : base(speed, health, imagePath, startPos, display, animationSpeed)
        {
            this.attackTimer = attackTimer;
            this.coolDown = coolDown;
            this.player = player;
        }
       
        //Make the enemy chase after the player no matter the players position.
        public override void Update(float fps)
        {
            Vector2D velocity = this.Position.Subtract(player.Position);
            velocity.Normalize();

            Position.X += (1 / fps) * (velocity.X*speed);
            Position.Y += (1 / fps) * (velocity.Y*speed);
            if (attackTimer > 0)
                attackTimer -= 0.1f;

            if (Health <= 0)
            {
                GameWorld.ObjectsToRemove.Add(this);
            }
            base.Update(1 / fps);
        }

        public override void Draw(Graphics dc)
        {
            //make a vector with origin in the center of the sprite
            Vector2D spriteCenter = new Vector2D(Position.X + sprite.Width / 2f, Position.Y + sprite.Height / 2f);
            //subtract that vector with the mouse position
            Vector2D vec = spriteCenter.Subtract(player.Position);
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

        //Attack command and prevents the enemy from constantly ticking damage on the player
        public override void Attack()

        {
            if (attackTimer < 0)
            {
                attackTimer = 0;
            }
            if (attackTimer == 0)
            {
                player.Health -= 10;
                attackTimer = coolDown;
            }
        }

        //Enemy collison and its response to different objects.
        public override void OnCollision(GameObject other)
        {
            if (other is Projectile)
            {
                Health -= 25;
            }
            if (other is Player)
            {
                Attack();
            }
        }
    }
}