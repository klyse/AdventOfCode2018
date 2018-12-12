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

		[TestCase(18, ExpectedResult = 33)]
		[TestCase(42, ExpectedResult = 21)]
		public object GetBoxSum_TakesParamsAndCalculatesBiggestSum_ReturnsXValue(int serialNr)
		{
			var grid = Program.CalculateMatrix(serialNr);

			var res = Program.GetBoxSum(grid, 3, 3);

			return res.x;
		}

		[TestCase(18, ExpectedResult = 45)]
		[TestCase(42, ExpectedResult = 61)]
		public object GetBoxSum_TakesParamsAndCalculatesBiggestSum_ReturnsYValue(int serialNr)
		{
			var grid = Program.CalculateMatrix(serialNr);

			var res = Program.GetBoxSum(grid, 3, 3);

			return res.y;
		}

		[TestCase(18, ExpectedResult = 29)]
		[TestCase(42, ExpectedResult = 30)]
		public object GetBoxSum_TakesParamsAndCalculatesBiggestSum_ReturnsSum(int serialNr)
		{
			var grid = Program.CalculateMatrix(serialNr);

			var res = Program.GetBoxSum(grid, 3, 3);

			return res.maxSum;
		}
	}
}