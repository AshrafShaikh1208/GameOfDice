# Game of Dice

## Purpose

The "Game of Dice" is a multiplayer game where N players roll a 6 faced dice in a round-robin fashion. Each time a player rolls the dice, their points increase by the number (1 to 6) achieved by the roll.
As soon as a player accumulates M points they complete the game and are assigned a rank. Remaining players continue to play the game till they accumulate at least M points. The game ends when all players have accumulated at least M points.

## Setup Prerequisites
1. .NET Core 5.0 SDK

## Notes about rules
1. The order in which the users roll the dice is decided randomly at the start of the game.
2. If a player rolls the value "6" then they immediately get another chance to roll again and
move ahead in the game.
3. If a player rolls the value "1" two consecutive times then they are forced to skip their next
turn as a penalty.

## How to play
1. Run the program.
2. Choose "Start New Game" option by pressing "1" and then press enter.
3. Select the number of players.
4. Select the score to win.
5. When its your turn, press "r" to roll the dice.
