using System;

namespace guesser {
    class Program {
        static void Main(string[] args) {
            Console.Write("Player One enter your chosen number: ");
            int NumberToGuess;
            int Guess;
            int NumberOfGuesses;
            NumberToGuess = Int32.Parse(Console.ReadLine());
            while (NumberToGuess < 1 || NumberToGuess > 10) {
                Console.Write("Not a valid choice, please enter another number: ");
                NumberToGuess = Int32.Parse(Console.ReadLine());
            }
            Console.Clear();
            Guess = 0;
            NumberOfGuesses = 0;
            while (Guess != NumberToGuess && NumberOfGuesses < 5) {
                Console.Write("Player Two have a guess: ");
                Guess = Int32.Parse(Console.ReadLine());
                NumberOfGuesses++;
            }
            if (Guess != NumberToGuess) {
                Console.WriteLine("Player One wins");
            } else {
                Console.WriteLine("Player Two wins");
            }
        }
    }
}
