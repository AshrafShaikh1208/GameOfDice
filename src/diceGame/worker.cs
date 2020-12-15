using System;
namespace diceGameNew.src.diceGame
{
    public class worker
    {
        public worker()
        {
        }

        public static void DoWork()
        {
            game game = new game();
            Console.Clear();

            while (true)
            {
                game.displayGameMenue();
                string optionSelected = Console.ReadLine();

                int option;
                bool parseSucess = checkInputInteger(optionSelected, out option);

                // Check if the input is correct
                while (option > 3 || option <= 0)
                {

                    Console.WriteLine("Option entered invalid, please enter a number from 1 to 3: ");
                    game.displayGameMenue();
                    optionSelected = Console.ReadLine();
                    parseSucess = checkInputInteger(optionSelected, out option);
                }

                if (option == 1 || option == 2)
                {
                    game.selectGameOption(option);
                }

                if (option == 3)
                {
                    Console.WriteLine("Exiting game");
                    break;
                }
              

            }
        }

        // Check integer input
        public static Boolean checkInputInteger(string input, out int option)
        {
            var vinput = input;
            bool parseSucess = int.TryParse(vinput, out option);
            game game = new game();

            while (!parseSucess)
            {
                Console.WriteLine("Option entered invalid, please enter a number from more then 1 ");
                vinput = Console.ReadLine();
                parseSucess = int.TryParse(vinput, out option);
            }

            return true;
        }

        // Check string input
        public static Boolean checkInputString(string input, out string option)
        {
            var vinput = input;
            int intOption;
            bool parseSucess = int.TryParse(vinput, out intOption);
            game game = new game();

            while (parseSucess)
            {
                Console.WriteLine("press ‘r’ to roll the dice");
                vinput = Console.ReadLine();
                parseSucess = int.TryParse(vinput, out intOption);
                if (!parseSucess && vinput != "r")
                {
                    parseSucess = true;
                }

            }

            option = input;
            return true;
        }
    }
}
