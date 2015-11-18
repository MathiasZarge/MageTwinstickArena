using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MageTwinstick
{
    public partial class Form1 : Form
    {

        // Fields
        private Graphics dc;
        private GameWorld gameWorld;
        private bool isRunning = false;
        private bool paused = false;
        private bool menuDrawn = false;
        Image playGame = Image.FromFile(@"Images\PlayGame.png");
        Image exitGame = Image.FromFile(@"Images\ExitGame.png");

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isRunning)
            {
                //run gameloop every tick
                gameWorld.GameLoop();

                if (gameWorld.IsRunning == false)
                {
                    isRunning = false;
                    dc.Clear(Color.White);
                    gameWorld.Dispose();
                    gameWorld = new GameWorld(dc, DisplayRectangle);
                    gameWorld.SetupWorld();
                    menuDrawn = false;
                }
            }
            else if (!paused && !isRunning && !menuDrawn)
            {
                dc.Clear(Color.White);
                dc.DrawImage(Image.FromFile(@"Images\MainMenu.jpg"), 0, 0, DisplayRectangle.Width, DisplayRectangle.Height);
                dc.DrawString("███████╗██╗   ██╗██████╗ ███████╗██████╗     ██████╗ ██╗   ██╗██████╗ ███████╗██████╗     ███╗   ███╗ █████╗  ██████╗ ███████╗", new Font("Consolas", 10), Brushes.Black, 150, 50);
                dc.DrawString("██╔════╝██║   ██║██╔══██╗██╔════╝██╔══██╗    ██╔══██╗██║   ██║██╔══██╗██╔════╝██╔══██╗    ████╗ ████║██╔══██╗██╔════╝ ██╔════╝", new Font("Consolas", 10), Brushes.Black, 150, 60);
                dc.DrawString("███████╗██║   ██║██████╔╝█████╗  ██████╔╝    ██║  ██║██║   ██║██████╔╝█████╗  ██████╔╝    ██╔████╔██║███████║██║  ███╗█████╗  ", new Font("Consolas", 10), Brushes.Black, 150, 70);
                dc.DrawString("╚════██║██║   ██║██╔═══╝ ██╔══╝  ██╔══██╗    ██║  ██║██║   ██║██╔═══╝ ██╔══╝  ██╔══██╗    ██║╚██╔╝██║██╔══██║██║   ██║██╔══╝  ", new Font("Consolas", 10), Brushes.Black, 150, 80);
                dc.DrawString("███████║╚██████╔╝██║     ███████╗██║  ██║    ██████╔╝╚██████╔╝██║     ███████╗██║  ██║    ██║ ╚═╝ ██║██║  ██║╚██████╔╝███████╗", new Font("Consolas", 10), Brushes.Black, 150, 90);
                dc.DrawString("╚══════╝ ╚═════╝ ╚═╝     ╚══════╝╚═╝  ╚═╝    ╚═════╝  ╚═════╝ ╚═╝     ╚══════╝╚═╝  ╚═╝    ╚═╝     ╚═╝╚═╝  ╚═╝ ╚═════╝ ╚══════╝", new Font("Consolas", 10), Brushes.Black, 150, 100);

                dc.DrawImage(playGame, DisplayRectangle.Width/2 - playGame.Width/2, DisplayRectangle.Height/2);
                dc.DrawImage(exitGame, DisplayRectangle.Width / 2 - exitGame.Width / 2, DisplayRectangle.Height / 2 + 200);

                menuDrawn = true;
            }
            else if (paused && !isRunning)
            {
                
            }
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
            if (isRunning && e.Button == MouseButtons.Left)
            {
                foreach (GameObject go in GameWorld.Objects)
                {
                    if (go is Player)
                    {
                        (go as Player).Attack();
                    }
                }
            }
            else if (!isRunning && !paused)
            {
                if (Mouse.X > DisplayRectangle.Width / 2 - playGame.Width / 2 && Mouse.X < DisplayRectangle.Width / 2 + playGame.Width / 2 && Mouse.Y > DisplayRectangle.Height / 2 && Mouse.Y < DisplayRectangle.Height / 2 + playGame.Height)
                {
                    isRunning = true;
                }
                if (Mouse.X > DisplayRectangle.Width / 2 - exitGame.Width / 2 && Mouse.X < DisplayRectangle.Width / 2 + exitGame.Width / 2 && Mouse.Y > DisplayRectangle.Height / 2 + 200 && Mouse.Y < (DisplayRectangle.Height / 2 + 200) + exitGame.Height)
                {
                    Environment.Exit(0);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape && !paused && isRunning)
            {
                isRunning = false;
                paused = true;
            }
            else if (e.KeyCode == Keys.Escape && paused && !isRunning)
            {
                isRunning = true;
                paused = false;
            }
        }
    }
}