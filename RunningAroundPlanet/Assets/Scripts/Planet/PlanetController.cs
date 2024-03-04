using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlanetSystem
{
	public class PlanetController
	{
		public Transform PlanetTr => _planetTr;
		private Transform _planetTr;

		public void Init(Transform tr)
		{
			_planetTr = tr;
		}
	}
}
