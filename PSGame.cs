using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop
{
    public class PSGame : Game 
    {
        //Constructor
        public PSGame(string console, string gameTitle, string gameDev, Condition condition, decimal originalPrice, DateTime releaseDate) : base (console, gameTitle, gameDev, condition, originalPrice, releaseDate)
        {
            //No other attributres in the PSGame class
        }


        //implementing the abstract method in Game class
        public override decimal OriginalPrice()
        {
            return  originalPrice;
        }
           


        //this calculation is overriden in the derived classes
        public override decimal CalculateApproximateValue()
        {
            decimal value = 0;
            //modify games value depending on condition
            if (condition == Condition.mint)
            {
                value = originalPrice * 0.8m; //80% of the original cost
            }

            else if (condition == Condition.good)
            {
                value = originalPrice * 0.7m; //70% of the original cost
            }

            else if (condition == Condition.fair)
            {
                value = originalPrice * 0.5m; //50% of the original cost
            }

            else if (condition == Condition.poor)
            {
                value = originalPrice * 0.4m; //40% of the original cost
            }

            int age = CalculateApproximateAgeInYears();
            //lose a further 20% for each year that has passed since the game's release
            for (int i = 0; i < age; i++)
            {
                // lose 20% each year
                value = value * 0.8m;
            }
            value = Decimal.Round(value, 0);  //Round to the nearest pound


            value = value - (value % 100); //the shop rouns this down to the nearest 100£

            //adds 99£
            value = value + 99;
            return value;                                                                                                     
        }

    }
}
