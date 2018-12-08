using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC._7
{
	public class Dependency
	{
		public char ObservedChar { get; set; }
		public char DependsOnChar { get; set; }

		public Dependency(char value, char dependency)
		{
			ObservedChar = value;
			DependsOnChar = dependency;
		}
	}

	class Program
	{
		public static List<Dependency> Dependencies = new List<Dependency>
		{
			new Dependency('F', 'Q'),
			new Dependency('A', 'K'),
			new Dependency('K', 'R'),
			new Dependency('D', 'X'),
			new Dependency('L', 'T'),
			new Dependency('V', 'W'),
			new Dependency('J', 'N'),
			new Dependency('B', 'W'),
			new Dependency('X', 'C'),
			new Dependency('W', 'I'),
			new Dependency('Q', 'P'),
			new Dependency('E', 'M'),
			new Dependency('C', 'N'),
			new Dependency('U', 'O'),
			new Dependency('O', 'R'),
			new Dependency('N', 'Z'),
			new Dependency('R', 'I'),
			new Dependency('G', 'H'),
			new Dependency('T', 'H'),
			new Dependency('M', 'P'),
			new Dependency('Y', 'I'),
			new Dependency('S', 'Z'),
			new Dependency('I', 'H'),
			new Dependency('H', 'P'),
			new Dependency('P', 'Z'),
			new Dependency('Y', 'P'),
			new Dependency('A', 'O'),
			new Dependency('V', 'O'),
			new Dependency('G', 'Y'),
			new Dependency('K', 'B'),
			new Dependency('I', 'P'),
			new Dependency('D', 'L'),
			new Dependency('A', 'P'),
			new Dependency('O', 'T'),
			new Dependency('F', 'C'),
			new Dependency('M', 'S'),
			new Dependency('V', 'Q'),
			new Dependency('G', 'I'),
			new Dependency('O', 'I'),
			new Dependency('N', 'I'),
			new Dependency('E', 'O'),
			new Dependency('N', 'S'),
			new Dependency('J', 'H'),
			new Dependency('C', 'P'),
			new Dependency('E', 'N'),
			new Dependency('T', 'P'),
			new Dependency('A', 'G'),
			new Dependency('A', 'V'),
			new Dependency('C', 'H'),
			new Dependency('A', 'Y'),
			new Dependency('E', 'U'),
			new Dependency('T', 'Y'),
			new Dependency('Q', 'S'),
			new Dependency('Y', 'S'),
			new Dependency('E', 'P'),
			new Dependency('N', 'T'),
			new Dependency('T', 'M'),
			new Dependency('Q', 'M'),
			new Dependency('H', 'Z'),
			new Dependency('D', 'Y'),
			new Dependency('J', 'R'),
			new Dependency('U', 'R'),
			new Dependency('K', 'N'),
			new Dependency('A', 'W'),
			new Dependency('A', 'H'),
			new Dependency('X', 'G'),
			new Dependency('V', 'J'),
			new Dependency('W', 'C'),
			new Dependency('I', 'Z'),
			new Dependency('V', 'H'),
			new Dependency('R', 'H'),
			new Dependency('U', 'N'),
			new Dependency('O', 'Z'),
			new Dependency('X', 'S'),
			new Dependency('E', 'G'),
			new Dependency('W', 'U'),
			new Dependency('U', 'G'),
			new Dependency('D', 'Z'),
			new Dependency('E', 'R'),
			new Dependency('L', 'B'),
			new Dependency('B', 'R'),
			new Dependency('G', 'T'),
			new Dependency('F', 'K'),
			new Dependency('R', 'S'),
			new Dependency('J', 'Z'),
			new Dependency('Q', 'U'),
			new Dependency('X', 'O'),
			new Dependency('F', 'I'),
			new Dependency('W', 'R'),
			new Dependency('W', 'Y'),
			new Dependency('M', 'Y'),
			new Dependency('S', 'I'),
			new Dependency('F', 'O'),
			new Dependency('C', 'Y'),
			new Dependency('N', 'G'),
			new Dependency('O', 'S'),
			new Dependency('Q', 'O'),
			new Dependency('K', 'T'),
			new Dependency('X', 'Z'),
			new Dependency('L', 'N'),
			new Dependency('S', 'P'),
		};

		//public static readonly List<Dependency> Dependencies = new List<Dependency>
		//{
		//	new Dependency('C', 'F'),
		//	new Dependency('C', 'A'),
		//	new Dependency('A', 'B'),
		//	new Dependency('A', 'D'),
		//	new Dependency('B', 'E'),
		//	new Dependency('D', 'E'),
		//	new Dependency('F', 'E'),
		//};

		static void Main(string[] args)
		{
			Console.WriteLine("Advent of Code Day 7!");

			var startingPoints = Dependencies.Select(c => c.ObservedChar).Except(Dependencies.Select(c => c.DependsOnChar));

			Console.ReadLine();
		}
	}
}