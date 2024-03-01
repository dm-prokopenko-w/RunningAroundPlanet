using UnityEngine;
using Core;
using UnityEngine.AI;
using PlayerSystem;
using static UnityEditor.PlayerSettings;

namespace PursuerSystem
{
	public class Pursuer : Character
	{
		[SerializeField] private NavMeshAgent _agent;
		[SerializeField] private Player _player;
		[SerializeField] private PursuerView _view;

		private bool _isMoving = true;
		private Vector3 _lastPlayerPos;
		private float _dist;

		private void Start()
		{
			_player.OnPlayerPos += MoveToPlayer;
			_view.OnMoving += Moving;
		}

		private void OnDestroy()
		{
			_player.OnPlayerPos -= MoveToPlayer;
			_view.OnMoving -= Moving;
		}

		private void MoveToPlayer(Vector3 pos)
		{
			_lastPlayerPos = pos;
		}

		private void Moving(bool value)
		{
			_isMoving = value;
			_agent.ResetPath();
		}

		private void Update()
		{
			if (!_isMoving) return;

			if ((_view.transform.position - _lastPlayerPos).magnitude > 50)
			{
				_agent.ResetPath();
				_agent.SetDestination(_lastPlayerPos);
			}
			else
			{
				_agent.ResetPath();
			}
		}

		private void FixedUpdate()
		{
			_rb.velocity = -Vector3.Project(_rb.velocity, _view.transform.up);

			_view.transform.position = Vector3.MoveTowards(_view.transform.position, _agent.transform.position, Time.deltaTime * 14);
		}
	}
}
