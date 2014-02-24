using UnityEngine;
using System.Collections;

public class ZachSteering : MonoBehaviour {

	//current location the character wants to aim for.
	protected bool hasTarget;
	protected Vector3 target;

	protected GameObject followTarget;

	//bool for arrival
	private bool arriving;

	//variables for movement.
	protected float velocity;
	protected float acceleration; 
	protected float maxVelocity;

	//variables for rotation.
	protected float rotAccel;
	protected float rotVelocity;
	protected float maxRotVelocity;

	//No infinite wandering
	int wanderTime;

	// Steer is called every frame by parent class.
	protected void Steer () {

		if (hasTarget) {
			//rotate towards target
			Quaternion targetRotation = Quaternion.LookRotation(target - transform.position);
			float str = Mathf.Min (rotVelocity * Time.deltaTime,1);
			transform.rotation = Quaternion.Lerp(transform.rotation,targetRotation,str);

			//move forwards.
			if(arriving)//slow it up!
			{
				//TODO: arrival. 
				transform.position += transform.forward.normalized * velocity * Time.deltaTime;
			}
			else // full speed ahead
			{
				transform.position += transform.forward.normalized * velocity * Time.deltaTime;
			}
		}
	}

	//Wander a specific distance
	protected void Wander(float wDist)
	{
		//if has no target find one
		if (!hasTarget || wanderTime > 500) {
			//Debug.Log ("finding target...");
			wanderTime = 0;
			float targetX = transform.position.x + Random.Range (-wDist,wDist);
			float targetZ = transform.position.z + Random.Range (-wDist,wDist);
			target =  new Vector3(targetX,2.3f,targetZ);
			hasTarget = true;

			//Debug.Log ("found target at " + target);
		}

		wanderTime++;

		//if close to target, find new target.
		if ((transform.position - target).magnitude < 3) 
		{
			//Debug.Log("got to target");
			target = Vector3.zero;
			hasTarget = false;
		}
		//otherwise, movement is handled in update.
	}
	//default wander distance
	protected void Wander()
	{
		Wander (25);
	}


	protected void Seek(Vector3 pos){
		target = pos;
		hasTarget = true;
	}

	protected void Seek(GameObject go)
	{
		Seek (go.transform.position);
	}

	void Arrive(Vector3 pos)
	{
		Seek (pos);
		arriving = true;
	}

	protected void Follow(GameObject go)
	{
		followTarget = go;
	}


}
