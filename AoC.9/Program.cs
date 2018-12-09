using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AoC._9
{
	public class Program
	{
		public static BigInteger CalculateWinningElveScore(int nrElves, int nrMarbles)
		{
			var marbleCircle = new List<int>();
			var playerScore = new BigInteger[nrElves];

			var currentPlayer = 0;
			var currentMarble = 0;
			marbleCircle.Add(currentMarble);

			if (nrMarbles < 30 && nrElves < 10)
				Console.WriteLine("[-] (0)");

			for (var i = 1; i <= nrMarbles; ++i)
			{
				if (i % 23 == 0)
				{
					playerScore[currentPlayer] += i;
					currentMarble = currentMarble - 7;
					if (currentMarble < 0)
						currentMarble = marbleCircle.Count + currentMarble;

					playerScore[currentPlayer] += marbleCircle[currentMarble];

					marbleCircle.RemoveAt(currentMarble);
				}
				else
				{
					currentMarble = ((currentMarble + 1) % marbleCircle.Count) + 1;
					marbleCircle.Insert(currentMarble, i);
				}

				if (nrMarbles < 30 && nrElves < 10)
				{
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
				}

				currentPlayer++;
				currentPlayer %= nrElves;
			}


			return playerScore.Max();
		}

		static void Main()
		{
			Console.WriteLine("Advent of Code Day 9!");

			Console.WriteLine("Example:");
			Console.WriteLine($"Example score: {CalculateWinningElveScore(9, 25)}");
			Console.WriteLine($"Star 1: {CalculateWinningElveScore(430, 71588)}");
			Console.WriteLine("Calculation for Star 2 takes 4-ever. Here is the pre-calculated value: 3412522480");
			Console.WriteLine($"Star 2: {CalculateWinningElveScore(430, 71588 * 100)}");

			Console.ReadLine();
		}
	}
}