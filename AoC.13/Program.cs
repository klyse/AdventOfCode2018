using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;

namespace AoC._13
{
	public static class ArrayExt
	{
		public static T[] GetRow<T>(this T[,] array, int row)
		{
			if (!typeof(T).IsPrimitive)
				throw new InvalidOperationException("Not supported for managed types.");

			if (array == null)
				throw new ArgumentNullException("array");

			int cols = array.GetUpperBound(1) + 1;
			T[] result = new T[cols];

			int size;

			if (typeof(T) == typeof(bool))
				size = sizeof(bool);
			else if (typeof(T) == typeof(char))
				size = sizeof(char);
			else
				size = Marshal.SizeOf<T>();

			Buffer.BlockCopy(array, row * cols * size, result, 0, cols * size);

			return result;
		}
	}

	public class Cart
	{
		public Point Point { get; set; }
		public char Orientation { get; set; }
		public int CrossDir { get; set; }
	}

	public static class CharHelper
	{
		public static bool IsUp(this char c)
		{
			return c == '^';
		}

		public static bool IsDown(this char c)
		{
			return c == 'v';
		}

		public static bool IsLeft(this char c)
		{
			return c == '<';
		}

		public static bool IsRight(this char c)
		{
			return c == '>';
		}

		public static bool IsCrossing(this char c)
		{
			return c == '+';
		}
	}

	public class Program
	{
		public static char[,] InputMatrix { get; set; }
		public static List<Cart> Carts { get; set; } = new List<Cart>();

		static void Tick(char[,] matrix)
		{
			foreach (var cart in Carts.OrderBy(c => c.Point.X).ThenBy(c => c.Point.Y))
			{
				var currentOrientation = cart.Orientation;
				var nextPt = ' ';

				if (currentOrientation.IsUp())
					nextPt = matrix[cart.Point.X - 1, cart.Point.Y];
				if (currentOrientation.IsDown())
					nextPt = matrix[cart.Point.X + 1, cart.Point.Y];
				if (currentOrientation.IsLeft())
					nextPt = matrix[cart.Point.X, cart.Point.Y - 1];
				if (currentOrientation.IsRight())
					nextPt = matrix[cart.Point.X, cart.Point.Y + 1];

				if (nextPt == '\\')
				{
					
				}
			}
		}

		static void Main()
		{
			Console.WriteLine("Advent of Code Day 13!");

			var input = System.IO.File.ReadAllLines("example.txt");
			var yLen = input.First().Length;
			var xLen = input.Length;

			InputMatrix = new char[xLen, yLen];

			for (var x = 0; x < xLen; x++)
			{
				var split = input[x].Select(c => c).ToArray();
				for (var y = 0; y < yLen; y++)
				{
					var cEl = split[y];

					if (cEl == '^' || cEl == '<')
					{
						Carts.Add(new Cart {Orientation = cEl, Point = new Point(x, y)});
						cEl = '|';
					}
					else if (cEl == '>' || cEl == 'v')
					{
						Carts.Add(new Cart {Orientation = cEl, Point = new Point(x, y)});
						cEl = '-';
					}

					InputMatrix[x, y] = cEl;
				}
			}

			for (var x = 0; x < xLen; x++)
			{
				for (var y = 0; y < yLen; y++)
				{
					var cart = Carts.FirstOrDefault(c => c.Point.X == x && c.Point.Y == y);
					if (cart is null)
					{
						Console.Write(InputMatrix[x, y]);
					}
					else
					{
						Console.Write(cart.Orientation);
					}
				}

				Console.WriteLine();
			}


			Console.ReadLine();
		}
	}
}