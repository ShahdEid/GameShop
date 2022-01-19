using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop
{
    public class XboxGame : Game 
    {
        //Constructor
        public XboxGame(string console, string gameTitle, string gameDev, Condition condition, decimal originalPrice, DateTime releaseDate) : base(console, gameTitle, gameDev, condition, originalPrice, releaseDate)
        {

        }
        //implementing the abstract method in Game class
        public override decimal OriginalPrice()
        {
            return originalPrice;
        }

        //this calculation is overriden in the derived classes
        public override decimal CalculateApproximateValue()
        {
            decimal value = 0;
            //modify games value depending on condition
            if (condition == Condition.mint)
            {
                value = originalPrice * 0.9m; //90% of the original cost
            }

            else if (condition == Condition.good)
            {
                value = originalPrice * 0.8m; //80% of the original cost
            }

            else if (condition == Condition.fair)
            {
                value = originalPrice * 0.7m; //70% of the original cost
            }

            else if (condition == Condition.poor)
            {
                value = originalPrice * 0.5m; //50% of the original cost
            }

            int age = CalculateApproximateAgeInYears();
            //lose a further 10% for each year that has passed since the game's release
            decimal alternativeValue = value * (decimal)Math.Pow(0.9, age);

            value = value * (decimal)Math.Pow(0.9, age);

            value = Decimal.Round(value, 0);//round to the nearest pound

            return value;
        }
    }
}
