using PlanetSystem;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace PlayerSystem
{
	public class PlanetView : MonoBehaviour, IStartable
	{
		[Inject] private PlanetController _uiController;

		[SerializeField] private Transform _mesh;

		public void Start()
		{
			_uiController.Init(_mesh);
		}
	}
}