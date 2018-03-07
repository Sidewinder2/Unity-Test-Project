using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer2d : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public float countup = 0f;
	public Text myText;
	
	// Update is called once per frame
	void Update () {
		countup++;
		myText.text = countup.ToString();
	}
}
