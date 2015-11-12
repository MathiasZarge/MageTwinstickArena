using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MageTwinstick
{
    public partial class Form1 : Form
    {

        // Fields
        private Graphics dc;
        private GameWorld gameWorld;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //run gameloop every tick
            gameWorld.GameLoop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Initialize grapthics and gameworld
            dc = CreateGraphics();
            gameWorld = new GameWorld(dc, this.DisplayRectangle);
            gameWorld.SetupWorld();
        }
    }
}
