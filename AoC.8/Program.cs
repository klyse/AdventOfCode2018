using System;
using System.Collections.Generic;
using System.Linq;
using static System.Int32;

namespace AoC._8
{
	public class Node
	{
		public List<Node> ChildNodes { get; set; } = new List<Node>();

		public List<int> Metadata { get; set; } = new List<int>();

		public bool HasChildNodes => ChildNodes.Any();

		public int MetadataSum => Metadata.Sum();

		public int MetadataCompleteSum
		{
			get
			{
				var sum = MetadataSum;

				foreach (var childNode in ChildNodes)
				{
					sum += childNode.MetadataCompleteSum;
				}

				return sum;
			}
		}
	}

	class Program
	{
		static void Star1(List<int> sequence)
		{
		}

		static void Main(string[] args)
		{
			Console.WriteLine("Advent of Code Day 8!");

			var Sequence = System.IO.File.ReadAllText("input.txt").Split(',').Select(Parse).ToList();
		}
	}
}