using Autofac;
using MagicPurse.DependencyResolution;
using MagicPurse.Interfaces;

namespace MagicPurse
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			ContainerBuilder containerBuilder = new ContainerBuilder();
			containerBuilder.RegisterModule(new ComponentRegistrationModule());

			IContainer container = containerBuilder.Build();

			using (ILifetimeScope scope = container.BeginLifetimeScope())
			{
				IApplication application = scope.Resolve<IApplication>();
				application.Run();
			}
		}
	}
}