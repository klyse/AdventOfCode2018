using System;
using System.Linq;
using System.Threading.Tasks;

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
				var preCalculated = new int[matrix.GetLength(1)];

				for (var y = 0; y < matrix.GetLength(1) - boxY; y++)
				{
					for (var x1 = 0; x1 < boxX; x1++)
					{
						preCalculated[y] += matrix[x + x1, y];
					}
				}

				for (var y = 0; y < matrix.GetLength(1) - boxY; y++)
				{
					for (var y1 = 0; y1 < boxX; y1++)
					{
						currentSum[x, y] += preCalculated[y + y1];
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

		static void Main()
		{
			Console.WriteLine("Advent of Code Day 11!");

			Console.WriteLine($"Power Grid Serial Number: {PowerGridSerialNumber}");

			var matrix = CalculateMatrix(PowerGridSerialNumber);

			var resultStar1 = GetBoxSum(matrix, 3, 3);
			Console.WriteLine($"Star 1: {resultStar1.x},{resultStar1.y} maxSum: {resultStar1.maxSum}");


			var (maxSum, x, y, box) = (0, 0, 0, 0);
			var @lock = new object();

			Parallel.For(0, 300, (i) =>
			{
				var sum = GetBoxSum(matrix, i, i);

				lock (@lock)
				{
					if (sum.maxSum > maxSum)
					{
						maxSum = sum.maxSum;
						y = sum.y;
						x = sum.x;
						box = i;
					}
				}
			});
			Console.WriteLine($"Star 2: {x},{y},{box} maxSum: {maxSum}");

			Console.ReadLine();
		}
	}
}