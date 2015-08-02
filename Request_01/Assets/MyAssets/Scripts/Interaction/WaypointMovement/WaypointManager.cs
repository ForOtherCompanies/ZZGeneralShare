using UnityEngine;
using System.Collections;

public class WaypointManager : MonoBehaviour {
	//to hide in inspector

	//public Waypoint currentWaypoint = null;
	//public Vector3 currentWaypoint = Vector3.zero;
	GameObject currentWaypoint = null;
	public WaypointHelperMover waypointHelperMover;

	//set private








	public void ChangeWaypoint (GameObject wp){

		if (currentWaypoint == wp)
			return;

		currentWaypoint = wp;
		waypointHelperMover.SetTarget (wp);

	}
}
