using Core;
using UnityEngine;
using UnityEngine.AI;
using VContainer;

namespace PursuerSystem
{
	public class PursuerView : Character
	{
		[Inject] private PursuerController _pursuer;

		[SerializeField] private NavMeshAgent _agent;

		public override void Start()
		{
			PursuerItem item = new()
			{
				//RB = _rb,
				Agent = _agent,
				Anim = _anim,
				View = transform
			};

			_pursuer.Init(item);
		}
	}
}
