using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;


namespace MageTwinstick
{
    /// <summary>
    /// Creates Enemy objects in the GameWorld
    /// </summary>
    class EnemySpawner
    {

        /// Properties that are set beforehand for the enemies.
        private float time = 0;                  /*!<Time is set to zero in the beginning of the game*/
        private int spawnCounter = 3;            /*!<Sets the spawnCounter to one to make sure an enemy spawns and to increase the number of enemies in latter rounds*/
        private Rectangle display;               /*!<Property that the enemy needs in its constructor*/
        private Player player;                   /*!<Property that the enemy needs in its constructor*/
        private float angle;                   /*!<Used to describe the angle in which the enemy will spawn*/
        private float posX;                    /*!<Used to calculate the position of the enemy on the X axis*/
        private float posY;                    /*!<Used to calculate the position of the enemy on the Y axis*/
        private Random rnd = new Random();       /*!Used to create the random number to determin the position of the enemy spawning*/
        private List<bool> spawned = new List<bool> { false, false, false, false };     /*!<Bools used to check if the enemies have been spawned and make sure that only the appropriate number of enemies spawn each round*/


        public EnemySpawner(Rectangle display, Player player)
        {
            this.display = display;
            this.player = player;
        }

        //Updates to add enemies onto the field
        public virtual void Update(float fps)
        {

            //Used for deciding the time and what time for enemies to spawn.
            time += (1 / fps);
            //Checking time to see if it is time for this type of enemy to spawn.
            if (time >= 1 && !spawned[0])
            {
                //Making sure a greater number of this type of enemy is spawning with every passing round.
                for (int i = 0; i < spawnCounter; i++)
                {
                    //Creates this type of enemy in the game.
                    angle = (float)(rnd.NextDouble() * 360);
                    posX = 650f * (float)Math.Cos(angle) + display.Width / 2;
                    posY = 500f * (float)Math.Sin(angle) + display.Height / 2;
                    GameWorld.ObjectsToAdd.Add(new Enemy(100, 75, @"Images\Crawler\Move\0.png;Images\Crawler\Move\1.png;Images\Crawler\Move\2.png;Images\Crawler\Move\3.png;Images\Crawler\Move\4.png;Images\Crawler\Move\5.png;Images\Crawler\Move\6.png;Images\Crawler\Move\7.png", new Vector2D(posX, posY), display, 15, 0, 2.0f, player));
                }
                
                spawned[0] = true; //!<Setting the enemy spawner to true, to make sure that only the appropriate number of enemies is spawned each round.
            }
            //Most of the functions below are the same as the above.
            if (time >= 5 && !spawned[1])
            {
                for (int i = 0; i < spawnCounter; i++)
                {
                    angle = (float)(rnd.NextDouble() * 360);
                    posX = 650f * (float)Math.Cos(angle) + display.Width / 2;
                    posY = 500f * (float)Math.Sin(angle) + display.Height / 2;
                    GameWorld.ObjectsToAdd.Add(new Enemy(125, 50, @"Images\Scorpion\Move\0.png;Images\Scorpion\Move\1.png;Images\Scorpion\Move\2.png;Images\Scorpion\Move\3.png", new Vector2D(posX, posY), display, 20, 0, 2.0f, player));
                }
                spawned[1] = true;
            }
            if (time >= 10 && !spawned[2])
            {
                for (int i = 0; i < spawnCounter; i++)
                {
                    angle = (float)(rnd.NextDouble() * 360);
                    posX = 650f * (float)Math.Cos(angle) + display.Width / 2;
                    posY = 500f * (float)Math.Sin(angle) + display.Height / 2;
                    GameWorld.ObjectsToAdd.Add(new Enemy(50, 125, @"Images\Demon\Move\0.png;Images\Demon\Move\1.png;Images\Demon\Move\2.png;Images\Demon\Move\3.png;Images\Demon\Move\4.png;Images\Demon\Move\5.png;Images\Demon\Move\6.png;Images\Demon\Move\7.png", new Vector2D(posX, posY), display, 10, 0, 2.0f, player));
                }
                spawned[2] = true;
            }
            if (time >= 20 && !spawned[3])
            {
                for (int i = 0; i < spawnCounter; i++)
                {
                    angle = (float)(rnd.NextDouble() * 360);
                    posX = 650f * (float)Math.Cos(angle) + display.Width / 2;
                    posY = 500f * (float)Math.Sin(angle) + display.Height / 2;
                    GameWorld.ObjectsToAdd.Add(new Enemy(50, 200, @"Images\Gargant\Move\0.png;Images\Gargant\Move\1.png;Images\Gargant\Move\2.png;Images\Gargant\Move\3.png;Images\Gargant\Move\4.png;Images\Gargant\Move\5.png;Images\Gargant\Move\6.png;Images\Gargant\Move\7.png", new Vector2D(posX, posY), display, 10, 0, 2.0f, player));
                }
                spawned[0] = false;
                spawned[1] = false;
                spawned[2] = false;
                spawnCounter++;
                time = 0;
            }
        }
    }
}
