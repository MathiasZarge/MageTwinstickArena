using System;
using System.Drawing;
using System.Windows.Forms;

namespace MageTwinstick
{
    public partial class Game : Form
    {

        // Fields
        private Graphics dc;
        private GameWorld gameWorld;

        public Game()
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

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Mouse.X = e.X;
            Mouse.Y = e.Y;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (GameObject go in GameWorld.Objects)
            {
                if (go is Player)
                {
                    Player p = go as Player;
                    p.Attack();
                }
            }
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}