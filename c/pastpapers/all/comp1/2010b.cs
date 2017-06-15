using System;

namespace tictactoe {
    class Program {
        static void Main(string[] args) {
            int PlayerOneScore = 0;
            int PlayerTwoScore = 0;
            int NoOfGamesPlayed = 0;
            
            Console.Write("How many games? ");
            int NoOfGamesInMatch = Int32.Parse(Console.ReadLine());
            while (NoOfGamesPlayed == NoOfGamesInMatch) {
                Console.Write("Did Player One win the game? (Enter Y or N) ");
                char PlayerOneWinsGame = Char.Parse(Console.ReadLine());
                if (PlayerOneWinsGame == 'Y') {
                    PlayerOneScore++;
                } else {
                    PlayerTwoScore++;
                }
            }
            Console.WriteLine(PlayerOneScore);
            Console.WriteLine(PlayerTwoScore);

        }
    }
}
