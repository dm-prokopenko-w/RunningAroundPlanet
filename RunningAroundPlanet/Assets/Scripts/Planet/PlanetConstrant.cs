using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetConstrant : MonoBehaviour
{
	private Vector3 _planetPos;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag.Equals("Planet"))
		{
			_planetPos = other.transform.position;
		}
	}

	private void FixedUpdate()
	{
		Quaternion rot = Quaternion.FromToRotation(-transform.up, _planetPos - transform.position);
		transform.rotation = rot * transform.rotation;
	}
}
