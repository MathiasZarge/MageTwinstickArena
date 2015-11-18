using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

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
        private EnemySpawner es;
        private bool isRunning = true;

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
            Player player = new Player(200, 100, @"Images\Player\Idle\0.png", new Vector2D(display.Width / 2f, display.Height / 2f), display, 10);


            Objects.Add(new Arena(@"Images\Background.png", new Vector2D(0, 0), display, 1));
            Objects.Add(player);

            es = new EnemySpawner(display, player);

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

            es.Update(currentFps);
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


            Pen p = new Pen(Color.Black, 5);
            Font f = new Font("Arial", 16);
            Player pl = (Player)Objects.Find(x => x is Player);
            double percentage = (300f / 100f) * pl.Health;
            dc.FillRectangle(Brushes.Red, new Rectangle(10, 10, Convert.ToInt32(percentage), 50));
            dc.DrawRectangle(p, new Rectangle(10, 10, 300, 50));
            percentage = (300f / 100f) * pl.Mana;
            dc.FillRectangle(Brushes.Blue, new Rectangle(display.Right - 310, 10, Convert.ToInt32(percentage), 50));
            dc.DrawRectangle(p, new Rectangle(display.Right - 310, 10, 300, 50));
            f = new Font("Arial", 30);
            dc.DrawString(Convert.ToString(pl.Score), f, Brushes.Black, display.Width / 2 - 50, 10);

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