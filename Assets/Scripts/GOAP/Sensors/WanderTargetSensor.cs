using CrashKonijn.Goap.Runtime;
using CrashKonijn.Goap.Core;
using CrashKonijn.Agent.Runtime;
using CrashKonijn.Agent.Core;
using UnityEngine;
using UnityEngine.AI;

namespace COMP396.Goap
{
	public class WanderTargetSensor : LocalTargetSensorBase, IInjectable
	{
		private WanderStatsSO wanderStats;

		public override void Created() { }
		public override void Update() { }


		public override ITarget Sense(IActionReceiver agent, IComponentReference references, ITarget target)
		{
			Vector3 position = GetRandomPosition(agent);

			return new PositionTarget(position);
		}

		private Vector3 GetRandomPosition(IActionReceiver agent)
		{
			for (int i = 0; i < 5; i++)
			{
				Vector2 random = Random.insideUnitSphere * wanderStats.WanderingRadius;
				Vector3 position = agent.Transform.position + 
					new Vector3(random.x, -0.82f, random.y);
				
				if (NavMesh.SamplePosition(position, out NavMeshHit hit, 1, NavMesh.AllAreas))
				{
					return hit.position;
				}
			}
			return agent.Transform.position;
		}

		public void Inject(DependencyInjection injection)
		{
			wanderStats = injection.wanderStats;
		}
	}
}