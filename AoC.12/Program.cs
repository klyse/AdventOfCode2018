using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace AoC._12
{
	public class Rule
	{
		public bool[] RuleSet { get; set; } = new bool[5];
		public bool Result { get; set; }

		public static Rule GetRule(string input)
		{
			var rule = new Rule();

			rule.RuleSet[0] = input[0] == '#';
			rule.RuleSet[1] = input[1] == '#';
			rule.RuleSet[2] = input[2] == '#';
			rule.RuleSet[3] = input[3] == '#';
			rule.RuleSet[4] = input[4] == '#';

			rule.Result = input[9] == '#';

			return rule;
		}
	}

	public class Pot
	{
		public bool ContainsFlower { get; set; }
		public long Index { get; set; }

		public bool Center { get; set; }
	}

	public class Program
	{
		public static string SequenceInput { get; } = "#...####.##..####..#.##....##...###.##.#..######..#..#..###..##.#.###.#####.##.#.#.#.##....#..#..#..";

		//public static string SequenceInput { get; } = "#..#.#..##......###...###";

		public static List<Pot> Sequence { get; } = new List<Pot>();

		public static List<string> RulesInput { get; } = new List<string>
		{
			"...## => .",
			"...#. => #",
			"....# => .",
			"###.# => #",
			"..... => .",
			"..#.. => .",
			"#.#.# => .",
			"#..#. => .",
			"#...# => .",
			"##... => .",
			".#.#. => #",
			".#..# => .",
			".###. => .",
			"#..## => #",
			"..#.# => #",
			".#### => #",
			"##..# => #",
			"##.#. => #",
			".#... => #",
			"#.#.. => .",
			"##### => .",
			"###.. => #",
			".##.# => .",
			"#.##. => .",
			"..### => .",
			".#.## => #",
			"..##. => #",
			"#.### => .",
			".##.. => #",
			"##.## => .",
			"#.... => .",
			"####. => #",
		};

		//public static List<string> RulesInput { get; } = new List<string>
		//{
		//	"...## => #",
		//	"..#.. => #",
		//	".#... => #",
		//	".#.#. => #",
		//	".#.## => #",
		//	".##.. => #",
		//	".#### => #",
		//	"#.#.# => #",
		//	"#.### => #",
		//	"##.#. => #",
		//	"##.## => #",
		//	"###.. => #",
		//	"###.# => #",
		//	"####. => #",
		//};

		public static List<Rule> Rules { get; } = new List<Rule>();

		private static long _evolutionCount = 0;

		public static List<Pot> Evolution(List<Pot> sequence, long maxEvolution)
		{
			var firstIndexWithFlower = sequence.FindIndex(c => c.ContainsFlower);
			for (var i = 0; i < 4 - firstIndexWithFlower; i++)
				sequence.Insert(0, new Pot());

			var lastIndexWithFlower = sequence.FindLastIndex(c => c.ContainsFlower);
			var addNrFlowers = 5 - (sequence.Count - lastIndexWithFlower);
			for (var i = 0; i < addNrFlowers; i++)
				sequence.Add(new Pot());


			var newSequence = sequence.Select(c => new Pot()).ToList();
			for (var i = 2; i < sequence.Count - 2; i++)
			{
				newSequence[i].Center = sequence[i].Center;

				foreach (var rule in Rules)
				{
					if (
						sequence[i - 2].ContainsFlower == rule.RuleSet[0] &&
						sequence[i - 1].ContainsFlower == rule.RuleSet[1] &&
						sequence[i].ContainsFlower == rule.RuleSet[2] &&
						sequence[i + 1].ContainsFlower == rule.RuleSet[3] &&
						sequence[i + 2].ContainsFlower == rule.RuleSet[4]
					)
					{
						newSequence[i].ContainsFlower = rule.Result;
					}
				}
			}

			long index = newSequence.FindIndex(c => c.Center) * -1;

			foreach (var t in newSequence)
			{
				t.Index = index;
				index++;
			}

			_evolutionCount++;


			if (_evolutionCount >= maxEvolution)
			{
				return newSequence;
			}

			return Evolution(newSequence, maxEvolution);
		}

		static void Main()
		{
			Console.WriteLine("Advent of Code Day 12!");

			foreach (var rule in RulesInput)
			{
				Rules.Add(Rule.GetRule(rule));
			}

			var first = true;
			foreach (var input in SequenceInput)
			{
				Sequence.Add(new Pot {Center = first, ContainsFlower = input == '#'});
				first = false;
			}

			var evolution1 = Evolution(Sequence.Select(c => c).ToList(), 20);
			Console.WriteLine($"Star 1: {evolution1.Where(c => c.ContainsFlower).Sum(c => c.Index)}");

			Console.ReadLine();
		}
	}
}