using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoxes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public GameObject CubeFab;
	
	
	public int boxCount = 5;
	public float boxCountDown = 5.0f;
	public float boxCountReset = 10.0f;
	
	// Update is called once per frame
	void Update () 
	{
	boxCountDown -= .2f;
	if (boxCountDown <= 0 && boxCount > 0)
		{
		boxCount--;
		boxCountDown = boxCountReset;
		GameObject cube = Instantiate(CubeFab);
		cube.transform.position = transform.position;
		}
	}
}
