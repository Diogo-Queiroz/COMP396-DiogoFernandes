using UnityEngine;
using CrashKonijn.Goap.Runtime;
using CrashKonijn.Goap.Core;
using CrashKonijn.Agent.Runtime;
using CrashKonijn.Agent.Core;

namespace COMP396.Goap
{
	public class WanderAction : GoapActionBase<WanderAction.Data>, IInjectable
	{
		public WanderStatsSO wanderStats;
		public class Data : IActionData
		{
			public ITarget Target { get; set; }
			public float Timer { get; set; }
		}
		public override void Created() { }
		
		public override void Start(IMonoAgent agent, Data data)
		{
			data.Timer = Random.Range(wanderStats.MinTimeBetweenWandering, wanderStats.MaxTimeBetweenWandering);
		}
		public override IActionRunState Perform(IMonoAgent agent, Data data, IActionContext context)
		{
			data.Timer -= context.DeltaTime;
			if (data.Timer > 0)
			{
				return ActionRunState.Continue;
			}
			return ActionRunState.Stop;
		}

		public override void End(IMonoAgent agent, Data data) { }

		public void Inject(DependencyInjection injection)
		{
			wanderStats = injection.wanderStats;
		}
	}
}