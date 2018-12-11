using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AoC._9
{
	public static class Program
	{
		public static LinkedListNode<T> NextOrFirst<T>(this LinkedListNode<T> current)
		{
			if (current.Next == null)
				return current.List.First;
			return current.Next;
		}

		public static LinkedListNode<T> PreviousOrLast<T>(this LinkedListNode<T> current)
		{
			if (current.Previous == null)
				return current.List.Last;
			return current.Previous;
		}

		public static LinkedListNode<T> GetNodeAtPos<T>(this LinkedListNode<T> currentNode, int shiftDelta)
		{
			for (int i = 0; i < Math.Abs(shiftDelta); i++)
			{
				if (shiftDelta < 0)
				{
					currentNode = currentNode.PreviousOrLast();
				}
				else if (shiftDelta > 0)
				{
					currentNode = currentNode.NextOrFirst();
				}
			}

			return currentNode;
		}

		public static BigInteger CalculateWinningElveScore(int nrElves, int nrMarbles)
		{
			var marbleCircle = new LinkedList<int>();
			var playerScore = new BigInteger[nrElves];

			var currentPlayer = 0;
			var currentMarble = marbleCircle.AddFirst(0);

			for (var i = 1; i <= nrMarbles; ++i)
			{
				if (i % 23 == 0)
				{
					currentMarble = currentMarble.GetNodeAtPos(-7);
					playerScore[currentPlayer] += currentMarble.Value + i;

					var nextMarble = currentMarble.Next;
					marbleCircle.Remove(currentMarble);
					currentMarble = nextMarble;
				}
				else
				{
					currentMarble = currentMarble.NextOrFirst();
					currentMarble = marbleCircle.AddAfter(currentMarble, i);
				}

				currentPlayer++;
				currentPlayer %= nrElves;
			}


			return playerScore.Max();
		}

		static void Main()
		{
			Console.WriteLine("Advent of Code Day 9!");

			Console.WriteLine($"Example score: {CalculateWinningElveScore(9, 25)}");
			Console.WriteLine($"Star 1: {CalculateWinningElveScore(430, 71588)}");
			Console.WriteLine($"Star 2: {CalculateWinningElveScore(430, 71588 * 100)}");

			Console.ReadLine();
		}
	}
}