using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameShop
{
    public partial class Form1 : Form

    {
        //shop that has a list of games available and a current index for each
       
        Shop shop;
        

        //private string shopName; //Check 
        public Form1()
        {
            InitializeComponent();
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            //timer
            timer1.Interval = 1000;

            //start the timer
            timer1.Start();

            //Now for the games
            shop = new Shop("Your Shop Name"); //Check parameter

            //Games that will be displayed in the list

            PSGame psgame = new PSGame("Playstation 4", "Spiderman", "Marvel", Game.Condition.fair, 46, new DateTime(2021, 8, 3));
            PSGame psgame1 = new PSGame("Playstation 5", "GTA", "Gold Coast Development", Game.Condition.poor, 30, new DateTime(2017, 3, 3));
            PSGame psgame2 = new PSGame("Playstation 4", "LEGO Marvel Collection", "Interactive Entertainment", Game.Condition.good, 75, new DateTime(2020, 3, 10));
            PSGame psgame3 = new PSGame("Playstation 4", "Horizon Forbidden", "Guerrilla Games", Game.Condition.mint, 150, new DateTime(2022, 1, 10));
            PSGame psgame4 = new PSGame("Playstation 5", "Call of Duty", "Sledgehammer Games", Game.Condition.good, 45, new DateTime(2021, 9, 9));
            PSGame psgame5 = new PSGame("Playstation 4", "God of War", "Jetpack Interactive", Game.Condition.fair, 25, new DateTime(2018, 4, 21));
            XboxGame xboxgame1 = new XboxGame("Xbox 360","The sims 4","Maxis", Game.Condition.poor, 13, new DateTime(2017, 1, 18));
            XboxGame xboxgame2 = new XboxGame("Xbox 360", "Truck Driver", "Triangles Studios", Game.Condition.mint , 110, new DateTime(2020, 5, 18));
            XboxGame xboxgame3 = new XboxGame("Xbox 1 S", "Just Dance", "Gold Coast Nintendo", Game.Condition.fair, 62, new DateTime(2021, 4, 10));
            XboxGame xboxgame4 = new XboxGame("Xbox 1", "Minecraft Dungeons", "Mojang Studios", Game.Condition.poor, 15, new DateTime(2018, 6, 24));
            XboxGame xboxgame5 = new XboxGame("Xbox 1", "GTA", "Gold Coast Development", Game.Condition.good, 15, new DateTime(2019, 8, 1));


            shop.AddGame(psgame); 
            shop.AddGame(psgame1);
            shop.AddGame(psgame2);
            shop.AddGame(psgame3);
            shop.AddGame(psgame4);
            shop.AddGame(psgame5);
            shop.AddGame(xboxgame1); 
            shop.AddGame(xboxgame2); 
            shop.AddGame(xboxgame3);
            shop.AddGame(xboxgame4);
            shop.AddGame(xboxgame5);


            DisplayGame(); 
        }


        //Method to display currently viewed games in the shop through the form
        private void DisplayGame()
        {
            labelGame.Text = string.Format("Viewing {0} of {1}" , shop.getcurrentlyViewedGame + 1, shop.NumberOfGames);
            textBoxGame.Text = shop.DescribeCurrentGame();
        }


        //Previous button Navigation 
        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            shop.StepToPreviousGame();
            DisplayGame();
        }

        //Next button Navigation
        private void buttonNext_Click(object sender, EventArgs e)
        {
            shop.StepToNextGame();
            DisplayGame();
        }

        private void textBoxGame_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Variables to store hours, minutes, and secs
            int hour;
            int minute;
            int second;

            DateTime timeNow = DateTime.Now;
            hour = timeNow.Hour;
            minute = timeNow.Minute;
            second = timeNow.Second;
            //string variable to hold time
            string time;
            if (checkBox24Hour.Checked)
            {
                time = String.Format("{0:00}:{1:00}:{2:00}", hour, minute, second);

            }
            //AM or PM
            else
            {
                string timeOfDay = "AM";

                //start pm time
                if (hour >= 12)
                {
                    timeOfDay = "PM";
                    // adjust the hour number
                    hour = hour - 12;
                }

                //time with the am and pm at the end
                time = String.Format("{0:00}:{1:00}:{2:00} {3}", hour, minute, second, timeOfDay);

            }

            //store time in the text box
            textBoxTime.Text = time;
        }

        private void textBoxTime_TextChanged(object sender, EventArgs e)
        {

        }

      
    }
}
