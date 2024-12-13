using System;
using CrashKonijn.Goap.Runtime;
using CrashKonijn.Goap.Core;
using CrashKonijn.Agent.Runtime;
using CrashKonijn.Agent.Core;
using CrashKonijn.Goap.Resolver;

namespace COMP396.Goap
{
	public class CapabilityConfigFactory : CapabilityFactoryBase
	{
		public override ICapabilityConfig Create()
		{
			var factory = new CapabilityBuilder("COMP396");

			factory.AddGoal<WanderGoal>().AddCondition<IsWandering>(Comparison.GreaterThanOrEqual, 1);
			factory.AddAction<WanderAction>()
				.SetTarget<WanderTarget>()
				.AddEffect<IsWandering>(EffectType.Increase)
				.SetBaseCost(5)
				.SetStoppingDistance(10);
			factory.AddTargetSensor<WanderTargetSensor>()
				.SetTarget<WanderTarget>();

			return factory.Build();
		}
	}
}