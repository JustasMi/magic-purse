using System.Collections.Generic;

namespace MagicPurse.Interfaces
{
	public interface IPossibilityCalculator
	{
		long Calculate(List<List<double>> combinations);
	}
}