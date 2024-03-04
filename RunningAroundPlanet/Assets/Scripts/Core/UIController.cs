namespace UISystem
{
	public class UIController 
	{
		private Joystick _moveJoystick;
		private Joystick _lookJoystick;

		public void Init(Joystick move, Joystick look)
		{
			_moveJoystick = move;
			_lookJoystick = look;
		}

		public float MoveVer => _moveJoystick.Vertical;
		public float MoveHor => _moveJoystick.Horizontal;
		public float LookHor => _lookJoystick.Horizontal;
	}
}