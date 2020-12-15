using System;
namespace diceGameNew.src.diceGame
{
    public class player
    {
        private String name;
        private int totalScore;
        private bool resultDisplayed = false;
        private int rank;

        public player(String name)
        {
            this.name = name;
        }

        public String getName()
        {
            return name;
        }

        public int getTotalScore()
        {
            return totalScore;
        }

        public void setTotalScore(int score)
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
