using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Testoasa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graphics g;
        Pen p = new Pen(Color.Black, 2);
        Brush b = new SolidBrush(Color.Black);
        Font f;
        int posx=0;
        int posy = 0;
        int prevposx = 0;
        int prevposy = 0;
        
        bool coborareCreion = false;
        bool ismuteed = true;

        private void Form1_Load(object sender, EventArgs e)
        {
            Width = 1024;
            Height = 768;
            g = CreateGraphics();
            f = this.Font;
            posx = Width / 2;
            posy = Height / 2;

            
            
        }

        void print_locations()
        {
            g.FillRectangle(new SolidBrush(BackColor), 500, 0, 250, 50);
            string l = "posx= " + posx.ToString() + " posy= " + posy.ToString();
            l += " \r\n " + "prevposx= " + prevposx.ToString() + " prevposy= " + prevposy.ToString();
            g.DrawString(l, f, b,  500, 0 );
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            prevposx = posx;
            prevposy = posy;

            if (e.KeyCode == Keys.C)
            {
                coborareCreion = true;
            }
            else if (e.KeyCode == Keys.X)
            {
                coborareCreion = false;
            }
            else if (e.KeyCode == Keys.M)
            {
                ismuteed = true;
            }
            else if (e.KeyCode == Keys.P)
            {
                ismuteed = false;
            }
            else if (e.KeyCode == Keys.A)
            {
                if (coborareCreion == true)
                {
                    g.DrawLine(p, posx -= 1, posy, prevposx, prevposy);
                }
                else
                {
                    posx -= 1;
                }
            }

            else if (e.KeyCode == Keys.D)
            {

                if (coborareCreion == true)
                {
                    g.DrawLine(p, posx += 1, posy, prevposx, prevposy);
                }
                else
                {
                    posx += 1;
                }
            }
            else if (e.KeyCode == Keys.W)
            {
                if (coborareCreion == true)
                {
                    g.DrawLine(p, posx, posy -= 1, prevposx, prevposy);
                }
                else
                {
                    posy -= 1;
                }
            }
            else if (e.KeyCode == Keys.S)
            {
                if (coborareCreion == true)
                {
                    g.DrawLine(p, posx, posy += 1, prevposx, prevposy);
                }
                else
                {
                    posy += 1;
                }

            }
            play_music();
            print_locations();

        }
        void play_music()
        {
            try
            {
                if (ismuteed == false)
                {
                    System.Console.Beep(posx, posy / 2);
                }

            }
            catch { }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            prevposx = posx;
            prevposy = posy;
            posx = e.X;
            posy = e.Y;
            if (coborareCreion == true)
            {
                g.DrawLine(p, posx, posy , prevposx, prevposy);
            }
            print_locations();
            play_music();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            print_locations();
            string s = "  Apasati tastele A stanga D dreapta, S jos, W sus";
            s += " \r\n C creion X mutare sau utilizati Mouse-ul pentru a desena liniile";
            s += " \r\n M pentru mute sunet si P pentru play sunet";
            g.DrawString(s, f, b, 0, 0);
        }


    }
}
