using PlanetSystem;
using PlayerSystem;
using PursuerSystem;
using UISystem;
using VContainer;
using VContainer.Unity;

namespace Core
{
	public class BootStarter : LifetimeScope
	{
		protected override void Configure(IContainerBuilder builder)
		{
			builder.Register<PlanetController>(Lifetime.Scoped); 
			builder.Register<UIController>(Lifetime.Scoped); 
			builder.Register<PlayerController>(Lifetime.Scoped).As<PlayerController, IFixedTickable>(); 
			builder.Register<PursuerController>(Lifetime.Scoped).As<PursuerController, IFixedTickable, ITickable>();
		}
	}
}
