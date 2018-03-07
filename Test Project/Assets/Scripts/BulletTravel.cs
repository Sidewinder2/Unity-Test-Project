using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTravel : MonoBehaviour 
	{

	// Use this for initialization
	void Start () 
		{
			
		}
	public float movespeed = 5;
	public float lifeSpan = 1000;
		
		
	// Update is called once per frame
	void Update () 
		{
		transform.Translate(0, 0, movespeed);
		lifeSpan--;
		if (lifeSpan <= 0)
			{
			Destroy(gameObject);
			}
		}
		
		
	//does stuff pertaining to collisions
	void OnCollisionEnter(Collision collisionInfo)
		{
		Debug.Log("test "+collisionInfo.gameObject.tag);
		if(collisionInfo.gameObject.tag == "Destroyable")
			{
			Destroy(collisionInfo.gameObject);
			Destroy(gameObject);
			}
		if(collisionInfo.gameObject.tag == "Terrain")
			{
			Destroy(gameObject);
			}
		}
	}
