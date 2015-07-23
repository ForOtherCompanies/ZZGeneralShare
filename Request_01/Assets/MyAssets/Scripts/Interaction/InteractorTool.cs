using UnityEngine;
using System.Collections;

public class InteractorTool : MonoBehaviour {

	public float interactionDistance = 0.5f;

	public InteractionAgent lastSelected = null;
	public GameObject aimPoint3d;

	//references to other elements in the same prefab
	public Camera playerCamera;


	//to set private
	public InteractionAgent currentAgent;

	void Update() {
		RaycastHit hit;

		Debug.DrawRay (playerCamera.transform.position, playerCamera.transform.forward*interactionDistance, Color.cyan);
		Physics.Raycast (playerCamera.transform.position, playerCamera.transform.forward, out hit, interactionDistance);


		aimPoint3d.transform.position = hit.point;


		if (hit.transform != null && hit.transform.tag == "InteractiveByRay"){
			currentAgent = hit.transform.GetComponent<InteractionAgent>();

		} else{
			currentAgent = null;
		}


		if ( currentAgent != lastSelected){
			if (currentAgent == null){
				lastSelected.Unselect();
				lastSelected = null;
			} else{
				if (lastSelected != null)
					lastSelected.Unselect ();
				lastSelected = currentAgent;
				lastSelected.Select();
			}


		}


	}
}
