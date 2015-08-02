using UnityEngine;
using System.Collections;

public class KeepOnTargetPosition : MonoBehaviour {

	public GameObject target;


	public void Update(){
		transform.position = target.transform.position;
	}
}
