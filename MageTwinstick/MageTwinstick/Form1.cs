﻿using System;
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
        private bool isRunning = true;
        private bool paused = false;

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
            foreach (GameObject go in GameWorld.Objects)
            {
                if (go is Player)
                {
                    Player p = go as Player;
                    p.Attack();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape && !paused)
            {
                isRunning = false;
                paused = true;
            }
            else if (e.KeyCode == Keys.Escape && paused)
            {
                isRunning = true;
                paused = false;
            }
        }
    }
}