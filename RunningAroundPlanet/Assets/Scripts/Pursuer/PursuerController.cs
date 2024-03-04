using UnityEngine;
using Core;
using UnityEngine.AI;
using PlayerSystem;
using VContainer;
using VContainer.Unity;
using PlanetSystem;

namespace PursuerSystem
{
	public class PursuerController : IFixedTickable, ITickable
	{
		[Inject] private PlayerController _player;
		[Inject] private PlanetController _planet;

		private NavMeshAgent _agent;
		private Transform _view;
		private Vector3 _dir;
		private Animator _anim;
		private bool _isInit = false;

		public void Init(PursuerItem item)
		{
			_view = item.View;
			_agent = item.Agent;
			_anim = item.Anim;
			_isInit = true;
		}

		public void FixedTick()
		{
			if (!_isInit) return;

			_view.transform.position = Vector3.MoveTowards(
				_view.transform.position,
				_agent.transform.position,
				Time.deltaTime * Constants.PursuerSpeed);

			LookAtPlayer();
		}

		public void Tick()
		{
			if (!_isInit) return;

			if ((_agent.transform.position - _player.PlayerTran.position).magnitude > Constants.MinDisToPlayer)
			{
				_agent.SetDestination(_player.PlayerTran.position);
			}
			else
			{
				_agent.ResetPath();
			}
		}

		private void LookAtPlayer()
		{
			if ((_agent.transform.position - _view.transform.position).magnitude > 0.5f)
			{
				_anim.SetFloat("Y", 2.5f);
				_dir = (_agent.transform.position - _view.position).normalized;
			}
			else
			{
				_anim.SetFloat("Y", 0);
				_dir = (_player.PlayerTran.position - _view.position).normalized;
			}

			Quaternion _rot = Quaternion.FromToRotation(_view.forward, _dir) * _view.rotation;
			_view.rotation = Quaternion.Slerp(_view.rotation, _rot, 1);

			Vector3 toPlanetDirection = (_view.position - _planet.PlanetTr.position).normalized;
			Quaternion targetRotation = Quaternion.FromToRotation(_view.up, toPlanetDirection) * _view.rotation;
			_view.rotation = Quaternion.Slerp(_view.rotation, targetRotation, 1);
		}
	}
}