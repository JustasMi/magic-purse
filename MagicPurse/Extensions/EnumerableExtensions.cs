using System;
using System.Collections.Generic;

namespace MagicPurse.Extensions
{
	public static class EnumerableExtensions
	{
		public static IEnumerable<T> Replace<T>(this IEnumerable<T> items, T find, T replace)
		{
			if (find == null)
			{
				throw new ArgumentNullException("find");
			}

			foreach (T item in items)
			{
				if (object.Equals(find, item))
				{
					yield return replace;
				}
				else
				{
					yield return item;
				}
			}
		}
	}
}