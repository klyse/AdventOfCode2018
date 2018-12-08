using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using static System.Int32;
using System.Drawing.Imaging;

namespace AoC._6
{
	internal class Program
	{
		private static readonly List<Point> InputCoordinates = new List<Point>
		{
			new Point(137, 282),
			new Point(229, 214),
			new Point(289, 292),
			new Point(249, 305),
			new Point(90, 289),
			new Point(259, 316),
			new Point(134, 103),
			new Point(96, 219),
			new Point(92, 308),
			new Point(269, 59),
			new Point(141, 132),
			new Point(71, 200),
			new Point(337, 350),
			new Point(40, 256),
			new Point(236, 105),
			new Point(314, 219),
			new Point(295, 332),
			new Point(114, 217),
			new Point(43, 202),
			new Point(160, 164),
			new Point(245, 303),
			new Point(339, 277),
			new Point(310, 316),
			new Point(164, 44),
			new Point(196, 335),
			new Point(228, 345),
			new Point(41, 49),
			new Point(84, 298),
			new Point(43, 51),
			new Point(158, 347),
			new Point(121, 51),
			new Point(176, 187),
			new Point(213, 120),
			new Point(174, 133),
			new Point(259, 263),
			new Point(210, 205),
			new Point(303, 233),
			new Point(265, 98),
			new Point(359, 332),
			new Point(186, 340),
			new Point(132, 99),
			new Point(174, 153),
			new Point(206, 142),
			new Point(341, 162),
			new Point(180, 166),
			new Point(152, 249),
			new Point(221, 118),
			new Point(95, 227),
			new Point(152, 186),
			new Point(72, 330),
		};

		//private static readonly List<Point> InputCoordinates = new List<Point>
		//{
		//	new Point(1, 1),
		//	new Point(1, 6),
		//	new Point(8, 3),
		//	new Point(3, 4),
		//	new Point(5, 5),
		//	new Point(8, 9)
		//};

		private static readonly List<Color> Colors = new List<Color>
		{
			ColorTranslator.FromHtml("#8f9455"),
			ColorTranslator.FromHtml("#a956cf"),
			ColorTranslator.FromHtml("#52c249"),
			ColorTranslator.FromHtml("#d140a3"),
			ColorTranslator.FromHtml("#8ebc3a"),
			ColorTranslator.FromHtml("#6665d5"),
			ColorTranslator.FromHtml("#c4ba37"),
			ColorTranslator.FromHtml("#8a50a1"),
			ColorTranslator.FromHtml("#3e8d29"),
			ColorTranslator.FromHtml("#da7eda"),
			ColorTranslator.FromHtml("#59bd67"),
			ColorTranslator.FromHtml("#e83b7a"),
			ColorTranslator.FromHtml("#4cc892"),
			ColorTranslator.FromHtml("#de3951"),
			ColorTranslator.FromHtml("#5accbd"),
			ColorTranslator.FromHtml("#d9492e"),
			ColorTranslator.FromHtml("#4cbee0"),
			ColorTranslator.FromHtml("#e67629"),
			ColorTranslator.FromHtml("#4c94d0"),
			ColorTranslator.FromHtml("#e6a130"),
			ColorTranslator.FromHtml("#556bb5"),
			ColorTranslator.FromHtml("#7a8f2b"),
			ColorTranslator.FromHtml("#a196e1"),
			ColorTranslator.FromHtml("#b59b3c"),
			ColorTranslator.FromHtml("#b03671"),
			ColorTranslator.FromHtml("#63a76b"),
			ColorTranslator.FromHtml("#e86a9c"),
			ColorTranslator.FromHtml("#2e7741"),
			ColorTranslator.FromHtml("#bb3859"),
			ColorTranslator.FromHtml("#3e9f86"),
			ColorTranslator.FromHtml("#b13f2f"),
			ColorTranslator.FromHtml("#277257"),
			ColorTranslator.FromHtml("#b5444c"),
			ColorTranslator.FromHtml("#547c34"),
			ColorTranslator.FromHtml("#a65b92"),
			ColorTranslator.FromHtml("#a6bd6d"),
			ColorTranslator.FromHtml("#914767"),
			ColorTranslator.FromHtml("#556213"),
			ColorTranslator.FromHtml("#d68ec0"),
			ColorTranslator.FromHtml("#af761e"),
			ColorTranslator.FromHtml("#dd8494"),
			ColorTranslator.FromHtml("#59602a"),
			ColorTranslator.FromHtml("#e47f6e"),
			ColorTranslator.FromHtml("#7d6e22"),
			ColorTranslator.FromHtml("#9d4b55"),
			ColorTranslator.FromHtml("#e69a59"),
			ColorTranslator.FromHtml("#964f34"),
			ColorTranslator.FromHtml("#d3a46f"),
			ColorTranslator.FromHtml("#bd5f2b"),
			ColorTranslator.FromHtml("#966633")
		};

