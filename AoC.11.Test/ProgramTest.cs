using System;
using NUnit.Framework;

namespace AoC._11.Test
{
	[TestFixture]
	public class ProgramTest
	{
		[TestCase(8, 3, 5, ExpectedResult = 4)]
		[TestCase(57, 122, 79, ExpectedResult = -5)]
		[TestCase(39, 217, 196, ExpectedResult = 0)]
		[TestCase(71, 101, 153, ExpectedResult = 4)]
		public object CalculateMatrix_TakesParameterAndReturnsMatrixAtPos(int serialNr, int x, int y)
		{
			var grid = Program.CalculateMatrix(serialNr);

			return grid[x, y];
		}
	}
}