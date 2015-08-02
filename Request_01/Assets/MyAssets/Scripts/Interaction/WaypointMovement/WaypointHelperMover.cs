using UnityEngine;
using System.Collections;

public class WaypointHelperMover : MonoBehaviour {

	public Transform goal;
	public NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		//agent.SetDestination (goal.position);

	}


	public void Update (){
		Debug.Log ("--> " + agent.destination);
	}


	public void SetTarget (GameObject newTarget){

		//goal.transform.position = newTarget;
		//agent.SetDestination (newTarget);

		agent.SetDestination(newTarget.transform.position);
	}
}
