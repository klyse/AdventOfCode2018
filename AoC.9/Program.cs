using System;
using System.Collections.Generic;

namespace AoC._9
{
	public class Program
	{
		public static int CalculateWinningElveScore(int nrElves, int nrMarbles)
		{
			var marbleCircle = new List<int>();
			var playerScore = new int[nrElves];

			var currentPlayer = 0;
			var currentMarble = 0;
			marbleCircle.Add(currentMarble);

			Console.WriteLine("[-] (0)");
			for (var i = 1; i < nrMarbles - 1; ++i)
			{
				currentMarble = ((currentMarble + 1) % marbleCircle.Count) + 1;
				marbleCircle.Insert(currentMarble, i);


				Console.Write($"[{currentPlayer}]");

				foreach (var marble in marbleCircle)
				{
					if (marble == i)
					{
						Console.Write($"({marble.ToString()})".PadLeft(4));
					}
					else
					{
						Console.Write(marble.ToString().PadLeft(4));
					}
				}

				Console.WriteLine();

				currentPlayer++;
				currentPlayer %= nrElves;
			}


			return 123;
		}

		static void Main(string[] args)
		{
			Console.WriteLine("Advent of Code Day 9!");

			CalculateWinningElveScore(9, 25);

			Console.ReadLine();
		}
	}
}