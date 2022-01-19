using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShop
{
    public abstract class Game : IComparable
    {
        // we rate game's condition
        public enum Condition
        {
            poor,
            fair,
            good,
            mint
        };


        protected string console;
        protected string gameTitle;
        protected string gameDev;
        protected Condition condition;
        protected decimal originalPrice;
        protected DateTime releaseDate;

        //Constructor
        public Game(string console, string gameTitle, string gameDev, Condition condition, decimal originalPrice, DateTime releaseDate)
        {
            this.console = console;
            this.gameTitle = gameTitle;
            this.gameDev = gameDev;
            this.condition = condition;
            this.originalPrice = originalPrice;
            this.releaseDate = releaseDate;


        }

       public abstract decimal OriginalPrice(); //implement in PSGame and Xbox Classes

      public  DateTime ReleaseDate()
        {
           return DateTime.Now;
       }

        public int CalculateApproximateAgeInYears()
        {
            DateTime now = DateTime.Now;
            TimeSpan ageAsTimeSpan = now.Subtract(releaseDate);
            int ageInYears = ageAsTimeSpan.Days / 365; //Doesn't take into account leap years - just approximate
            return ageInYears;

        }

        //get method 
        public Condition Getcondition

        {
            get { return condition; }
            
        }


        //abstract method has to be implmented in the derived class
        public abstract decimal CalculateApproximateValue();


        public virtual string Description()
        {
            //get a string describing the games condition from the names in the Condition enum
            string conditionName = Enum.GetName(typeof(Condition), condition); // enum name here

            //Builds a string for the description
            string description = string.Format("Console: {0}{1}GameTitle: {2}{3}GameDev: {4}{5}Condition: {6}{7}Current Value: {8:c}",
                console,
                Environment.NewLine,
                gameTitle,
                Environment.NewLine,
                gameDev,
                Environment.NewLine,
                conditionName,
                Environment.NewLine,
                
                CalculateApproximateValue()

                );
            return description + "\n Original Price: " + originalPrice;
        }

        //Implement IComparable CompareTo method 
        int IComparable.CompareTo(object obj)
        {
            //Icomparable returns +1, 0 or -1
            Game otherGame = (Game)obj;
            decimal differenceInPrice = this.CalculateApproximateValue() - otherGame.CalculateApproximateValue();
            //return +1, 0 or -1
            return Math.Sign(differenceInPrice);
        }




    }
}
