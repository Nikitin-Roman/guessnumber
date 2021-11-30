using System;

namespace GuessNumber
{
	class Program
	{
		static void Main(string[] args)
		{
			GuessNumber gsn = new GuessNumber(100, 5, GuessingPlayer.Machine);

			gsn.Start();
			Console.ReadLine();
		}
	}
}
