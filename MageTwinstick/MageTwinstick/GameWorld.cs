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
            Objects.Add(new Arena(@"Images\Background.png",new Vector2D(0,0), display, 1));
            Objects.Add(new Player(150, 100, @"Images\Player\Idle\0.png", new Vector2D(display.Width/2f, display.Height/2f), display, 10));
            endTime = DateTime.Now;
        }

        public void GameLoop()
        {
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
            dc.DrawString(string.Format("{0}, {1}, {2}",Convert.ToString(currentFps), Mouse.X, Mouse.Y), f, Brushes.Black,10,10);
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