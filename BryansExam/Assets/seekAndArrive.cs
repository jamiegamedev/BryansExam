using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This is about the best I can do at the moment. I got the cube follwing an object. Random positions etc where a bit above my pay grade.


public class seekAndArrive : MonoBehaviour {

	public Vector3 velocity = Vector3.zero;
	public Vector3 ForceAcc = Vector3.zero;
	public float mass;
	//public float maxspeed = 10.0f;
	public GameObject enemy;
	//public Vector3 desiredTarget = new Vector3(0,0,0);
	
	Vector3 Seek(Vector3 target)
	{
		Vector3 desired = target - transform.position;
		desired.Normalize();
		//desired*= maxspeed;
		return desired - velocity;
		
	}
	// Use this for initialization
	void Start () 
	{
		mass = 1.0f;
	}

	// Update is called once per frame
	void Update () 
	{
		//float forceAmount = 10.0f;
		//maxspeed = 30.0f;
		//ForceAcc += Seek(desiredTarget);
		//float distance = Vector3.Distance(transform.position,enemy.transform.position);
		ForceAcc += Seek(enemy.transform.position);
		
		Vector3 accel = ForceAcc / mass;
		velocity = velocity + accel * Time.deltaTime;
		transform.position = transform.position + velocity * Time.deltaTime;
		ForceAcc = Vector3.zero;
		
		if(velocity.magnitude <= float.Epsilon)
		{
			transform.forward = Vector3.Normalize(velocity);
		}
	}
}
