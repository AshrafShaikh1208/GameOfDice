using System;

namespace diceGameNew
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                diceGameNew.src.diceGame.worker.DoWork();
            }
            catch(Exception ex)
            { Console.WriteLine("Error " + ex.ToString()); }
        }
    }
}
