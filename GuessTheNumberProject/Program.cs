using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberProject {
	class Program {
		// method GenerateMagicNumber returns random number between 1 - 100 (MagicNumber)
		int GenerateMagicNumber(int HighestNumber) {
			Random rnd = new Random();
			var MagicNumber = rnd.Next(101);
			// Debug($"The magic number is {MagicNumber}");
			return MagicNumber;
		} 
		// method AskForTheGuess displays a message asking user to pick a number 1 - 100,
		int AskForTheGuess() {
			Console.Write($"Pick a number 1 - 100 : ");
		// user's guess is stored as a string inside variable TheGuess
			var TheGuess = Console.ReadLine();
		// string is then converted into an integer and stored as integer variable GuessTheNumber
			int GuessTheNumber = int.Parse(TheGuess);
		// GuessTheNumber value is returned to 
			return GuessTheNumber;
		}
		int CompareGuessToMagicNumber(int MagicNumber, int TheGuess) {
			if (MagicNumber == TheGuess) { // is the guess correct?
				return 0;
			}
			if (MagicNumber > TheGuess) { // is the guess too low?
				return -1;
			}
			if (MagicNumber < TheGuess) { // is the guess too high?
				return 1;
			}

			return -2;
		}
		bool PrintOutcomeResult(int Result) {
			if (Result == 0) { // the guess matched - they won
				Debug("Correct! You won the game!");
				return true; }

			if (Result == -1) { // the guess is too low
				Debug("Too low, guess again.");
				return false; }

			if (Result == 1) { // the guess is too high
			Debug("Too high, guess again.");
			return false; }
			return true;
		}
		void Debug(string message) {
			Console.WriteLine(message);
		}
		void RunGameOnce() {
			var MagicNumber = GenerateMagicNumber(100);
			bool GameOver = false;
			while (GameOver == false) {
			var UserGuess = AskForTheGuess();
			var GuessResult = CompareGuessToMagicNumber(MagicNumber, UserGuess);
			GameOver = PrintOutcomeResult(GuessResult);
			}
		}
		void Run() {
			bool PlayAgain = true;
			while (PlayAgain == true) {
				RunGameOnce();
				Console.Write($"Play again? Y/N : ");
				var answer = Console.ReadLine();
				if (answer == "Y" || answer == "y" || answer== "Yes" || answer == "yes") {
					PlayAgain = true;
				} else {
					PlayAgain = false;
				}
			}
		}
		static void Main(string[] args) {
			new Program().Run();
		}
	}
}
