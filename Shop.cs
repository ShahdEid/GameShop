using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop
{
    public class Shop
    {
        private string shopName;
        //the shop has a list of the games available for sale

        private List<Game> gamesForSale;


        private int currentlyViewedGame = 0;

    

        //Constructor
        public Shop (string shopName)
        {
          gamesForSale = new List<Game>();
        }



        //Get method for currentlyViewedGame
        public int getcurrentlyViewedGame
        {
            get { return currentlyViewedGame; }
        }

        //Get method to return number of games available 
        public int NumberOfGames
        {
            get { return gamesForSale.Count; }
        }

        //Method to return the game's description
        public string DescribeCurrentGame()
        {
            string description;
            //if there are games available, discription will be displayed
            if (gamesForSale.Count > 0)
            {
                description = gamesForSale[currentlyViewedGame].Description();
            }

            else
            {
                description = "No Games available";
            }
            return description;


        }


        //Method to add game to the list 
        public void AddGame(Game game)

        {
            gamesForSale.Add(game);
        }

        //Method to remove game @ index position of the list
        public void RemoveGameAt(int index)
        {
            if (index < gamesForSale.Count)
            {
                gamesForSale.RemoveAt(index);

                //currentlyViewedGame is either zero or pointing at a game that is already there
                LegalisecurrentlyViewedGame();
            }
        }

        //currentlyViewedGame indexes a game that exists 
        private void LegalisecurrentlyViewedGame()
        {
            if (currentlyViewedGame > (gamesForSale.Count - 1))
            {
                currentlyViewedGame = gamesForSale.Count - 1;

                //-1 if it is 0

                if (currentlyViewedGame < 0)
                {
                    currentlyViewedGame = 0;
                }
            }
        }
        //Method to check any previous games in the list
        public bool IsPreviousGame()
        {
            if (currentlyViewedGame > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

            // return (currentlyViewedGame > 0);
        }

        public bool IsNextGame()
        {
            if (currentlyViewedGame < gamesForSale.Count - 1)
            { 
                return true;
            }
            else
            {
                return false;
            }

        }

        //method to move to the next game
        public void StepToNextGame()
        {
            if (IsNextGame())
            {
                currentlyViewedGame++;
            }
        }

        //method to move to the previous game
        public void StepToPreviousGame()
        {
            if (IsPreviousGame())
            {
                currentlyViewedGame--;
            }
        }

    }
}
