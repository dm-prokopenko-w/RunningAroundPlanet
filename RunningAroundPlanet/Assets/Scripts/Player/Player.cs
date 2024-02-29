using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
	[SerializeField] private NavMeshAgent agent;
	[SerializeField] private Transform _view;
	[SerializeField] private Rigidbody _rb;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				agent.SetDestination(hit.point);
			}
		}

	}

	private void FixedUpdate()
	{
		_view.position = Vector3.MoveTowards(_view.position, agent.transform.position, Time.deltaTime * 100);
		//_rb.velocity = agent.transform.position.normalized;
		//_view.transform.position = agent.transform.position;
	}

}
