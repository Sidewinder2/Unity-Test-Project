using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
	
	
	public float jumpHeight = 1000;
    public Rigidbody rb;
	
	
	
	// Use this for initialization
	void Start () 
	{

			Screen.SetResolution(640, 480, true);
			
	}
	
	//camera
	public float minX = -360.0f;
	public float maxX = 360.0f;
	
	public float minY = -45.0f;
	public float maxY = 45.0f;
 
	public float sensX = 100.0f;
	public float sensY = 50.0f;
	
	public float rotationY = 0.0f;
	public float rotationX = 0.0f;
	
	//movement
	public float moveSpeed = .14f;
	
	//shooting
	public GameObject bullet;
	public float bulletSpeed = 10;
	public float refireRate = 2;
	public float refireTime  = 0;
	
	//drawing crosshairs
	public Texture2D cursorImage;
	private int cursorWidth = 32;
	private int cursorHeight = 32;

	
	// Update is called once per frame
	void FixedUpdate () 
	{
		
		
		//strafe keys
		if (Input.GetButton("A"))
		{
			Vector3 oldvect = transform.localEulerAngles;
			transform.localEulerAngles = new Vector3 (0, rotationX, 0);
			transform.Translate(-moveSpeed, 0, 0);
			//transform.localEulerAngles = oldvect;
		}
		if (Input.GetButton("D"))
		{
			Vector3 oldvect = transform.localEulerAngles;
			transform.localEulerAngles = new Vector3 (0, rotationX, 0);
			transform.Translate(moveSpeed, 0, 0);
			//transform.localEulerAngles = oldvect;
		}
		if (Input.GetButton("W"))
		{
			Vector3 oldvect = transform.localEulerAngles;
			transform.localEulerAngles = new Vector3 (0, rotationX, 0);
			transform.Translate(0, 0, moveSpeed);
			//transform.localEulerAngles = oldvect;
		}
		if (Input.GetButton("S"))
		{
			Vector3 oldvect = transform.localEulerAngles;
			transform.localEulerAngles = new Vector3 (0, rotationX, 0);
			transform.Translate(0, 0, -moveSpeed);
		//transform.localEulerAngles = oldvect;
		}
		
		//Jumping
		if (Input.GetKeyDown("space"))
		{
			//transform.Translate(0, 0, -moveSpeed);
			rb.AddForce(0f, jumpHeight, 0f);
		}
		
		//Lunge
		if (Input.GetMouseButtonDown(1))
		{
			//transform.Translate(0, 0, -moveSpeed);
			rb.AddRelativeForce(0, jumpHeight*.6f, jumpHeight*3f);
			
		}
		
		//Debug.Log(rotationY);
		
		//rotate the player and camera
		rotationX += Input.GetAxis ("Mouse X") * sensX * Time.deltaTime;
		rotationY += Input.GetAxis ("Mouse Y") * sensY * Time.deltaTime;
		rotationY = Mathf.Clamp (rotationY, minY, maxY);
		
		//update player X rotation. Also rotates camera's X since it's attached
		transform.localEulerAngles = new Vector3 (0, rotationX, 0);
		
		//update the camera Y rotation
		GameObject camera = GameObject.Find("Main Camera");
		camera.transform.localEulerAngles = new Vector3 (-rotationY, 0, 0);
		
		
		//Reduce bullet timer
		refireTime  = Mathf.Clamp (refireTime, 0, refireTime - 1);
		
		//Shooting
		if (Input.GetMouseButton(0))
			{
			if (refireTime == 0)
				{
				GameObject bullet1 = Instantiate(bullet);		//create bullet
				bullet1.transform.position = camera.transform.position;	//set position to camera
				//bullet1.transform.localEulerAngles = transform.localEulerAngles;
				bullet1.transform.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);	//set rotation to camera angles
				//Debug.Log(camera.transform.localEulerAngles);
					
				refireTime = refireRate;
				}
		
			
			}
		
		//~ if(Input.GetMouseButtonDown(0))
			//~ {
			//~ Debug.Log("Mouse Pressed");
			//~ }
		
	}
	
	
	//does stuff pertaining to collisions
	void OnCollisionEnter(Collision collisionInfo)
		{
			print("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
			print("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
			print("Their relative velocity is " + collisionInfo.relativeVelocity);
		}

}
