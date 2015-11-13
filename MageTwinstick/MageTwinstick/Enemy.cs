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
       
        private void start()
        {
            attackTimer = 0;
            coolDown = 2.0f;
        }

        //Make the enemy chase after the player no matter the players position.
        public override void Update(float fps)
        {
            Vector2D velocity = this.Position.Subtract(player.Position);
            velocity.Normalize();

            Position.X += (1 / fps) * (velocity.X*speed);
            Position.Y += (1 / fps) * (velocity.Y*speed);
            base.Update(1 / fps);
        }

        //Attack command and prevents the enemy from constantly ticking damage on the player
        public override void Attack()

        {
            if (attackTimer < 0)
                attackTimer = 0;
            if (attackTimer == 0)
            {
                Attack();
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