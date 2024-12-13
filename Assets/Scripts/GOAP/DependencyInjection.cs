using CrashKonijn.Goap.Runtime;
using CrashKonijn.Goap.Core;
using CrashKonijn.Agent.Runtime;
using CrashKonijn.Agent.Core;

namespace COMP396.Goap
{
	public class DependencyInjection : GoapConfigInitializerBase, IGoapInjector
	{
		public WanderStatsSO wanderStats;
		public override void InitConfig(IGoapConfig config)
		{
			config.GoapInjector = this;
		}

		public void Inject(IAction action)
		{
			if (action is IInjectable injectable)
			{
				injectable.Inject(this);
			}
		}

		public void Inject(IGoal goal)
		{
			if (goal is IInjectable injectable)
			{
				injectable.Inject(this);
			}
		}

		public void Inject(IWorldSensor worldSensor)
		{
			if (worldSensor is IInjectable injectable)
			{
				injectable.Inject(this);
			}
		}

		public void Inject(ITargetSensor targetSensor)
		{
			if (targetSensor is IInjectable injectable)
			{
				injectable.Inject(this);
			}
		}

		public void Inject(ISensor sensor)
		{
			if (sensor is IInjectable injectable)
			{
				injectable.Inject(this);
			}
		}
	}
}
