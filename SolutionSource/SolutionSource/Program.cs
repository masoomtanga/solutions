using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionSource
{
	class Program
	{
		static void Main(string[] args)
		{
			var a = new[] { "abcd", "efgh", "defa", "jkno" };
			var b = new[] { "cdab", "gehf", "efad", "nojk" };
			Crossover1.EqualityCheck(a, b);
		}
	}
}
