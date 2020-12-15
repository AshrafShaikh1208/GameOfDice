using System;
namespace diceGameNew.src.diceGame
{
    public class Player
    {
        private String Name;
        private int totalScore;
        private bool resultDisplayed = false;
        private int rank;

        public Player(String name)
        {
            this.Name = name;
        }

        public String GetName()
        {
            return Name;

        }

        public int GetTotalScore()
        {
            return totalScore;
        }

        public void SetTotalScore(int score)
        {
            totalScore += score;
        }

        public bool ResultDisplayed
        {
            get { return resultDisplayed; }
            set { resultDisplayed = value; }
        }

        public int Rank
        {
            get { return rank; }
            set { rank = value; }
        }
    }
}
