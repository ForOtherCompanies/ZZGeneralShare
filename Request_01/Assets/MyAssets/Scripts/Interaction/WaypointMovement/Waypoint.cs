using UnityEngine;
using System.Collections;

public class Waypoint : InteractionAgent {

	WaypointManager waypointManager;
	public GameObject waypointPoint;

	public override void Start ()
	{
		base.Start();
		waypointManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<WaypointManager>();
	}



	public override void MakeActions ()
	{
		base.MakeActions ();
		//waypointManager.currentWaypoint = waypointPoint;
		waypointManager.ChangeWaypoint (waypointPoint);
		Debug.Log (transform.name + " Make action from Waypoint");
	}



}
