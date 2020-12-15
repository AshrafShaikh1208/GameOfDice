using System;
namespace diceGameNew.src.diceGame
{
    public class Worker
    {
        public Worker()
        {
        }

        public static void DoWork()
        {
            try
            {
                Game game = new Game();
                Console.Clear();

                while (true)
                {
                    game.DisplayGameMenue();
                    string optionSelected = Console.ReadLine();

                    int option;
                    bool parseSucess = CheckInputInteger(optionSelected, out option);

                    // Check if the input is correct
                    while (option > 3 || option <= 0)
                    {

                        Console.WriteLine("Option entered invalid, please enter a number from 1 to 3: ");
                        game.DisplayGameMenue();
                        optionSelected = Console.ReadLine();
                        parseSucess = CheckInputInteger(optionSelected, out option);
                    }

                    if (option == 1 || option == 2)
                    {
                        game.SelectGameOption(option);
                    }

                    if (option == 3)
                    {
                        Console.WriteLine("Exiting game");
                        break;
                    }
                }
            }
            catch (Exception ex)
            { Console.WriteLine("Error!!! " + ex.ToString()); }
        }

        // Check integer input
        public static Boolean CheckInputInteger(string input, out int option)
        {
            option = 0;
            try
            {
                var vinput = input;
                bool parseSucess = int.TryParse(vinput, out option);
                Game game = new Game();

                while (!parseSucess)
                {
                    Console.WriteLine("Option entered invalid, please enter valid input.");
                    vinput = Console.ReadLine();
                    parseSucess = int.TryParse(vinput, out option);
                }
            }
            catch (Exception ex)
            { Console.WriteLine("Error!!! " + ex.ToString()); }

            return true;
        }

        // Check string input
        public static Boolean CheckInputString(string input, out string option)
        {
            option = "";
            try
            {
                var vinput = input;
                int intOption;
                bool parseSucess = int.TryParse(vinput, out intOption);
                Game game = new Game();

                while (parseSucess)
                {
                    Console.WriteLine("Option entered invalid, press ‘r’ to roll the dice");
                    vinput = Console.ReadLine();
                    parseSucess = int.TryParse(vinput, out intOption);
                    if (!parseSucess && (vinput != "r" || vinput == ""))
                    {
                        parseSucess = true;
                    }
                }



                option = input;
                return true;
            }
            catch (Exception ex)
            { Console.WriteLine("Error!!! " + ex.ToString()); }
            return true;
        }
    }
}
