using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumber
{

	public enum GuessingPlayer
	{
		Human,
		Machine
	}
	class GuessNumber
	{
		private readonly int maxTries;
		private int maxNum;
		private readonly GuessingPlayer guessingPlayer;

		public GuessNumber(int maxNum = 100, int maxTries = 5, GuessingPlayer guessingPlayer = GuessingPlayer.Human)
		{
			this.maxTries = maxTries;
			this.maxNum = maxNum;
			this.guessingPlayer = guessingPlayer;

		}
		public void Start()
		{
			if (guessingPlayer == GuessingPlayer.Human)
			{
				HumanGuess();
			}
			else if (guessingPlayer == GuessingPlayer.Machine)
			{
				MachineGuess();
			}
		}
		private void HumanGuess()
		{
			Random rand = new Random();
			int guessedNumber = rand.Next(0, maxNum);

			int currentGuess = -1;
			int currentTry = 0;

			while (currentGuess != guessedNumber && currentTry < maxTries)
			{
				Console.WriteLine("Enter the number");
				currentGuess = int.Parse(Console.ReadLine());

				if (currentGuess == guessedNumber)
				{
					Console.WriteLine("You win!");
					break;
				}

				if (guessedNumber > currentGuess)
				{
					Console.WriteLine("Guessed number bigger than you enter");
				}
				else if (guessedNumber < currentGuess)
				{
					Console.WriteLine("Guessed number smaller than you enter");
				}
				currentTry++;

				if (currentTry == maxTries)
				{
					Console.WriteLine($"You lose. The number was{guessedNumber}");
				}

			}
		}
		private void MachineGuess()
		{
			Console.WriteLine("Guess the number");
			int guessedNumber = int.Parse(Console.ReadLine());

			int min = 0;
			int max = maxNum;


			int currentGuess = -1;
			int currentTry = 0;
			string answer = "";
			while (currentGuess != guessedNumber && currentTry < maxTries)
			{
				currentGuess = (min + max) / 2;
				Console.WriteLine($"Is it {currentGuess}? y/n");
				answer = Console.ReadLine();

				if(currentGuess == guessedNumber && answer == "n")
				{
					Console.WriteLine("you lie");
				}
				else if (answer == "y")
				{
					Console.WriteLine("Computer is win");
				}
				else
				{
					if (guessedNumber > currentGuess)
					{
						min = currentGuess;
					}
					else if (guessedNumber < currentGuess)
					{
						max = currentGuess;
					}
				}
				currentTry++;

				if (currentTry == maxTries)
				{
					Console.WriteLine("Computer is lose");
				}
			}
		}

	}
}
