using Core;
using UISystem;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace PlayerSystem
{
	public class PlayerController : IFixedTickable
	{
		[Inject] private UIController _uiController;

		public Transform PlayerTran => _view;

		private Rigidbody _rb;
		private Transform _view;
		private Animator _anim;
		private bool _isInit = false;

		public void Init(Animator anim, Rigidbody rb, Transform view)
		{
			_rb = rb;
			_view = view;
			_anim = anim;
			_isInit = true;
		}

		public void FixedTick()
		{
			if (!_isInit) return;

			Move();
			Look();
		}

		private void Move()
		{
			Vector3 down = -Vector3.Project(_rb.velocity, _view.up);
			Vector3 forward = _view.forward * _uiController.MoveVer * Constants.PlayerSpeed;
			Vector3 side = _view.right * _uiController.MoveHor * Constants.PlayerSpeed;

			_rb.velocity = down + forward + side;

			_anim.SetFloat("X", _uiController.MoveHor * 2.5f);
			_anim.SetFloat("Y", _uiController.MoveVer * 2.5f);
		}

		private void Look()
		{
			_view.Rotate(_view.up, -_uiController.LookHor * Constants.PlayerSensativity);
		}
	}
}
