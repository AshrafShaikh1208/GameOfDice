using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace diceGameNew.src.diceGame
{
    public class Game : IGameInterface
    {
        private Dice dice;
        private int scoreToWin;
        private List<string> Result = new List<string>();
        private List<Player> objPlayers = new List<Player>();
        private Dictionary<string, int> checkForFoul = new Dictionary<string, int>();
        private DataTable products;
        private DataTable finalTable;
        private static int index;

        public Game()
        {
            Console.Clear();
        }

        // Function to display hame menue
        public void DisplayGameMenue() 
        {
            
            Console.WriteLine("");
            Console.WriteLine("(1) Start a new game");
            Console.WriteLine("(2) Display game rules");
            Console.WriteLine("(3) Exit game");
            Console.WriteLine("Choose an option: ");
        }

        // Function to display game instruction
        public void DisplayGameInstruction()
        {
            Console.WriteLine("");
            Console.WriteLine("All players roll a dice once per turn in round-robin fashion");
            Console.WriteLine("If the player gets another chance because they rolled a ‘6’");
            Console.WriteLine("The player miss the next chance if he rolled ‘1’ twice consecutively");

        }

        // Function to select the game option
        public void SelectGameOption(int optionSelected)
        {
            switch (optionSelected)
            {
                case 1:
                    this.StartNewGame();
                    break;
                case 2:
                    this.DisplayGameInstruction();
                    break;
                default:
                    break;
            }
        }

        // Function to start new game
        public void StartNewGame()
        {
            try
            {
                int numberOfPlayers; dice = new Dice(); checkForFoul.Clear(); objPlayers.Clear();

                finalTable = new DataTable();
                finalTable.TableName = "Result";
                finalTable.Columns.Add("Rank", typeof(int)).AllowDBNull = false;
                finalTable.Columns.Add("Name", typeof(string));
                finalTable.Columns.Add("Score", typeof(int)).AllowDBNull = false;

                Console.WriteLine("Please enter number of players");
                string input = Console.ReadLine();
                bool parseSucess = Worker.CheckInputInteger(input, out numberOfPlayers);

                Console.WriteLine("Please enter the maximum score required to win");

                input = Console.ReadLine();
                parseSucess = Worker.CheckInputInteger(input, out scoreToWin);

                // Generate random numer to decide who plays first
                Random randomNumberGenerator = new Random();
                int result = randomNumberGenerator.Next(numberOfPlayers) + 1;

                for (int i = 1; i <= numberOfPlayers; i++)
                {
                    objPlayers.Add(new Player("Player-" + i.ToString()));

                    checkForFoul.Add("Player-" + i.ToString(), 0);
                }

                while (true)
                {
                    string strPlayer = "Player-" + result.ToString();
                    index = objPlayers.IndexOf(objPlayers.Where(p => p.GetName() == strPlayer).FirstOrDefault());
                    bool allowRoll = true;

                    // check for skipping the roll if the user has rolled 1 consecutively times
                    if (checkForFoul.ContainsKey(objPlayers[index].GetName()) && checkForFoul[objPlayers[index].GetName()] == 2)
                    {
                        Console.WriteLine(objPlayers[index].GetName() + " you missed this chance as you rolled 1 twice consicatively");
                        checkForFoul[strPlayer] = 0;
                        allowRoll = false;
                    }

                    // check for skipping the roll of the user who has already won
                    if (objPlayers[index].GetTotalScore() == scoreToWin)
                    {
                        if (!Result.Contains(objPlayers[index].GetName().ToString()))
                            Result.Add(objPlayers[index].GetName());

                        if (Result.Count == objPlayers.Count)
                        {
                            Console.WriteLine("*** Game Ends ***");
                            break;
                        }

                        allowRoll = false;
                    }

                    // check to roll the dice
                    if (allowRoll)
                    {
                        Console.WriteLine(strPlayer + " its your turn (press ‘r’ to roll the dice)");
                        input = Console.ReadLine();
                        Worker.CheckInputString(input, out input);

                        int rollScore;
                        PlayOneRound(objPlayers[index], out rollScore);
                        CheckIfAnyoneHasWon(index);
                        WhoIsLeading();

                        // Check to give use one more roll if he scores 6
                        while (rollScore == 6)
                        {
                            Console.WriteLine(objPlayers[index].GetName() + " you won one more chance to roll as you scored 6 (press ‘r’ to roll the dice again)");
                            input = Console.ReadLine();
                            Worker.CheckInputString(input, out input);
                            PlayOneRound(objPlayers[index], out rollScore);
                            CheckIfAnyoneHasWon(index);
                            WhoIsLeading();
                        }

                        // Check if user has rolled 1 teice consicatively
                        if (rollScore == 1)
                        {
                            int intFoulCheck = checkForFoul[strPlayer];
                            checkForFoul[strPlayer] = intFoulCheck + 1;

                            if (checkForFoul[strPlayer] == 2)
                            {
                                Console.WriteLine(objPlayers[index].GetName() + " rolled 1 twice consicatively as misses the next roll");
                            }
                        }
                        else
                        {
                            checkForFoul[strPlayer] = 0;
                        }
                    }

                    if (result == numberOfPlayers)
                        result = 1;
                    else
                        result++;
                }
            }
            catch (Exception ex)
            { Console.WriteLine("Error!!! " + ex.ToString()); }
        }

        // Function to roll the dice
        public void PlayOneRound(Player player, out int roll)
        {
            int diceRoll = dice.Roll();
            roll = diceRoll;
            try
            {
                int totalScore = player.GetTotalScore();

                // Check if the total is greater the score to win
                if ((totalScore + diceRoll) > scoreToWin)
                {
                    Console.WriteLine(player.GetName() + " scored " + diceRoll + ". Require " + (scoreToWin - totalScore) + " score to win");
                }
                else
                {
                    player.SetTotalScore(diceRoll);
                    Console.WriteLine(player.GetName() + " rolled dice, and scored " + diceRoll + " points, for a total of " + player.GetTotalScore() + " points");
                }
            }
            catch (Exception ex)
            { Console.WriteLine("Error!!! " + ex.ToString()); }
        }

        // Function to create rank table
        public void WhoIsLeading()
        {
            string str = "";
            try
            {
                if (scoreToWin == 0)
                {
                    Console.WriteLine("Please start the game");
                    return;
                }

                if (objPlayers.Count == finalTable.Rows.Count)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Rank Table : ");
                    Console.WriteLine("");

                    foreach (DataColumn column in finalTable.Columns)
                    {
                        str += column.ColumnName + " | ";
                    }

                    Console.WriteLine(str);


                    foreach (DataRow row in finalTable.Rows)
                    {
                        str = "";

                        foreach (var vitem in row.ItemArray)
                        {
                            str += vitem + " | ";
                        }
                        Console.WriteLine(str);
                    }

                    Console.WriteLine("");
                    Console.WriteLine(finalTable.Rows[0][1] + " is the WINNER!!!");

                    Console.WriteLine("");

                }
                else
                {

                    //int[] arrscore = new int[objPlayers.Count];

                    products = new DataTable();
                    products.TableName = "Result";
                    products.Columns.Add("Rank", typeof(int)).AllowDBNull = false;
                    products.Columns.Add("Name", typeof(string));
                    products.Columns.Add("Score", typeof(int)).AllowDBNull = false;


                    int lastRank = 0;

                    foreach (var vPlayer in objPlayers)
                    {
                        DataRow newRow = products.NewRow();
                        //arrscore[0] = Convert.ToInt32(vPlayer.getTotalScore());
                        newRow["Rank"] = lastRank;
                        newRow["Name"] = vPlayer.GetName();
                        newRow["Score"] = Convert.ToInt32(vPlayer.GetTotalScore());

                        products.Rows.Add(newRow);
                        lastRank++;
                    }

                    products.DefaultView.Sort = "Score desc";
                    products = products.DefaultView.ToTable();

                    Console.WriteLine("");
                    Console.WriteLine("Rank Table : ");
                    Console.WriteLine("");

                    foreach (DataColumn column in products.Columns)
                    {
                        str += column.ColumnName + " | ";
                    }

                    Console.WriteLine(str);

                    lastRank = 1;
                    foreach (DataRow row in products.Rows)
                    {
                        str = "";
                        row["Rank"] = lastRank;

                        foreach (var vitem in row.ItemArray)
                        {
                            str += vitem + " | ";
                        }
                        Console.WriteLine(str);
                        lastRank++;
                    }

                    Console.WriteLine("");
                }
            }
            catch (Exception ex)
            { Console.WriteLine("Error!!! " + ex.ToString()); }
        }

        // Function to check who won
        public void CheckIfAnyoneHasWon(int index)
        {
            try
            {
                if (scoreToWin != 0)
                {
                    if (objPlayers[index].GetTotalScore() == scoreToWin)
                    {
                        DataRow newRow = finalTable.NewRow();
                        if (finalTable.Rows.Count == 0)
                            newRow["Rank"] = 1;
                        else
                            newRow["Rank"] = finalTable.Rows.Count + 1;

                        newRow["Name"] = objPlayers[index].GetName();
                        newRow["Score"] = Convert.ToInt32(objPlayers[index].GetTotalScore());

                        finalTable.Rows.Add(newRow);

                        Console.WriteLine(objPlayers[index].GetName() + " Won!!!");
                    }
                }
                else
                {
                    Console.WriteLine("Please start the game by selecting option 1");
                }
            }
            catch (Exception ex)
            { Console.WriteLine("Error!!! " + ex.ToString()); }
        }
    }
}
