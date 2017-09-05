using System.Collections.Generic;

namespace MagicPurse.Interfaces
{
	public interface ICombinationCalculator
	{
		List<List<double>> Calculate(Money money);
	}
}