using System;
using System.Collections.Generic;
using System.Drawing;

namespace MageTwinstick
{
    class GameWorld
    {
        //Fields
        private Graphics dc;
        private DateTime endTime;
        private float currentFps;
        private BufferedGraphics backBuffer;
        private Rectangle display;

        //Properties
        //Auto properties for the given values
        public static List<GameObject> Objects { get; set; } = new List<GameObject>();
        public static List<GameObject> ObjectsToRemove { get; set; } = new List<GameObject>();
        public static List<GameObject> ObjectsToAdd { get; set; } = new List<GameObject>();

        //Constructer
        public GameWorld(Graphics dc, Rectangle display) //takes graphics and display as arguments
        {
            this.display = display;
            this.backBuffer = BufferedGraphicsManager.Current.Allocate(dc, display);
            this.dc = backBuffer.Graphics;
        }

        //Methods
        public void SetupWorld() // Setup the world before we begin the game loop
        {
            Player player = new Player(150, 100, @"Images\Player\Idle\0.png", new Vector2D(display.Width / 2f, display.Height / 2f), display, 10);
            Enemy gargant = new Enemy(30, 200, @"Images\Gargant\Move\0.png;Images\Gargant\Move\1.png;Images\Gargant\Move\2.png;Images\Gargant\Move\3.png;Images\Gargant\Move\4.png;Images\Gargant\Move\5.png;Images\Gargant\Move\6.png;Images\Gargant\Move\7.png", new Vector2D(0, 0), display, 20, 0, 2.0f, player);
            Enemy crawler = new Enemy(50, 75, @"Images\Crawler\Move\0.png;Images\Crawler\Move\1.png;Images\Crawler\Move\2.png;Images\Crawler\Move\3.png;Images\Crawler\Move\4.png;Images\Crawler\Move\5.png;Images\Crawler\Move\6.png;Images\Crawler\Move\7.png", new Vector2D(300, 0), display, 20, 0, 2.0f, player);
            Enemy demon = new Enemy(30, 125, @"Images\Demon\Move\0.png;Images\Demon\Move\1.png;Images\Demon\Move\2.png;Images\Demon\Move\3.png;Images\Demon\Move\4.png;Images\Demon\Move\5.png;Images\Demon\Move\6.png;Images\Demon\Move\7.png", new Vector2D(600, 0), display, 20, 0, 2.0f, player);
            Enemy scorpion = new Enemy(75, 50, @"Images\Scorpion\Move\0.png;Images\Scorpion\Move\1.png;Images\Scorpion\Move\2.png;Images\Scorpion\Move\3.png", new Vector2D(900, 0), display, 20, 0, 2.0f, player);

            Objects.Add(new Arena(@"Images\Background.png", new Vector2D(0, 0), display, 1));
            Objects.Add(player);
            Objects.Add(gargant);
            Objects.Add(crawler);
            Objects.Add(demon);
            Objects.Add(scorpion);

            endTime = DateTime.Now;
        }

        public void GameLoop()
        {
            //add pending objects
            foreach (GameObject obj in ObjectsToAdd)
            {
                Objects.Add(obj);
            }
            ObjectsToAdd.Clear();

            //remove pending objects
            foreach (GameObject gameObject in ObjectsToRemove)
            {
                Objects.Remove(gameObject);
            }
            ObjectsToRemove.Clear();

            DateTime startTime = DateTime.Now;

            TimeSpan deltaTime = startTime - endTime;

            int mill = deltaTime.Milliseconds > 0 ? deltaTime.Milliseconds : 1;

            currentFps = 1000 / mill;

            dc.Clear(Color.White);

            Update(); // Update all gameobjects
            UpdateAnimation(); // update all animations
            Draw(); // draw all objects

            endTime = DateTime.Now;
        }

        public void Draw()
        {
            //Call the draw method on all objects in the list
            foreach (GameObject go in Objects)
            {
                go.Draw(dc);
            }

#if DEBUG
            Font f = new Font("Arial", 16);
            dc.DrawString(string.Format("{0}, {1}, {2}", Convert.ToString(currentFps), Mouse.X, Mouse.Y), f, Brushes.Black, 10, 10);
#endif

            backBuffer.Render();
        }

        public void Update()
        {
            //Call the draw method on all objects in the list
            foreach (GameObject go in Objects)
            {
                go.Update(currentFps);
            }
        }

        public void UpdateAnimation()
        {
            //Call the draw method on all objects in the list
            foreach (GameObject go in Objects)
            {
                go.UpdateAnimation(currentFps);
            }
        }
    }
}