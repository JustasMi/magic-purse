using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicPurse.Tests
{
	[TestFixture(Category = "Calculator", Description = "XCalculator")]
	public class SomethingTests
	{
		[Test(Description = "What test")]
		public void test()
		{
			Assert.IsTrue(true);
		}
	}
}