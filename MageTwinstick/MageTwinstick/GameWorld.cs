using System;
using System.Drawing;
using IrrKlang;

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
        private static ISoundEngine soundEngine;
    }
}