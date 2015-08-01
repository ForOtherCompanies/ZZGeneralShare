using UnityEngine;
using System.Collections;

public class Waypoint : InteractionAgent {

	public override void MakeActions ()
	{
		base.MakeActions ();
		Debug.Log (transform.name + " acting from Waypoint");
	}

}
