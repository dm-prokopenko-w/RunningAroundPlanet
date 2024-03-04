using UnityEngine;
using UnityEngine.AI;

namespace PursuerSystem
{
	public struct PursuerItem
	{
		public Rigidbody RB;
		public Animator Anim;
		public NavMeshAgent Agent;
		public Transform View;
	}
}