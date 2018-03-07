using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	
	public TextMesh tm;

	public float countup = 0f;
	
	// Update is called once per frame
	void Update () {
		countup++;
		tm.text = countup.ToString();
	}
}
