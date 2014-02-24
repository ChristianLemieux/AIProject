using UnityEngine;
using System.Collections;

public class ZachWerewolf : ZachSteering {

	private GameObject villagerTarget;

	// Use this for initialization
	void Start () {
		hasTarget = false;
		velocity = 8;
		rotVelocity = .4f;
	}
	
	// Update is called once per frame
	void Update () {
		if (villagerTarget != null) {
			Seek(villagerTarget);
		}
		else {
			Wander (40);
		}

		base.Steer ();
	}

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log ("a " + other.tag + "has entered the werewolf's trigger!");
		if (other.tag == "Villager") {
			Debug.Log ("a villager has entered the werewolf's trigger!");

			if (villagerTarget == null) {//if the werewolf didnt already have a target...
					hasTarget = true;
					villagerTarget = other.gameObject;
			} 

		}
		else if(other.tag == "Mayor")
		{
			//Flee
			Debug.Log("RUNNNNNNNNN");
			Flee(other.gameObject);
		}
	}
}
