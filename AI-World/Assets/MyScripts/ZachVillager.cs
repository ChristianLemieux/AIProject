using UnityEngine;
using System.Collections;

public class ZachVillager : ZachSteering {


	// Use this for initialization
	void Start () {
		velocity = 5;
		rotVelocity = 1;
	}
	
	// Update is called once per frame
	void Update () {
		Wander ();

		base.Steer();

		Debug.DrawRay (transform.position, transform.forward*10);
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Werewolf") {
			GameObject.Destroy (this.gameObject);
			Debug.Log ("wolf caught a poor human");
		} else if (col.gameObject.tag == "Cart") {
			GameObject.Destroy(this.gameObject);
			Debug.Log ("human escaped!");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Mayor") {
			Follow(other.gameObject);
		} 
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Werewolf") {
			//do stuff
		}
	}
}
