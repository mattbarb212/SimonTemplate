using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Drawing.Drawing2D;
using System.Threading;

namespace SimonSays
{
    public partial class GameScreen : UserControl
    {
        //TODO: create guess variable to track what part of the pattern the user is at
        int guess;
        Random randGen = new Random();
        SoundPlayer mistakeSound = new SoundPlayer(Properties.Resources.mistake);
        SoundPlayer greenSound = new SoundPlayer(Properties.Resources.green);
        SoundPlayer redSound = new SoundPlayer(Properties.Resources.red);
        SoundPlayer yellowSound = new SoundPlayer(Properties.Resources.yellow);
        SoundPlayer blueSound = new SoundPlayer(Properties.Resources.blue);

        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            //TODO: clear the pattern list from form1, refresh, pause for a bit, and run ComputerTurn()
            Form1.colours.Clear();
            Refresh();
            Thread.Sleep(500);
            ComputerTurn();
        }

        private void ComputerTurn()
        {
            //TODO: get rand num between 0 and 4 (0, 1, 2, 3) and add to pattern list
            
            Form1.colours.Add(randGen.Next(0,4));

            //TODO: create a for loop that shows each value in the pattern by lighting up approriate button
            for (int i = 0; i < Form1.colours.Count(); i++)
            {
                if (Form1.colours[i] == 0)
                {
                    greenButton.BackColor = Color.LimeGreen;
                    Refresh();
                    Thread.Sleep(200);
                    greenButton.BackColor = Color.ForestGreen;
                    Refresh();
                    Thread.Sleep(200);
                }
                else if (Form1.colours[i] == 1)
                {
                    redButton.BackColor = Color.Red;
                    Refresh();
                    Thread.Sleep(200);
                    redButton.BackColor = Color.DarkRed;
                    Refresh();
                    Thread.Sleep(200);
                }
                else if (Form1.colours[i] == 2)
                {
                    yellowButton.BackColor = Color.Gold;
                    Refresh();
                    Thread.Sleep(200);
                    yellowButton.BackColor = Color.Goldenrod;
                    Refresh();
                    Thread.Sleep(200);
                }
                else if (Form1.colours[i] == 3)
                {
                    blueButton.BackColor = Color.MediumBlue;
                    Refresh();
                    Thread.Sleep(200);
                    blueButton.BackColor = Color.DarkBlue;
                    Refresh();
                    Thread.Sleep(200);
                }
            }

            //TODO: get guess index value back to 0
            guess = 0;
        }

        public void GameOver()
        {
            //TODO: Play a game over sound
            mistakeSound.Play();
            Thread.Sleep(1000);

            //TODO: close this screen and open the GameOverScreen
            Form f = this.FindForm();
            f.Controls.Remove(this);

            GameOverScreen gOS = new GameOverScreen();

            f.Controls.Add(gOS);

            gOS.Location = new Point((this.Width - gOS.Width) / 2, (this.Height - gOS.Height) / 2);
        }

        //TODO: create one of these event methods for each button
        private void greenButton_Click(object sender, EventArgs e)
        {
            if (Form1.colours[guess] == 0)
            {
                greenButton.BackColor = Color.LimeGreen;
                greenSound.Play();
                Refresh();
                Thread.Sleep(100);
                greenButton.BackColor = Color.Green;
                Refresh();
                Thread.Sleep(100);
                guess++;
            }
            else
            {
                GameOver(); 
            }
            if (Form1.colours.Count == guess)
            {
                ComputerTurn();
            }
        }
        private void redButton_Click(object sender, EventArgs e)
        { 
            if (Form1.colours[guess] == 1)
            {
                redButton.BackColor = Color.Red;
                redSound.Play();
                Thread.Sleep(100);
                redButton.BackColor = Color.DarkRed;
                Refresh();
                Thread.Sleep(100);
                guess++;
            }
            else
            {
                GameOver();
            }
            if (Form1.colours.Count == guess)
            {
                ComputerTurn();
            }
        }
        private void yellowButton_Click(object sender, EventArgs e)
        {
            if (Form1.colours[guess] == 2)
            {
                yellowButton.BackColor = Color.Gold;
                yellowSound.Play();
                Thread.Sleep(100);
                yellowButton.BackColor = Color.Goldenrod;
                Refresh();
                Thread.Sleep(100);
                guess++;
            }
            else
            {
                GameOver();
            }
            if (Form1.colours.Count == guess)
            {
                ComputerTurn();
            }
        }
        private void blueButton_Click(object sender, EventArgs e)
        {
            if (Form1.colours[guess] == 3)
            {
                blueButton.BackColor = Color.MediumBlue;
                blueSound.Play();
                Thread.Sleep(100);
                blueButton.BackColor = Color.DarkBlue;
                Refresh();
                Thread.Sleep(100);
                guess++;
            }
            else
            {
                GameOver(); 
            }
            if (Form1.colours.Count == guess)
            {
                ComputerTurn();
            }
        }
    }
}
