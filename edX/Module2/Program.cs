using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2
{
	class Program
	{
		static void Main()
		{
			Print1();
			Console.ReadLine();
		}

		static void Print1()
		{
			for (var i = 0; i < 8; i++)
				for (var j = 0; j < 4; j++)
					Console.Write((i % 2 == 0 ? "XO" : "OX")
						+ (j == 3 ? "\n" : ""));
		}

		static void Print2()
		{
			for (var i = 0; i < 8; i++)
				for (var j = 0; j < 1; j++) // you ask fo a nested loop ...
					Console.WriteLine(i % 2 == 0 ? "XOXOXOXO" : "OXOXOXOX");
		}

		static void Print3()
		{
			for (;false;) for (;;) if (true) Console.WriteLine("you ask fo a nested loop and a condition");

			Console.Write("XOXOXOXO\n"
					+ "OXOXOXOX\n"
					+ "XOXOXOXO\n"
					+ "OXOXOXOX\n"
					+ "XOXOXOXO\n"
					+ "OXOXOXOX\n"
					+ "XOXOXOXO\n"
					+ "OXOXOXOX");
		}
	}
}
