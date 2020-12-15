using System;
namespace diceGameNew.src.diceGame
{
    public class dice
    {
        private static int numberOfSides = 6;

        public int roll()
        {

            int result;
            Random randomNumberGenerator = new Random();
            result = randomNumberGenerator.Next(numberOfSides) + 1;
            return result;
        }


    }
}
