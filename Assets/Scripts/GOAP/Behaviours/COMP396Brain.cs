using CrashKonijn.Goap.Runtime;
using CrashKonijn.Goap.Core;
using CrashKonijn.Agent.Runtime;
using CrashKonijn.Agent.Core;
using KBCore.Refs;
using UnityEngine;

namespace COMP396.Goap
{
	[RequireComponent(typeof(GoapActionProvider))]
	public class COMP396Brain : ValidatedMonoBehaviour
	{
		[SerializeField, Self] private GoapActionProvider brain;
		[SerializeField, Scene] private GoapBehaviour runner;

		private void Awake()
		{
			brain.AgentType = runner.GetAgentType("COMP396-Agent");
		}

		private void Start()
		{
			brain.RequestGoal<WanderGoal>(false);
		}
	}
}