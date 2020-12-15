using System;
namespace diceGameNew.src.diceGame
{
    public interface gameInterface
    {
        void DisplayGameMenue();

        void DisplayGameInstruction();

        void SelectGameOption(int optionSelected);

        void StartNewGame();

        void PlayOneRound(player player, out int roll);

        void WhoIsLeading();

        void CheckIfAnyoneHasWon(int index);
    }
}
