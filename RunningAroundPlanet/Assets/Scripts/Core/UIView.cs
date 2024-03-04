using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace UISystem
{
	public class UIView : MonoBehaviour, IStartable
	{
		[Inject] private UIController _uiController;

		[SerializeField] private Joystick _moveJoystick;
		[SerializeField] private Joystick _lookJoystick;


		public void Start()
		{
			_uiController.Init(_moveJoystick, _lookJoystick);
		}
	}
}