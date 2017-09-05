namespace MagicPurse.Interfaces
{
	public interface ICurrencyFactory
	{
		Currency Build(string currency);
	}
}