		/// <summary>
		/// Calculates the Manhattan distance between the two points.
		/// </summary>
		public static int CalculateManhattanDistance(Point pt1, Point pt2)
		{
			return Math.Abs(pt1.X - pt2.X) + Math.Abs(pt1.Y - pt2.Y);
		}


		public class Coordinate
		{
			public int Id { get; set; }
			public Point Point { get; set; }
		}

		public class Field
		{
			public int PointId { get; set; }
			public int Distance { get; set; } = MaxValue;
		}

		private static void Star1(List<Coordinate> coordinates)
		{
			var boarderYMin = 0;
			var boarderYMax = InputCoordinates.Max(c => c.Y) + 20;
			var boarderXMin = 0;
			var boarderXMax = InputCoordinates.Max(c => c.X) + 20;

			var minValX = InputCoordinates.Min(c => c.X);
			var minValY = InputCoordinates.Min(c => c.Y);
			var maxValX = InputCoordinates.Max(c => c.X);
			var maxValY = InputCoordinates.Max(c => c.Y);

			var numCoordinates = coordinates.Count;

			var coordinateSystem = new int[numCoordinates, boarderXMax - boarderXMin, boarderYMax - boarderXMin];

			for (var c = 0; c < numCoordinates; c++)
			{
				var input = coordinates[c];
				for (var x = boarderXMin; x < boarderXMax; x++)
				for (var y = boarderYMin; y < boarderYMax; y++)
					coordinateSystem[c, x, y] = CalculateManhattanDistance(new Point(x, y), input.Point);
			}

			var evaluatedCoordinates = new Field[boarderXMax - boarderXMin, boarderYMax - boarderXMin];

			for (var x = boarderXMin; x < boarderXMax; x++)
			for (var y = boarderYMin; y < boarderYMax; y++)
			{
				var evaluatedCoordinate = evaluatedCoordinates[x, y] = evaluatedCoordinates[x, y] ?? new Field();

				var same = false;
				for (var c = 0; c < numCoordinates; c++)
				{
					var coordinate = coordinateSystem[c, x, y];

					if (evaluatedCoordinate.Distance == coordinate)
					{
						same = true;
					}
					else if (evaluatedCoordinate.Distance > coordinate)
					{
						same = false;
						evaluatedCoordinate.Distance = coordinate;
						evaluatedCoordinate.PointId = c;
					}
				}

				if (same)
					evaluatedCoordinate.Distance = -1;
			}

			var draw = false;
			// ReSharper disable once ConditionIsAlwaysTrueOrFalse
			if (draw)
				// ReSharper disable HeuristicUnreachableCode
				for (var y = boarderYMin; y < boarderYMax; y++)
				{
					for (var x = boarderXMin; x < boarderXMax; x++)
						if (evaluatedCoordinates[x, y].Distance < 0)
							Console.Write(" . ");
						else if (evaluatedCoordinates[x, y].Distance == 0)
							Console.Write(" x ");
						else
							Console.Write($"{evaluatedCoordinates[x, y].PointId}".PadLeft(3));

					Console.WriteLine();
				}
			// ReSharper restore HeuristicUnreachableCode

			Console.WriteLine("Results:");

			var resultSet = new Dictionary<int, int>();

			for (var x = boarderXMin; x < boarderXMax; x++)
			for (var y = boarderYMin; y < boarderYMax; y++)
			{
				var point = evaluatedCoordinates[x, y];

				if (evaluatedCoordinates[x, y].Distance < 0)
					continue;

				if (!resultSet.ContainsKey(point.PointId))
					resultSet.Add(point.PointId, 0);

				if (x <= minValX || x >= maxValX ||
					y <= minValY || y >= maxValY)
				{
					resultSet[point.PointId] = MinValue;
					continue;
				}

				resultSet[point.PointId]++;
			}

			foreach (var number in resultSet.OrderBy(c => c.Value)) Console.WriteLine($"PointID: {number}");

			var biggestPoint = resultSet.OrderBy(c => c.Value).Last().Key;

			var pic = new Bitmap(boarderXMax, boarderYMax);
			for (var y = boarderYMin; y < boarderYMax; y++)
			{
				for (var x = boarderXMin; x < boarderXMax; x++)
				{
					if (evaluatedCoordinates[x, y].Distance < 0) continue;

					if (biggestPoint == evaluatedCoordinates[x, y].PointId)
					{
						pic.SetPixel(x, y, Color.Red);
					}
					else if (y == minValY || y == maxValY || x == minValX || x == maxValX)
					{
						var col = Color.FromArgb(150, Color.Black);
						pic.SetPixel(x, y, col);
					}
					else if (evaluatedCoordinates[x, y].Distance == 0)
					{
						pic.SetPixel(x, y, Color.Fuchsia);
					}
					else if (resultSet[evaluatedCoordinates[x, y].PointId] < 0)
					{
						var col = Color.FromArgb(150, Colors[evaluatedCoordinates[x, y].PointId]);
						pic.SetPixel(x, y, col);
					}
					else
					{
						pic.SetPixel(x, y, Colors[evaluatedCoordinates[x, y].PointId]);
					}
				}

				pic.Save("test.png", ImageFormat.Png);
			}
		}

