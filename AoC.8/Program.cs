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

		public int MetadataSum
		{
			get
			{
				var sum = Metadata.Sum();

				foreach (var childNode in ChildNodes)
				{
					sum += childNode.MetadataSum;
				}

				return sum;
			}
		}

		public int NodeSum
		{
			get
			{
				if (!ChildNodes.Any())
					return Metadata.Sum();

				var sum = 0;
				foreach (var metadata in Metadata)
				{
					if (metadata > 0 && metadata <= ChildNodes.Count)
					{
						sum += ChildNodes[metadata - 1].NodeSum;
					}
				}

				return sum;
			}
		}

		public List<int> Sequence { get; set; }

		public static Node FillNode(Node node)
		{
			var nrSubNodes = node.Sequence.First();
			var nrMetadata = node.Sequence.Skip(1).First();

			node.Sequence = node.Sequence.Skip(2).ToList();
			for (int i = 0; i < nrSubNodes; i++)
			{
				var childNode = FillNode(new Node {Sequence = node.Sequence});
				node.ChildNodes.Add(childNode);
				node.Sequence = childNode.Sequence;
			}

			if (nrMetadata == 0)
				throw new Exception("Metadata must contain on or more elements");

			for (int i = 0; i < nrMetadata; i++)
			{
				node.Metadata.Add(node.Sequence.First());
				node.Sequence = node.Sequence.Skip(1).ToList();
			}

			return node;
		}
	}

	class Program
	{
		static void Main()
		{
			Console.WriteLine("Advent of Code Day 8!");

			var sequence = System.IO.File.ReadAllText("input.txt").Split(',').Select(Parse).ToList();

			var firstNode = new Node();
			firstNode.Sequence = sequence;
			Node.FillNode(firstNode);

			Console.WriteLine($"Star 1 Metadata Sum: {firstNode.MetadataSum}");
			Console.WriteLine($"Star 2 Node Sum: {firstNode.NodeSum}");

			Console.ReadLine();
		}
	}
}