﻿using System;
using System.Drawing;

namespace MageTwinstick
{
    internal class Enemy : Unit
    {
        public float attackTimer;
        public float coolDown;
        private Player player;
        private Random random = new Random();

        //Methods to be used in attack  
        /// <summary>
        /// Enemy constructor
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="health"></param>
        /// <param name="imagePath"></param>
        /// <param name="startPos"></param>
        /// <param name="display"></param>
        /// <param name="animationSpeed"></param>
        /// <param name="attackTimer"></param>
        /// <param name="coolDown"></param>
        /// <param name="player"></param>
        public Enemy(float speed, int health, string imagePath, Vector2D startPos, Rectangle display,
            float animationSpeed, float attackTimer, float coolDown, Player player)
            : base(speed, health, imagePath, startPos, display, animationSpeed)
        {
            this.attackTimer = attackTimer;
            this.coolDown = coolDown;
            this.player = player;
        }
       
        /// <summary>
        /// Cause the Enemy to chase the Player regardless of the Player's position 
        /// </summary>
        /// <param name="fps"></param>
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
                player.Score += 100;
                GameWorld.ObjectsToRemove.Add(this);
                double r = random.Next(0, 101);
                if (r > 95)
                {
                    GameWorld.ObjectsToAdd.Add(new HealthRegen(@"Images\Powerups\healthPowerUp.png", new Vector2D(Position.X, Position.Y), display,1));
                }
                else if (r < 50)
                {
                    GameWorld.ObjectsToAdd.Add(new ManaRegen(@"Images\Powerups\manaPowerUp.png", new Vector2D(Position.X, Position.Y), display, 1));
                }

            }
            base.Update(fps);
        }
        /// <summary>
        /// Properly rotates and draws the objects sprite in the GameWorld
        /// </summary>
        /// <param name="dc"></param>
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

        /// <summary>
        /// Attack command and prevents the Enemy from constantly damaging on the Player
        /// </summary>
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

        /// <summary>
        /// Enemy collison and its response to different GameObject's.
        /// </summary>
        /// <param name="other"></param>
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