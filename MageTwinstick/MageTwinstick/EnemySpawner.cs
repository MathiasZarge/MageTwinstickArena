using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;


namespace MageTwinstick
{
    class EnemySpawner
    {
        /// <summary>
        /// Properties
        /// </summary>
        private float time = 0;
        private int spawnCounter = 1;
        private Rectangle display;
        private Player player;
        protected float angle;
        protected float posX;
        protected float posY;
        private Random rnd = new Random();
        List<bool> spawned = new List<bool> { false, false, false, false };

        /// <summary>
        /// The method of the enemy constructor.
        /// </summary>
        /// <param name="display"></param>
        /// <param name="player"></param>
        public EnemySpawner(Rectangle display, Player player)
        {
            this.display = display;
            this.player = player;
        }

        /// <summary>
        /// Updates to add enemies onto the field.
        /// </summary>
        /// <param name="fps"></param>
        public virtual void Update(float fps)
        {

            //Used for deciding the time and what time for enemies to spawn.
            time += (1 / fps);
            //Checking time to see if it is time for this type of enemy to spawn.
            if (time >= 1 && !spawned[0])
            {
                //Making sure a increased number of this type of enemy is spawning with every passing round.
                for (int i = 0; i < spawnCounter; i++)
                {
                    //Creates this type of enemy in the game at a random position in a circle around the player.
                    angle = (float)(rnd.NextDouble() * 360);
                    posX = 750f * (float)Math.Cos(angle) + display.Width / 2;
                    posY = 550f * (float)Math.Sin(angle) + display.Height / 2;
                    GameWorld.ObjectsToAdd.Add(new Enemy(100, 75, @"Images\Crawler\Move\0.png;Images\Crawler\Move\1.png;Images\Crawler\Move\2.png;Images\Crawler\Move\3.png;Images\Crawler\Move\4.png;Images\Crawler\Move\5.png;Images\Crawler\Move\6.png;Images\Crawler\Move\7.png", new Vector2D(posX, posY), display, 15, 0, 2.0f, player));
                }

                spawned[0] = true;
            }
            //Most of the functions below are the same as the above.
            if (time >= 5 && !spawned[1])
            {
                for (int i = 0; i < spawnCounter; i++)
                {
                    angle = (float)(rnd.NextDouble() * 360);
                    posX = 600f * (float)Math.Cos(angle) + display.Width / 2;
                    posY = 600f * (float)Math.Sin(angle) + display.Height / 2;
                    GameWorld.ObjectsToAdd.Add(new Enemy(125, 50, @"Images\Scorpion\Move\0.png;Images\Scorpion\Move\1.png;Images\Scorpion\Move\2.png;Images\Scorpion\Move\3.png", new Vector2D(posX, posY), display, 20, 0, 2.0f, player));
                }
                spawned[1] = true;
            }
            //Most of the functions below are the same as the above.
            if (time >= 10 && !spawned[2])
            {
                for (int i = 0; i < spawnCounter; i++)
                {
                    angle = (float)(rnd.NextDouble() * 360);
                    posX = 600f * (float)Math.Cos(angle) + display.Width / 2;
                    posY = 600f * (float)Math.Sin(angle) + display.Height / 2;
                    GameWorld.ObjectsToAdd.Add(new Enemy(50, 125, @"Images\Demon\Move\0.png;Images\Demon\Move\1.png;Images\Demon\Move\2.png;Images\Demon\Move\3.png;Images\Demon\Move\4.png;Images\Demon\Move\5.png;Images\Demon\Move\6.png;Images\Demon\Move\7.png", new Vector2D(posX, posY), display, 10, 0, 2.0f, player));
                }
                spawned[2] = true;
            }
            //Most of the functions below are the same as the above.
            if (time >= 20 && !spawned[3])
            {
                for (int i = 0; i < spawnCounter; i++)
                {
                    angle = (float)(rnd.NextDouble() * 360);
                    posX = 600f * (float)Math.Cos(angle) + display.Width / 2;
                    posY = 600f * (float)Math.Sin(angle) + display.Height / 2;
                    GameWorld.ObjectsToAdd.Add(new Enemy(50, 200, @"Images\Gargant\Move\0.png;Images\Gargant\Move\1.png;Images\Gargant\Move\2.png;Images\Gargant\Move\3.png;Images\Gargant\Move\4.png;Images\Gargant\Move\5.png;Images\Gargant\Move\6.png;Images\Gargant\Move\7.png", new Vector2D(posX, posY), display, 10, 0, 2.0f, player));
                }
                // Adds a counter to spawnCounter to increase the number of enemies spawned every round.
                // Reseting the time back to zero to restart the round with a now increased numbers of enemies.
                spawned[0] = false;
                spawned[1] = false;
                spawned[2] = false;
                spawnCounter++;
                time = 0;
            }
        }
    }
}
