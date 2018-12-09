using NUnit.Framework;
using AoC._9;

namespace AoC._9.Test
{
	[TestFixture]
	public class ProgramTest
	{
		[TestCase(10, 1618, ExpectedResult = 8317)]
		[TestCase(13, 7999, ExpectedResult = 146373)]
		[TestCase(17, 1104, ExpectedResult = 2764)]
		[TestCase(21, 6111, ExpectedResult = 54718)]
		[TestCase(30, 5807, ExpectedResult = 37305)]
		public object CalculateWinningElveScore_TakesParamAndReturnsWinningElveScore(int nrElves, int nrMarbles)
		{
			return Program.CalculateWinningElveScore(nrElves, nrMarbles);
		}
	}
}