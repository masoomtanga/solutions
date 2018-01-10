using System.Collections.Generic;
using System.Linq;

namespace SolutionSource
{
	/// <summary>
	/// Two strings , a and b, are said to be twins only if they can be made equivalent
	/// by performing SwapEven and SwapOdd
	/// </summary>
	public class Crossover1
	{

		public static void EqualityCheck(IReadOnlyCollection<string> a, IReadOnlyList<string> b)
		{
			var result = new List<string>(a.Count);
			result.AddRange(a.Select((t, i) => PerformComparison(t, b[i])).Select(swapSuccess => swapSuccess ? "Yes" : "No"));
		}
		private static bool PerformComparison(string a, string b)
		{
			if (a.Length != b.Length) return false;
			if (a == b) return false;
			for (var i = 0; i < a.Length; i++)
			{
				const char placeholder = '~';
				var indexInB = b.IndexOf(a[i]);
				if (indexInB == -1 || b[i] == a[i]) continue;
				var temp = b[i];
				var t = indexInB % 2;
				if (t == 0 && i % 2 == 0)
				{

					b = b.Replace(b[i], placeholder).Replace(a[i], temp).Replace(placeholder, a[i]);

				}
				else if (t != 0 && i % 2 != 0)
				{

					b = b.Replace(b[i], placeholder).Replace(a[i], temp).Replace(placeholder, a[i]);
				}
			}

			return a == b;
		}
	}
}
