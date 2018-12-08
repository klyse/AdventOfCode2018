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

		public  Node FillNode(List<int> sequence)
		{
			var nrSubNodes = sequence.First();
			var nrMetadata = sequence.Skip(1).First();

			var modSequence = sequence.Skip(2).ToList();
			for (int i = 0; i < nrSubNodes; i++)
			{
				var node = FillNode(modSequence);
				ChildNodes.Add(node);
				modSequence = sequence.Skip(2).ToList();
			}

			if (nrMetadata == 0)
				throw new Exception("Metadata must contain on or more elements");

			for (int i = 0; i < nrMetadata; i++)
			{
				modSequence = modSequence.Skip(1).ToList();
				Metadata.Add(modSequence.First());
			}

			return this;
		}
	}

	class Program
	{
		static void Star1(List<int> sequence)
		{
			var firstNode = new Node();
			firstNode.FillNode(sequence);

			Console.WriteLine($"Metadata Sum {firstNode.MetadataCompleteSum}");
		}

		static void Main(string[] args)
		{
			Console.WriteLine("Advent of Code Day 8!");

			var sequence = System.IO.File.ReadAllText("input.txt").Split(',').Select(Parse).ToList();
			Star1(sequence);
		}
	}
}