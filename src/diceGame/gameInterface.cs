using System;
namespace diceGameNew.src.diceGame
{
    public interface gameInterface
    {
        void displayGameMenue();

        void displayGameInstruction();

        void selectGameOption(int optionSelected);

        void startNewGame();

        void playOneRound(player player, out int roll);

        void whoIsLeading();

        void checkIfAnyoneHasWon(int index);

       
    }
}
