using System;
using CrashKonijn.Goap.Runtime;
using CrashKonijn.Goap.Core;
using CrashKonijn.Agent.Runtime;
using CrashKonijn.Agent.Core;
using KBCore.Refs;
using UnityEngine;
using UnityEngine.AI;

namespace COMP396.Goap
{
	[RequireComponent(typeof(NavMeshAgent))]
	[RequireComponent(typeof(AgentBehaviour))]
	public class AgentMoveBehaviour : ValidatedMonoBehaviour
	{
		[Header("References")]
		[SerializeField, Self] private NavMeshAgent agent;
		[SerializeField, Self] private Animator animator;
		[SerializeField, Self] private AgentBehaviour behaviour;

		[Header("Variables")]
		[SerializeField] private float MinMoveDistance = 0.25f;
		private ITarget currentTarget;
		private Vector3 lastPosition;
		private static readonly int Speed = Animator.StringToHash("Speed");

		private void OnEnable()
		{
			behaviour.Events.OnTargetChanged += TargetChanged;
		}

		private void OnDisable()
		{
			behaviour.Events.OnTargetChanged -= TargetChanged;
		}

		private void TargetChanged(ITarget target, bool inRange)
		{
			currentTarget = target;
			lastPosition = currentTarget.Position;
			agent.SetDestination(currentTarget.Position);
		}

		private void Update()
		{
			animator.SetFloat(Speed, agent.velocity.magnitude);
			if (currentTarget == null) { return; }
			if (MinMoveDistance <= Vector3.Distance(currentTarget.Position, lastPosition))
			{
				lastPosition = currentTarget.Position;
				agent.SetDestination(lastPosition);
			}
		}
	}
}