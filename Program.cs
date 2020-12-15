using System;

namespace diceGameNew
{
    class Program
    {
        // Main function
        static void Main()
        {
            try
            { diceGameNew.src.diceGame.Worker.DoWork(); }
            catch(Exception ex)
            { Console.WriteLine("Error " + ex.ToString()); }
        }
    }
}
