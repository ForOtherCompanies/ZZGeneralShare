using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	//settings
	public float rotationTimerThreshold = 1.5f;
	//rotation threshold to lock movement
	public float rotationThreshold = 1f;  //IsEulerDegree per frame 
	
	public float rotationLockedTimerThreshold = 3f;
	//rotation threshold for keep the movement locked
	public float rotationLockedThreshold = 1f;
	
	public float movementSpeed = 3f;
	
	
	//local vars
	public Quaternion lastRotation;
	public Quaternion movementRotation;
	public bool locked;
	public float rotationTimer = 0f;
	public float rotationLockedTimer = 0f;
	public bool bouncing;
	public float bouncingTimer=0f;
	public float bouncingLimit=3f;
	//developing vars
	float maxDifferenceX = 0f;
	float maxDifferenceY = 0f;
	
	// Use this for initialization
	void Start () {
		locked = false;
		lastRotation = transform.rotation;
		
	}
	
	void Update (){
		
		//		Debug.Log (rigidbody.velocity);
		if (bouncing){
			bouncingTimer += Time.deltaTime;
		}
		
		if (bouncingTimer > bouncingLimit){
			bouncingTimer = 0;
			bouncing = false;
			GetComponent<Rigidbody>().velocity = new Vector3 (0,0,0);
			
		}
		
		
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (!locked){ 
			TryToLock();
			
			
		} else {
			TryToUnlock();
		}
		
		lastRotation = transform.rotation;
		
		if (locked)
			transform.Translate (transform.forward * Time.deltaTime * movementSpeed, Space.World);
		
		/*
	//	debug log for angular difference per frame
		maxDifferenceX = Mathf.Max (Mathf.Abs(Mathf.DeltaAngle(lastRotation.eulerAngles.x, transform.eulerAngles.x)), maxDifferenceX);
		maxDifferenceY = Mathf.Max (Mathf.Abs(Mathf.DeltaAngle(lastRotation.eulerAngles.y, transform.eulerAngles.y)), maxDifferenceY);

		Debug.Log ( "x:"+ maxDifferenceX + "#y:"+maxDifferenceY);
*/
		
		
		
	}
	
	void OnGUI (){
		//Rect r = new Rect (10, 10, 100, 20);
		//GUI.Label(r, "PLACEHOLDERXX" );
	}
	
	void TryToLock(){
		if (bouncing)
			return;
		//if rotation beyond threshold then reset locking timer
		if (Mathf.Abs(Mathf.DeltaAngle(lastRotation.eulerAngles.x, transform.eulerAngles.x))> rotationThreshold
		    ||Mathf.Abs(Mathf.DeltaAngle(lastRotation.eulerAngles.y, transform.eulerAngles.y))> rotationThreshold){
			
			rotationTimer = 0f;
		} else{
			rotationTimer += Time.deltaTime;
			if (rotationTimer > rotationTimerThreshold){
				locked = true;
				movementRotation = transform.rotation;
				rotationTimer = 0f;
			}
			
		}
	}
	
	void TryToUnlock(){
		if (Mathf.Abs(Mathf.DeltaAngle(movementRotation.eulerAngles.x, transform.eulerAngles.x))> rotationLockedThreshold
		    ||Mathf.Abs(Mathf.DeltaAngle(movementRotation.eulerAngles.y, transform.eulerAngles.y))> rotationLockedThreshold){
			locked = false;
		} else
			movementRotation = transform.rotation;
		//Debug.Log ("not unlock");
		
	}
	
	void Move (){
		
		
	}
	
	void OnCollisionEnter (Collision col){
		bouncing = true;
		locked = false;
		rotationTimer = 0f;
		Debug.Log ("colision");
	}
}
