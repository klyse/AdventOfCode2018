﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;

namespace AoC._10
{
	public class MyPoint
	{
		public int X { get; set; }
		public int Y { get; set; }

		public int XVelocity { get; set; }
		public int YVelocity { get; set; }

		public MyPoint(int x, int y, int xv, int yv)
		{
			X = x;
			Y = y;
			XVelocity = xv;
			YVelocity = yv;
		}
	}

	class Program
	{
		static readonly List<MyPoint> MyPoints = new List<MyPoint>
		{
			new MyPoint(21188, 31669, -2, -3),
			new MyPoint(-10416, -31455, 1, 3),
			new MyPoint(21144, -31450, -2, 3),
			new MyPoint(42218, 21146, -4, -2),
			new MyPoint(42223, 10633, -4, -1),
			new MyPoint(-52484, 42188, 5, -4),
			new MyPoint(52759, 21154, -5, -2),
			new MyPoint(-41981, 21153, 4, -2),
			new MyPoint(-10386, -31452, 1, 3),
			new MyPoint(10651, -10414, -1, 1),
			new MyPoint(42234, 42197, -4, -4),
			new MyPoint(-52447, 42193, 5, -4),
			new MyPoint(52763, -10408, -5, 1),
			new MyPoint(31673, 21150, -3, -2),
			new MyPoint(10660, -52501, -1, 5),
			new MyPoint(-31433, -31453, 3, 3),
			new MyPoint(52750, -20933, -5, 2),
			new MyPoint(42202, -31456, -4, 3),
			new MyPoint(-52442, -41971, 5, 4),
			new MyPoint(-52459, 52711, 5, -5),
			new MyPoint(-20916, -41972, 2, 4),
			new MyPoint(10656, 42191, -1, -4),
			new MyPoint(-41966, 21153, 4, -2),
			new MyPoint(-20912, 21153, 2, -2),
			new MyPoint(21172, -10415, -2, 1),
			new MyPoint(-41966, -20937, 4, 2),
			new MyPoint(-20898, -31455, 2, 3),
			new MyPoint(-20882, -52492, 2, 5),
			new MyPoint(21163, 31671, -2, -3),
			new MyPoint(-20924, 21148, 2, -2),
			new MyPoint(-41926, -41975, 4, 4),
			new MyPoint(-31459, -52497, 3, 5),
			new MyPoint(-10384, -10413, 1, 1),
			new MyPoint(-52485, -41980, 5, 4),
			new MyPoint(-41937, 10626, 4, -1),
			new MyPoint(21170, 42192, -2, -4),
			new MyPoint(21170, 52713, -2, -5),
			new MyPoint(-31405, 52715, 3, -5),
			new MyPoint(-41934, 52718, 4, -5),
			new MyPoint(-31445, -10415, 3, 1),
			new MyPoint(-41937, -20938, 4, 2),
			new MyPoint(31681, -52496, -3, 5),
			new MyPoint(21177, -52494, -2, 5),
			new MyPoint(52741, -20934, -5, 2),
			new MyPoint(21184, 21146, -2, -2),
			new MyPoint(-20887, 10634, 2, -1),
			new MyPoint(-52502, 42191, 5, -4),
			new MyPoint(42244, 21155, -4, -2),
			new MyPoint(42191, 10625, -4, -1),
			new MyPoint(-52495, 52716, 5, -5),
			new MyPoint(-31413, 10625, 3, -1),
			new MyPoint(-10418, -31452, 1, 3),
			new MyPoint(-10378, 52715, 1, -5),
			new MyPoint(52747, -31451, -5, 3),
			new MyPoint(21178, 31672, -2, -3),
			new MyPoint(-20888, 31675, 2, -3),
			new MyPoint(10657, 52714, -1, -5),
			new MyPoint(21152, 10630, -2, -1),
			new MyPoint(10676, 52718, -1, -5),
			new MyPoint(31722, -10408, -3, 1),
			new MyPoint(-41974, -41979, 4, 4),
			new MyPoint(-31416, -10409, 3, 1),
			new MyPoint(52715, -20930, -5, 2),
			new MyPoint(52755, -20931, -5, 2),
			new MyPoint(31669, 31674, -3, -3),
			new MyPoint(52750, -10413, -5, 1),
			new MyPoint(-10383, 10628, 1, -1),
			new MyPoint(31713, 21146, -3, -2),
			new MyPoint(52763, -52499, -5, 5),
			new MyPoint(42210, -52501, -4, 5),
			new MyPoint(10656, -31453, -1, 3),
			new MyPoint(31666, 21152, -3, -2),
			new MyPoint(-20896, -31453, 2, 3),
			new MyPoint(21145, -10415, -2, 1),
			new MyPoint(-52461, 21151, 5, -2),
			new MyPoint(-10363, -41972, 1, 4),
			new MyPoint(-20890, 10628, 2, -1),
			new MyPoint(-41973, -41976, 4, 4),
			new MyPoint(21186, -20934, -2, 2),
			new MyPoint(-52447, 42192, 5, -4),
			new MyPoint(-52458, -20937, 5, 2),
			new MyPoint(-20891, 52714, 2, -5),
			new MyPoint(21173, -52501, -2, 5),
			new MyPoint(52747, -31459, -5, 3),
			new MyPoint(42230, -20931, -4, 2),
			new MyPoint(52708, -52498, -5, 5),
			new MyPoint(52755, 21146, -5, -2),
			new MyPoint(21173, 31675, -2, -3),
			new MyPoint(-20904, 52715, 2, -5),
			new MyPoint(52742, -20933, -5, 2),
			new MyPoint(10659, -41973, -1, 4),
			new MyPoint(52707, -10416, -5, 1),
			new MyPoint(-41974, -10414, 4, 1),
			new MyPoint(-10379, -52493, 1, 5),
			new MyPoint(-41981, 10628, 4, -1),
			new MyPoint(-10403, -41976, 1, 4),
			new MyPoint(-52466, 31676, 5, -3),
			new MyPoint(52755, -20932, -5, 2),
			new MyPoint(-31425, -20932, 3, 2),
			new MyPoint(-10375, -41973, 1, 4),
			new MyPoint(42210, -41971, -4, 4),
			new MyPoint(21188, -20936, -2, 2),
			new MyPoint(-10371, -10415, 1, 1),
			new MyPoint(-31458, -10412, 3, 1),
			new MyPoint(-52454, -10413, 5, 1),
			new MyPoint(-31452, -20938, 3, 2),
			new MyPoint(21152, 52710, -2, -5),
			new MyPoint(-31453, -10411, 3, 1),
			new MyPoint(10631, 31667, -1, -3),
			new MyPoint(31667, 31671, -3, -3),
			new MyPoint(-31453, -20938, 3, 2),
			new MyPoint(-41963, 42188, 4, -4),
			new MyPoint(42238, 42189, -4, -4),
			new MyPoint(31681, -41980, -3, 4),
			new MyPoint(-41974, -52498, 4, 5),
			new MyPoint(-31445, 52717, 3, -5),
			new MyPoint(-52453, 10628, 5, -1),
			new MyPoint(-10384, 52713, 1, -5),
			new MyPoint(-10394, 31670, 1, -3),
			new MyPoint(42235, 42193, -4, -4),
			new MyPoint(42236, 31670, -4, -3),
			new MyPoint(-41982, 21154, 4, -2),
			new MyPoint(42234, 21151, -4, -2),
			new MyPoint(52743, -31457, -5, 3),
			new MyPoint(-20908, -52500, 2, 5),
			new MyPoint(10633, -10417, -1, 1),
			new MyPoint(10624, 10627, -1, -1),
			new MyPoint(31683, -31459, -3, 3),
			new MyPoint(-31453, 10627, 3, -1),
			new MyPoint(10682, -52492, -1, 5),
			new MyPoint(-10408, -10413, 1, 1),
			new MyPoint(-41946, -41977, 4, 4),
			new MyPoint(31706, -31452, -3, 3),
			new MyPoint(-52487, 10634, 5, -1),
			new MyPoint(-10371, -20932, 1, 2),
			new MyPoint(42222, 31673, -4, -3),
			new MyPoint(-10402, -31459, 1, 3),
			new MyPoint(10633, -20934, -1, 2),
			new MyPoint(-10377, -41975, 1, 4),
			new MyPoint(-52454, 42192, 5, -4),
			new MyPoint(42214, -41973, -4, 4),
			new MyPoint(-52447, 21148, 5, -2),
			new MyPoint(-31451, -20934, 3, 2),
			new MyPoint(42231, -52493, -4, 5),
			new MyPoint(-10368, -10415, 1, 1),
			new MyPoint(10656, -31453, -1, 3),
			new MyPoint(10635, 10625, -1, -1),
			new MyPoint(-10387, -52501, 1, 5),
			new MyPoint(42234, -41976, -4, 4),
			new MyPoint(-52466, 10633, 5, -1),
			new MyPoint(52760, 31667, -5, -3),
			new MyPoint(-10410, 31667, 1, -3),
			new MyPoint(-52469, 21150, 5, -2),
			new MyPoint(-52501, -10412, 5, 1),
			new MyPoint(21152, -31450, -2, 3),
			new MyPoint(-20938, -10412, 2, 1),
			new MyPoint(-31420, 10627, 3, -1),
			new MyPoint(-31416, -41980, 3, 4),
			new MyPoint(10671, -10409, -1, 1),
			new MyPoint(31666, -10411, -3, 1),
			new MyPoint(-31435, -31454, 3, 3),
			new MyPoint(42218, 10626, -4, -1),
			new MyPoint(10627, -10415, -1, 1),
			new MyPoint(31701, 21149, -3, -2),
			new MyPoint(21149, 31676, -2, -3),
			new MyPoint(-31437, 52709, 3, -5),
			new MyPoint(42242, -31452, -4, 3),
			new MyPoint(-41956, 10630, 4, -1),
			new MyPoint(-20907, 31669, 2, -3),
			new MyPoint(-20936, -20932, 2, 2),
			new MyPoint(-31441, -41976, 3, 4),
			new MyPoint(-20892, -41976, 2, 4),
			new MyPoint(42215, 42196, -4, -4),
			new MyPoint(-31432, -52500, 3, 5),
			new MyPoint(-52476, -20934, 5, 2),
			new MyPoint(21169, 52715, -2, -5),
			new MyPoint(-31445, 10632, 3, -1),
			new MyPoint(21189, 52709, -2, -5),
			new MyPoint(42214, -52499, -4, 5),
			new MyPoint(-20895, -41971, 2, 4),
			new MyPoint(21170, 21151, -2, -2),
			new MyPoint(-52490, 52711, 5, -5),
			new MyPoint(-41966, 10626, 4, -1),
			new MyPoint(52727, 42188, -5, -4),
			new MyPoint(10657, 31672, -1, -3),
			new MyPoint(21162, 21150, -2, -2),
			new MyPoint(52744, 10626, -5, -1),
			new MyPoint(-31436, 42195, 3, -4),
			new MyPoint(-31457, 31674, 3, -3),
			new MyPoint(10631, -41973, -1, 4),
			new MyPoint(21147, 42193, -2, -4),
			new MyPoint(52707, -52501, -5, 5),
			new MyPoint(10623, -52492, -1, 5),
			new MyPoint(-41974, -20935, 4, 2),
			new MyPoint(-41934, 10633, 4, -1),
			new MyPoint(21152, -31450, -2, 3),
			new MyPoint(21188, 31670, -2, -3),
			new MyPoint(-52455, 52711, 5, -5),
			new MyPoint(-20892, 21147, 2, -2),
			new MyPoint(-20924, 31673, 2, -3),
			new MyPoint(31665, 31668, -3, -3),
			new MyPoint(52720, -41979, -5, 4),
			new MyPoint(-20905, 21151, 2, -2),
			new MyPoint(42226, 31667, -4, -3),
			new MyPoint(42221, -20933, -4, 2),
			new MyPoint(31717, -20937, -3, 2),
			new MyPoint(52708, 42194, -5, -4),
			new MyPoint(-52442, -10408, 5, 1),
			new MyPoint(-41942, 31668, 4, -3),
			new MyPoint(21156, 52709, -2, -5),
			new MyPoint(-20932, -52499, 2, 5),
			new MyPoint(-41977, -10408, 4, 1),
			new MyPoint(-10371, 52713, 1, -5),
			new MyPoint(-20884, -10416, 2, 1),
			new MyPoint(-20915, -31456, 2, 3),
			new MyPoint(-31421, -31450, 3, 3),
			new MyPoint(-31419, 42192, 3, -4),
			new MyPoint(-10367, -31458, 1, 3),
			new MyPoint(-10410, -10417, 1, 1),
			new MyPoint(31716, -10415, -3, 1),
			new MyPoint(-52479, 52717, 5, -5),
			new MyPoint(10647, 52718, -1, -5),
			new MyPoint(-52471, -31450, 5, 3),
			new MyPoint(42210, 52710, -4, -5),
			new MyPoint(-52453, 31673, 5, -3),
			new MyPoint(42234, -10410, -4, 1),
			new MyPoint(-52459, -10411, 5, 1),
			new MyPoint(-52477, -31455, 5, 3),
			new MyPoint(52726, 31671, -5, -3),
			new MyPoint(21155, -10417, -2, 1),
			new MyPoint(31689, -52492, -3, 5),
			new MyPoint(-41966, -41976, 4, 4),
			new MyPoint(-20921, -31459, 2, 3),
			new MyPoint(31670, 52710, -3, -5),
			new MyPoint(-10363, -41977, 1, 4),
			new MyPoint(-20935, 10633, 2, -1),
			new MyPoint(31721, 52709, -3, -5),
			new MyPoint(-10386, -52495, 1, 5),
			new MyPoint(-10359, -10408, 1, 1),
			new MyPoint(42202, 10625, -4, -1),
			new MyPoint(-52455, -20933, 5, 2),
			new MyPoint(52711, 31670, -5, -3),
			new MyPoint(-10363, -20933, 1, 2),
			new MyPoint(21192, -20932, -2, 2),
			new MyPoint(31702, -31451, -3, 3),
			new MyPoint(-41966, -20933, 4, 2),
			new MyPoint(-10382, -20937, 1, 2),
			new MyPoint(42227, -52494, -4, 5),
			new MyPoint(31713, 10627, -3, -1),
			new MyPoint(42194, -10413, -4, 1),
			new MyPoint(21146, 42193, -2, -4),
			new MyPoint(-20889, -41973, 2, 4),
			new MyPoint(42223, 52718, -4, -5),
			new MyPoint(10671, -31456, -1, 3),
			new MyPoint(10668, -20929, -1, 2),
			new MyPoint(21188, -41977, -2, 4),
			new MyPoint(-41965, 10629, 4, -1),
			new MyPoint(-41957, 31669, 4, -3),
			new MyPoint(52728, -41980, -5, 4),
			new MyPoint(-10407, 21150, 1, -2),
			new MyPoint(-52463, 42197, 5, -4),
			new MyPoint(31681, 21150, -3, -2),
			new MyPoint(31681, 21154, -3, -2),
			new MyPoint(10652, 21155, -1, -2),
			new MyPoint(-41934, 42191, 4, -4),
			new MyPoint(10658, 21150, -1, -2),
			new MyPoint(42202, 52711, -4, -5),
			new MyPoint(-41926, -41971, 4, 4),
			new MyPoint(52752, 31668, -5, -3),
			new MyPoint(-52470, -20936, 5, 2),
			new MyPoint(10671, -10412, -1, 1),
			new MyPoint(-52503, -31450, 5, 3),
			new MyPoint(10623, -41979, -1, 4),
			new MyPoint(21173, 10633, -2, -1),
			new MyPoint(10656, -20931, -1, 2),
			new MyPoint(-31451, 42188, 3, -4),
			new MyPoint(42211, -52498, -4, 5),
			new MyPoint(-20899, -20931, 2, 2),
			new MyPoint(10647, 21146, -1, -2),
			new MyPoint(-41934, -52492, 4, 5),
			new MyPoint(-10386, -41977, 1, 4),
			new MyPoint(31670, -52492, -3, 5),
			new MyPoint(-41930, -31451, 4, 3),
			new MyPoint(-10363, 52711, 1, -5),
			new MyPoint(31689, -10416, -3, 1),
			new MyPoint(-52447, -52501, 5, 5),
			new MyPoint(-41931, 52716, 4, -5),
			new MyPoint(-41934, 42189, 4, -4),
			new MyPoint(-20892, -41977, 2, 4),
			new MyPoint(52725, 52709, -5, -5),
			new MyPoint(52720, -10414, -5, 1),
			new MyPoint(-41962, -31459, 4, 3),
			new MyPoint(-20937, 31671, 2, -3),
			new MyPoint(31669, -10414, -3, 1),
			new MyPoint(52755, -41979, -5, 4),
			new MyPoint(-41926, -52495, 4, 5),
			new MyPoint(52744, 42189, -5, -4),
			new MyPoint(-10403, 52717, 1, -5),
			new MyPoint(31681, 42194, -3, -4),
			new MyPoint(-52471, 42197, 5, -4),
			new MyPoint(-10390, -52501, 1, 5),
			new MyPoint(21185, 21149, -2, -2),
			new MyPoint(10651, -41978, -1, 4),
			new MyPoint(-20884, 42189, 2, -4),
			new MyPoint(10676, 21146, -1, -2),
			new MyPoint(-31453, -20930, 3, 2),
			new MyPoint(42214, 21153, -4, -2),
			new MyPoint(21152, 31674, -2, -3),
			new MyPoint(-52487, -52496, 5, 5),
			new MyPoint(52739, 42189, -5, -4),
			new MyPoint(52717, 42188, -5, -4),
			new MyPoint(10679, 21146, -1, -2),
			new MyPoint(31686, -10417, -3, 1),
			new MyPoint(-31405, -10408, 3, 1),
			new MyPoint(42234, 42195, -4, -4),
			new MyPoint(31715, -31453, -3, 3),
			new MyPoint(-31453, 42190, 3, -4),
			new MyPoint(42229, 10630, -4, -1),
			new MyPoint(42191, 10626, -4, -1),
			new MyPoint(-31432, -20929, 3, 2),
			new MyPoint(-20884, 10626, 2, -1),
			new MyPoint(-52470, -41978, 5, 4),
			new MyPoint(52766, -41971, -5, 4),
			new MyPoint(-31429, 52717, 3, -5),
			new MyPoint(-41921, 31676, 4, -3),
			new MyPoint(-31424, 21146, 3, -2),
			new MyPoint(10650, -20933, -1, 2),
			new MyPoint(-31434, -52496, 3, 5),
			new MyPoint(21194, -41974, -2, 4),
			new MyPoint(21147, 42192, -2, -4),
		};

