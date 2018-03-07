using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCrosshair : MonoBehaviour {
		public Rect crosshairRect;
		public Texture crosshairTexture;
	
	// Use this for initialization
	void Start () {
		float crosshairSize = Screen.width * .1f;
		crosshairTexture = Resources.Load("Crosshairs.png") as Texture;
		crosshairRect = new Rect(Screen.width / 2 - crosshairSize / 2, 
												Screen.height / 2 - crosshairSize / 2,
												crosshairSize, crosshairSize);
	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.DrawTexture(crosshairRect, crosshairTexture);
		
	}
}
