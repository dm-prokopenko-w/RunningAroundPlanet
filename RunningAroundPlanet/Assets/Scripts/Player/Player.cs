using Core;
using VContainer;
using UnityEngine;

namespace PlayerSystem
{
	public class Player : Character
	{
		[Inject] private PlayerController _playerController;

		public override void Start()
		{
			_playerController.Init(_anim, _rb, transform);
		}
	}
}