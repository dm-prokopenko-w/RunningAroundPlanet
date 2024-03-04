using UnityEngine;

namespace PlanetSystem
{
	public class PlanetConstrant : MonoBehaviour
	{
		private Vector3 _planetPos;
		private float rotationSpeed = 5f; // Скорость вращения игрока

		protected void OnTriggerEnter(Collider other)
		{
			if (other.tag.Equals("Planet"))
			{
				_planetPos = other.transform.position;
			}
		}

		protected virtual void FixedUpdate()
		{  
			Vector3 toPlanetDirection = (transform.position - _planetPos).normalized;
			Quaternion targetRotation = Quaternion.FromToRotation(transform.up, toPlanetDirection) * transform.rotation;
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed);
		}
	}
}
