using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageTwinstick
{
    class EnemyControlles
    {
        private float time;
        List<GameObject>
        public virtual void Update(float fps)
        {
            time += 1 / fps;
            if (time >= 1)
            {
                time = 0;
                GameWorld.Objects.add(new Enemy(30, 50, @"Images\Scorpion\Move\0.png; Images\Scorpion\Move\1.png; Images\Scorpion\Move\2.png; Images\Scorpion\Move\3.png; Images\Scorpion\Move\4.png; Images\Scorpion\Move\5.png; Images\Scorpion\Move\6.png; Images\Scorpion\Move\7.png", new Vector2D(0, 0), display, 1, 0, 2.0f, player));
            }
        }
    }
}
