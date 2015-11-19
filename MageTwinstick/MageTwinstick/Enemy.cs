using System;
using System.Drawing;

namespace MageTwinstick
{
    internal class Enemy : Unit
    {
        private float attackTimer; //!< Used to calculate when an attack is ready
        private float coolDown; //!< Denotes the time between attacks   
        private Player player; //!< Keeps track of the player
        private Random random = new Random(); //!< Random used to drop powerups

        //Methods to be used in attack  
        /// <summary>
        /// Enemy constructor
        /// </summary>
        /// <param name="speed">Enemy movement speed</param>
        /// <param name="health">Enemy starting health</param>
        /// <param name="imagePath">Image path for the sprite</param>
        /// <param name="startPos">Starting position</param>
        /// <param name="display">Display rectangle</param>
        /// <param name="animationSpeed">Speed of the animation</param>
        /// <param name="attackTimer">Countdown for when an attack is ready</param>
        /// <param name="coolDown">Time between attacks</param>
        /// <param name="player">Keeps track of the player</param>
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
            //subtracts the position of the player with the position of this
            Vector2D velocity = this.Position.Subtract(player.Position);
            //makes unit vector
            velocity.Normalize();

            //Moves in the direction of the unit vector
            Position.X += (1 / fps) * (velocity.X*speed);
            Position.Y += (1 / fps) * (velocity.Y*speed);
            // if the attactimer is on cooldown, reduce it
            if (attackTimer > 0)
                attackTimer -= 0.1f;

            // if this objects health is 0 or beclow
            if (Health <= 0)
            {
                // add to player score
                player.Score += 100;
                //remove this object
                GameWorld.ObjectsToRemove.Add(this);
                // Randomize
                float r = random.Next(0, 101);
                // if over 95
                if (r > 95)
                {
                    // spawn health pickup
                    GameWorld.ObjectsToAdd.Add(new HealthRegen(@"Images\Powerups\healthPowerUp.png", new Vector2D(Position.X, Position.Y), display,1));
                }
                // if below 50
                else if (r < 50)
                {
                    // spawn mana
                    GameWorld.ObjectsToAdd.Add(new ManaRegen(@"Images\Powerups\manaPowerUp.png", new Vector2D(Position.X, Position.Y), display, 1));
                }

            }
            base.Update(fps);
        }
        /// <summary>
        /// Properly rotates and draws the objects sprite in the GameWorld
        /// </summary>
        /// <param name="dc">GDI+ for drawing the sprite</param>
        public override void Draw(Graphics dc)
        {
            //Make a vector with origin in the center of the sprite.
            Vector2D spriteCenter = new Vector2D(Position.X + sprite.Width / 2f, Position.Y + sprite.Height / 2f);
            //Subtract that vector with the mouse position.
            Vector2D vec = spriteCenter.Subtract(player.Position);
            //Normalize that vector.
            vec.Normalize();

            //Calulate the angle form the normalized vector.
            angle = Math.Atan2(vec.Y, vec.X) * 180 / Math.PI;

            //Change the origin on the coordinate system to the center of the sprite
            dc.TranslateTransform(Position.X + sprite.Width / 2f, Position.Y + sprite.Height / 2f);
            //Rotate the coordinate system the desired degrees.
            dc.RotateTransform((float)angle + 90);
            //Draw the sprite.
            dc.DrawImage(sprite, 0 - sprite.Width / 2, 0 - sprite.Height / 2, sprite.Width, sprite.Height);
            //Reset the graphics.
            dc.ResetTransform();
        }

        /// <summary>
        /// Attack command and prevents the Enemy from constantly damaging on the Player.
        /// </summary>
        public override void Attack()

        {
            // if the attacktimer is less than 0
            if (attackTimer < 0)
            {
                // set the timer to 0
                attackTimer = 0;
            }
            // if the timer is 0
            if (attackTimer == 0)
            {
                // damage the player
                player.Health -= 10;
                // put the atacktimer on cooldown
                attackTimer = coolDown;
            }
        }

        /// <summary>
        /// Enemy collison and its response to different GameObject's.
        /// </summary>
        /// <param name="other">The other GameObject</param>
        public override void OnCollision(GameObject other)
        {
            // if the other gameobject is of the class projectile
            if (other is Projectile)
            {
                // Loose health form the projectile
                Health -= 25;
            }
            // if other is player
            if (other is Player)
            {
                // call the attack function
                Attack();
            }
        }
    }
}