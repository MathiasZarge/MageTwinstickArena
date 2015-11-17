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
        private float time = 0;
        private int spawnCounter = 1;
        List<GameObject> enemy = new List<GameObject>();
        private Rectangle display;
        private Player player;
        List<bool> spawned = new List<bool> { false, false, false, false };

        public EnemySpawner(Rectangle display, Player player)
        {
            this.display = display;
            this.player = player;
        }

        //Updates to add enemies onto the field
        public virtual void Update(float fps)
        {
            
            time += (1/fps);
            if (time >= 1 && !spawned[0])
            {
                for (int i = 0; i < spawnCounter; i++)
                {
                    GameWorld.ObjectsToAdd.Add(new Enemy(100, 75, @"Images\Crawler\Move\0.png;Images\Crawler\Move\1.png;Images\Crawler\Move\2.png;Images\Crawler\Move\3.png;Images\Crawler\Move\4.png;Images\Crawler\Move\5.png;Images\Crawler\Move\6.png;Images\Crawler\Move\7.png", new Vector2D(300, 0), display, 15, 0, 2.0f, player));
                }
                spawned[0] = true;
            }
            if (time >= 5 && !spawned[1])
            {
                for (int i = 0; i < spawnCounter; i++)
                {
                    GameWorld.ObjectsToAdd.Add(new Enemy(125, 50, @"Images\Scorpion\Move\0.png;Images\Scorpion\Move\1.png;Images\Scorpion\Move\2.png;Images\Scorpion\Move\3.png", new Vector2D(900, 0), display, 20, 0, 2.0f, player));
                }
                spawned[1] = true;
            }
            if (time >= 10 && !spawned[2])
            {
                for (int i = 0; i < spawnCounter; i++)
                {
                    GameWorld.ObjectsToAdd.Add(new Enemy(50, 125, @"Images\Demon\Move\0.png;Images\Demon\Move\1.png;Images\Demon\Move\2.png;Images\Demon\Move\3.png;Images\Demon\Move\4.png;Images\Demon\Move\5.png;Images\Demon\Move\6.png;Images\Demon\Move\7.png", new Vector2D(600, 0), display, 10, 0, 2.0f, player));
                }
                spawned[2] = true;
            }
            if (time >= 20 && !spawned[3])
            {
                for (int i = 0; i < spawnCounter; i++)
                {
                    GameWorld.ObjectsToAdd.Add(new Enemy(50, 200, @"Images\Gargant\Move\0.png;Images\Gargant\Move\1.png;Images\Gargant\Move\2.png;Images\Gargant\Move\3.png;Images\Gargant\Move\4.png;Images\Gargant\Move\5.png;Images\Gargant\Move\6.png;Images\Gargant\Move\7.png", new Vector2D(0, 0), display, 10, 0, 2.0f, player));
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
