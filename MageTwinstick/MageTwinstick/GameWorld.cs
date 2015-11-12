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
        public static List<GameObject> Objects { get; set; }
        public static List<GameObject> ObjectsToRemove { get; set; }
        public static List<GameObject> ObjectsToAdd { get; set; }

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
            
        }

        public void GameLoop()
        {
            Update(); // Update all gameobjects
            UpdateAnimation(); // update all animations
            Draw(); // draw all objects
        }

        public void Draw()
        {
            
        }

        public void Update()
        {
            
        }

        public void UpdateAnimation()
        {
            
        }
    }
}