using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PursuerSystem
{
	public class PursuerView : MonoBehaviour
	{
		public event Action<bool> OnMoving;

		private void OnTriggerEnter(Collider other)
		{
			if (other.tag.Equals("Player"))
			{
				OnMoving?.Invoke(false);
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.tag.Equals("Player"))
			{
				OnMoving?.Invoke(true);
			}
		}
	}
}
