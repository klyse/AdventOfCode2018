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

		static void Main(string[] args)
		{
			Console.WriteLine("Advent of Code Day 10!");

			var matrix = CalculateMatrix(PowerGridSerialNumber);

			Console.ReadLine();
		}
	}
}