		static void DrawImage(int second)
		{
			var minX = Math.Abs(MyPoints.Min(c => c.X)) + 1;
			var minY = Math.Abs(MyPoints.Min(c => c.Y)) + 1;
			var maxX = Math.Abs(MyPoints.Max(c => c.X));
			var maxY = Math.Abs(MyPoints.Max(c => c.Y));
			var minXPx = 0;
			var minYPx = 0;
			var maxXPx = minX + maxX;
			var maxYPx = minY + maxY;

			try
			{
				using (var pic = new Bitmap(maxXPx + 10, maxYPx + 10))
				{
					foreach (var myPoint in MyPoints)
					{
						pic?.SetPixel((myPoint.X + minX), (myPoint.Y + minY), Color.Black);
					}

					pic.Save($"{second}.png", ImageFormat.Png);
				}
			}
			catch (Exception)
			{
			}

		}

		static void Main(string[] args)
		{
			Console.WriteLine("Advent of Code Day 10!");

			for (var second = 0; second < 10600; second++)
			{
				foreach (var myPoint in MyPoints)
				{
					myPoint.Y += myPoint.YVelocity;
					myPoint.X += myPoint.XVelocity;
				}

				if (second > 10500 && second < 10600)
					DrawImage(second);
			}

			Console.WriteLine("Star 1: 'XPFXXKL'. Open file '10520.png'");
			Console.WriteLine("This answer was found by generating loads of images and checking for the one with the lowest size.");

			Console.ReadLine();
		}
	}
}