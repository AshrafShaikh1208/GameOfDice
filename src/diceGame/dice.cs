using System;
namespace diceGameNew.src.diceGame
{
    public class dice
    {
        private static int numberOfSides = 6;

        public int roll()
        {
            int result = 0;
            try
            {
                Random randomNumberGenerator = new Random();
                result = randomNumberGenerator.Next(numberOfSides) + 1;
            }
            catch (Exception ex)
            { Console.WriteLine("Error !!!" + ex.ToString()); }

            return result;
        }


    }
}
