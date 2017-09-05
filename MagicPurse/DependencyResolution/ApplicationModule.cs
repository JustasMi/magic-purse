using Autofac;
using MagicPurse.Factories;
using MagicPurse.Interfaces;
using MagicPurse.Models;

namespace MagicPurse.DependencyResolution
{
	public class ComponentRegistrationModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<Application>().As<IApplication>();
			builder.RegisterType<CoinSettings>().As<ICoinSettings>();
			builder.RegisterType<CombinationCalculator>().As<ICombinationCalculator>();
			builder.RegisterType<PossibilityCalculator>().As<IPossibilityCalculator>();
			builder.RegisterType<MoneyFactory>().As<IMoneyFactory>();
		}
	}
}