using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;

namespace MageTwinstick
{
    class GameWorld
    {
        //Fields
        private Graphics dc; //<! The graphis that is used
        private DateTime endTime; //<! The end timeof the last frame
        private float currentFps; //<! the current values of the FPS
        private BufferedGraphics backBuffer; //<! The graphics backbuffer that is used
        private Rectangle display; //<! The displayrectangle
        private EnemySpawner es; //<! the enemyspawner

        //Properties
        //Auto properties for the given values
        /// <summary>
        /// Autorproperty fot the Objects list
        /// </summary>
        public static List<GameObject> Objects { get; set; } = new List<GameObject>();

        /// <summary>
        /// Autorproperty fot the Objects to remove list
        /// </summary>
        public static List<GameObject> ObjectsToRemove { get; set; } = new List<GameObject>();

        /// <summary>
        /// Autorproperty fot the Objects to add list
        /// </summary>
        public static List<GameObject> ObjectsToAdd { get; set; } = new List<GameObject>();

        /// <summary>
        /// Autoproperty for IsRunning
        /// </summary>
        public bool IsRunning { get; set; } = true;

        //Constructer
        /// <summary>
        /// constructer for gameworld
        /// </summary>
        /// <param name="dc">the graphics that is used</param>
        /// <param name="display">Displayrectangle</param>
        public GameWorld(Graphics dc, Rectangle display) //takes graphics and display as arguments
        {
            this.display = display;
            this.backBuffer = BufferedGraphicsManager.Current.Allocate(dc, display);
            this.dc = backBuffer.Graphics;
        }
        
        /// <summary>
        /// Setup word, creates the arena, enemyspawner and a player object
        /// </summary>
        public void SetupWorld() // Setup the world before we begin the game loop
        {
            //initiate a player object
            Player player = new Player(200, 100, @"Images\Player\Idle\0.png", new Vector2D(display.Width / 2f, display.Height / 2f), display, 10);
            
            // add an arena object to the 
            Objects.Add(new Arena(@"Images\Background.png", new Vector2D(0, 0), display, 1));

            //add player to the Objects list
            Objects.Add(player);

            // initate the enemyspawner
            es = new EnemySpawner(display, player);

            // define the end time for the fps calculation
            endTime = DateTime.Now;
        }

        /// <summary>
        /// gameloop, runs wvery tick
        /// </summary>
        public void GameLoop()
        {
            //add pending objects to the objects list
            foreach (GameObject obj in ObjectsToAdd)
            {
                Objects.Add(obj);
            }
            ObjectsToAdd.Clear();

            //remove pending objects form the objects list
            foreach (GameObject gameObject in ObjectsToRemove)
            {
                Objects.Remove(gameObject);
            }

            // clear the remove list
            ObjectsToRemove.Clear();

            // define the start time for the fps calculation
            DateTime startTime = DateTime.Now;

            // calculate the timespan
            TimeSpan deltaTime = startTime - endTime;

            // set the milliseconds to deltatime, if it is more than 0, else set it to one
            int mill = deltaTime.Milliseconds > 0 ? deltaTime.Milliseconds : 1;

            // calculate fps
            currentFps = 1000 / mill;

            // clear the canvas
            dc.Clear(Color.White);

            // if the game is runnig
            if (IsRunning)
            {
                es.Update(currentFps); // updat the enemyspawner
                Update(); // Update all gameobjects
                UpdateAnimation(); // update all animations
                Draw(); // draw all objects
            }

            //define end time
            endTime = DateTime.Now;

        }

        /// <summary>
        /// draw metgod
        /// </summary>
        public void Draw()
        {
            //Call the draw method on all objects in the list
            foreach (GameObject go in Objects)
            {
                go.Draw(dc);
            }

            // drawing the HUD
            // create the pen and font
            Pen p = new Pen(Color.Black, 5);
            Font f = new Font("Arial", 16);
            // find the player in the Objects list
            Player pl = (Player)Objects.Find(x => x is Player);
            //calculate the percentage of player HP
            double percentage = (300f / 100f) * pl.Health;
            // fill a rectangle depending on the health percentage
            dc.FillRectangle(Brushes.Red, new Rectangle(10, 10, Convert.ToInt32(percentage), 50));
            // draw edge rectangle
            dc.DrawRectangle(p, new Rectangle(10, 10, 300, 50));
            //same for mana
            percentage = (300f / 100f) * pl.Mana;
            dc.FillRectangle(Brushes.Blue, new Rectangle(display.Right - 310, 10, Convert.ToInt32(percentage), 50));
            dc.DrawRectangle(p, new Rectangle(display.Right - 310, 10, 300, 50));
            //change font size
            f = new Font("Arial", 30);
            // draw score
            dc.DrawString(Convert.ToString(pl.Score), f, Brushes.Black, display.Width / 2 - 50, 10);

            backBuffer.Render();
        }

        /// <summary>
        /// updates all objects
        /// </summary>
        public void Update()
        {
            //Call the draw method on all objects in the list
            foreach (GameObject go in Objects)
            {
                go.Update(currentFps);

                if (go is Player)
                {
                    //check if the player health is below 0
                    if ((go as Player).Health <= 0)
                    {
                        // change IsRunning to false
                        IsRunning = false;
                    }
                }
            }
        }
         /// <summary>
         /// Updates alle animations
         /// </summary>
        public void UpdateAnimation()
        {
            //Call the draw method on all objects in the list
            foreach (GameObject go in Objects)
            {
                go.UpdateAnimation(currentFps);
            }
        }

        /// <summary>
        /// reset all the lists 
        /// </summary>
        public static void ResetStatics()
        {
            Objects.Clear();
            ObjectsToRemove.Clear();
            ObjectsToAdd.Clear();
        }

        /// <summary>
        /// dispose the backbuffer and clear all lists
        /// </summary>
        public void Dispose()
        {
            backBuffer.Dispose();
            ResetStatics();
        }
    }
}