using System;
using System.Linq;

namespace AoC._11
{
	public class Program
	{
		public static int PowerGridSerialNumber { get; } = 8772;

		public static int[,] CalculateMatrix(int serialNr)
		{
			var matrix = new int[300, 300];

			for (var x = 0; x < 300; x++)
			{
				for (var y = 0; y < 300; y++)
				{
					var rackId = (x + 10);

					var intermediate = (rackId * y + serialNr) * rackId;
					var stringNr = intermediate.ToString();
					var hundredDigit = stringNr.Length >= 3 ? int.Parse(stringNr.ElementAt(stringNr.Length - 3).ToString()) : 0;
					matrix[x, y] = hundredDigit - 5;
				}
			}

			return matrix;
		}

		public static (int maxSum, int x, int y) GetBoxSum(int[,] matrix, int boxX, int boxY)
		{
			var currentSum = new int[matrix.GetLength(0) - boxX, matrix.GetLength(1) - boxY];

			int maxX = -1, maxY = -1;
			var maxFound = 0;

			for (var x = 0; x < matrix.GetLength(0) - boxX; x++)
			{
				for (var y = 0; y < matrix.GetLength(1) - boxY; y++)
				{
					for (var x1 = 0; x1 < boxX; x1++)
					{
						for (var y1 = 0; y1 < boxY; y1++)
						{
							currentSum[x, y] += matrix[x + x1, y + y1];
						}
					}

					if (currentSum[x, y] > maxFound)
					{
						maxFound = currentSum[x, y];
						maxX = x;
						maxY = y;
					}
				}
			}

			return (maxFound, maxX, maxY);
		}

		static void Main(string[] args)
		{
			Console.WriteLine("Advent of Code Day 10!");

			var matrix = CalculateMatrix(PowerGridSerialNumber);

			var biggestResult = GetBoxSum(matrix, 3, 3);
			Console.WriteLine($"Star 1: {biggestResult.x},{biggestResult.y}");

			Console.ReadLine();
		}
	}
}