		public static void Star2(List<Coordinate> coordinates)
		{
#pragma warning disable 219
			var boarderYMin = 0;
			var boarderYMax = InputCoordinates.Max(c => c.Y) + 1;
			var boarderXMin = 0;
			var boarderXMax = InputCoordinates.Max(c => c.X) + 1;
#pragma warning restore 219

			var minValX = InputCoordinates.Min(c => c.X);
			var minValY = InputCoordinates.Min(c => c.Y);
			var maxValX = InputCoordinates.Max(c => c.X);
			var maxValY = InputCoordinates.Max(c => c.Y);

			var numCoordinates = coordinates.Count;

			var coordinateSystem = new int[boarderXMax - boarderXMin, boarderYMax - boarderXMin];

			var maxCol = 0;
			for (var c = 0; c < numCoordinates; c++)
			{
				var input = coordinates[c];
				for (var x = minValX; x < maxValX; x++)
				for (var y = minValY; y < maxValY; y++)
				{
					coordinateSystem[x, y] += Math.Abs(x - input.Point.X) + Math.Abs(y - input.Point.Y);
					maxCol = Math.Max(maxCol, coordinateSystem[x, y]);
				}
			}


			var col = 255.0 / maxCol;
			var pic = new Bitmap(boarderXMax - minValX, boarderYMax - minValY);
			var areaSmallerThan10000 = 0;

			for (var y = minValY; y < maxValY; y++)
			for (var x = minValX; x < maxValX; x++)
				if (coordinateSystem[x, y] < 10000)
				{
					pic.SetPixel(x - minValX, y - minValY, Color.Yellow);
					areaSmallerThan10000++;
				}
				else
				{
					var a = (int)(coordinateSystem[x, y] * col);
					pic.SetPixel(x - minValX, y - minValY, Color.FromArgb(a, Color.Red));
				}

			foreach (var coordinate in coordinates) pic.SetPixel(coordinate.Point.X - minValX, coordinate.Point.Y - minValY, Color.Blue);

			pic.Save("test1.png", ImageFormat.Png);

			Console.WriteLine($"Area smaller than 10.000: {areaSmallerThan10000}");
		}

		private static void Main()
		{
			Console.WriteLine("Advent of Code Day 6!");


			var coordinates = new List<Coordinate>();
			var id = 0;
			foreach (var coordinate in InputCoordinates)
			{
				coordinates.Add(new Coordinate
				{
					Id = id,
					Point = coordinate
				});
				id++;
			}

			Star1(coordinates);
			Star2(coordinates);

			Console.ReadLine();
		}
	}
}