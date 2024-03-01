using Core;
using System;
using UnityEngine;

namespace PlayerSystem
{
	public class Player : Character
	{
		[SerializeField] private Transform _view;

		[SerializeField] private Joystick _moveJoystick;
		[SerializeField] private Joystick _lookJoystick;

		public event Action<Vector3> OnPlayerPos;

		private float _speed = 50f;
		private float _sensativity = 2f;
		private float _time = 0;

		private void Start()
		{
			_moveJoystick.OnMoved += TouchMoved;
		}
		private void OnDestroy()
		{
			_moveJoystick.OnMoved -= TouchMoved;

		}

		private void TouchMoved()
		{
			OnPlayerPos?.Invoke(_rb.position);
		}

		private void FixedUpdate()
		{
			Move();
			Look();
		}

		private void Move()
		{
			Vector3 down = -Vector3.Project(_rb.velocity, _view.up);
			Vector3 forward = _view.forward * _moveJoystick.Vertical * _speed;
			Vector3 side = _view.right * _moveJoystick.Horizontal * _speed;

			_rb.velocity = down + forward + side;
		}

		private void Look()
		{
			_view.Rotate(_view.up, _lookJoystick.Horizontal * _sensativity);
		}
	}
}
