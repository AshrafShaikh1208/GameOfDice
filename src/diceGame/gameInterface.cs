using System;
namespace diceGameNew.src.diceGame
{
    public interface IGameInterface
    {
        void DisplayGameMenue();

        void DisplayGameInstruction();

        void SelectGameOption(int optionSelected);

        void StartNewGame();

        void PlayOneRound(Player player, out int roll);

        void WhoIsLeading();

        void CheckIfAnyoneHasWon(int index);
    }
}
