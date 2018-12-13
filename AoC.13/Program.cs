using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

// ReSharper disable ConditionIsAlwaysTrueOrFalse

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

	public class Cart : ICloneable
	{
		public Point Point { get; set; }
		public char Orientation { get; set; }
		public int CrossDir { get; set; }

		public object Clone()
		{
			return new Cart
			{
				Point = Point,
				Orientation = Orientation,
				CrossDir = CrossDir
			};
		}
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

		public static bool IsCorner(this char c)
		{
			return c == '\\' || c == '/';
		}

		public static bool IsCart(this char c)
		{
			var cartSign = new[] {'<', '>', '^', 'v'};

			return cartSign.Contains(c);
		}

		public static char MirrorOrientation(this char c)
		{
			if (c == '>')
				return '<';
			if (c == '<')
				return '>';
			if (c == '^')
				return 'v';
			if (c == 'v')
				return '^';

			throw new Exception("not recognized char");
		}

		public static char ShiftLeft(this char c)
		{
			if (c == '>')
				return '^';
			if (c == '<')
				return 'v';
			if (c == '^')
				return '<';
			if (c == 'v')
				return '>';

			throw new Exception("not recognized char");
		}

		public static char ShiftRight(this char c)
		{
			return c.ShiftLeft().MirrorOrientation();
		}
	}

	public class Program
	{
		public static char[,] InputMatrix { get; set; }
		public static List<Cart> Carts { get; set; } = new List<Cart>();

		static Point Tick(List<Cart> carts, bool star2 = false)
		{
			var toRemove = new List<Cart>();
			foreach (var cart in carts.OrderBy(c => c.Point.X).ThenBy(c => c.Point.Y))
			{
				var currentOrientation = cart.Orientation;
				var newOrientation = currentOrientation;
				char nextPt;
				Point nextPoint;

				if (currentOrientation.IsUp())
				{
					nextPoint = new Point(cart.Point.X - 1, cart.Point.Y);
					nextPt = InputMatrix[cart.Point.X - 1, cart.Point.Y];
				}
				else if (currentOrientation.IsDown())
				{
					nextPoint = new Point(cart.Point.X + 1, cart.Point.Y);
					nextPt = InputMatrix[cart.Point.X + 1, cart.Point.Y];
				}
				else if (currentOrientation.IsLeft())
				{
					nextPoint = new Point(cart.Point.X, cart.Point.Y - 1);
					nextPt = InputMatrix[cart.Point.X, cart.Point.Y - 1];
				}
				else if (currentOrientation.IsRight())
				{
					nextPoint = new Point(cart.Point.X, cart.Point.Y + 1);
					nextPt = InputMatrix[cart.Point.X, cart.Point.Y + 1];
				}
				else
				{
					throw new Exception("Cart has no orientation");
				}

				if (!star2)
				{
					if (carts.Any(c => c.Point == nextPoint))
					{
						cart.Point = nextPoint;
						cart.Orientation = 'X';
						return nextPoint;
					}
				}
				else
				{
					var badCart = carts.FirstOrDefault(c => c.Point == nextPoint);
					if (badCart != null)
					{
						toRemove.Add(badCart);
						toRemove.Add(cart);
					}
				}

				if (nextPt.IsCorner())
				{
					bool mirror = nextPt == '\\';

					if (currentOrientation.IsUp())
					{
						newOrientation = '<';
					}
					else if (currentOrientation.IsDown())
					{
						newOrientation = '>';
					}
					else if (currentOrientation.IsLeft())
					{
						newOrientation = '^';
					}
					else if (currentOrientation.IsRight())
					{
						newOrientation = 'v';
					}

					newOrientation = mirror ? newOrientation : newOrientation.MirrorOrientation();
				}
				else if (nextPt.IsCrossing())
				{
					switch (cart.CrossDir)
					{
						case 0: // left
							cart.CrossDir++;
							newOrientation = currentOrientation.ShiftLeft();
							break;
						case 1: // straight
							newOrientation = currentOrientation; // same
							cart.CrossDir++;
							break;
						case 2: // right
							newOrientation = currentOrientation.ShiftRight();
							cart.CrossDir = 0;
							break;
					}
				}

				cart.Point = nextPoint;
				cart.Orientation = newOrientation;
			}

			foreach (var cart in toRemove)
			{
				carts.Remove(cart);
			}

			return Point.Empty;
		}

		public static void DrawMatrix(List<Cart> carts)
		{
			for (var x = 0; x < InputMatrix.GetLength(0); x++)
			{
				for (var y = 0; y < InputMatrix.GetLength(1); y++)
				{
					var cart = carts.FirstOrDefault(c => c.Point.X == x && c.Point.Y == y);
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
		}

		static void Main()
		{
			Console.WriteLine("Advent of Code Day 13!");

			var example = false;
			var inputFile = "input.txt";
			if (example)
				//inputFile = "example1.txt";
				inputFile = "example2.txt";

			var input = File.ReadAllLines(inputFile);
			var yLen = input.First().Length;
			var xLen = input.Length;

			InputMatrix = new char[xLen, yLen];

			for (var x = 0; x < xLen; x++)
			{
				var split = input[x].Select(c => c).ToArray();
				for (var y = 0; y < yLen; y++)
				{
					var cEl = split[y];

					if (cEl == '^' || cEl == 'v')
					{
						Carts.Add(new Cart {Orientation = cEl, Point = new Point(x, y)});
						cEl = '|';
					}
					else if (cEl == '>' || cEl == '<')
					{
						Carts.Add(new Cart {Orientation = cEl, Point = new Point(x, y)});
						cEl = '-';
					}

					InputMatrix[x, y] = cEl;
				}
			}

			var consoleOffset = Console.CursorTop;
			Point collision;
			var cartCopy = Carts.Select(c => (Cart)c.Clone()).ToList();


			if (example)
				DrawMatrix(cartCopy);
			do
			{
				collision = Tick(cartCopy);

				if (example)
				{
					Console.CursorLeft = 0;
					Console.CursorTop = consoleOffset;
					DrawMatrix(cartCopy);
					Thread.Sleep(400);
				}
			} while (collision == Point.Empty);

			Console.WriteLine($"Star 1: First collision at: {collision.Y},{collision.X}");


			consoleOffset = Console.CursorTop;
			cartCopy = Carts.Select(c => (Cart)c.Clone()).ToList();
			if (example)
				DrawMatrix(cartCopy);

			do
			{
				Tick(cartCopy,true);

				if (example)
				{
					Console.CursorLeft = 0;
					Console.CursorTop = consoleOffset;
					DrawMatrix(cartCopy);
					Thread.Sleep(400);
				}
				if (cartCopy.Count == 1)
				{
					break;
				}

			} while (true);

			Console.WriteLine($"Star 2: Lat carts position: {cartCopy.First().Point.Y},{cartCopy.First().Point.X}");


			Console.ReadLine();
		}
	}
}