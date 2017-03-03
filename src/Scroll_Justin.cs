using UnityEngine;
using System.Collections;

public class Scroll_Justin : MonoBehaviour {
	public float speed;
	 
	// Update is called once per frame
	void  Update () {

		Application.targetFrameRate = 60;
		Vector2 offset = GetComponent<Renderer>().material.mainTextureOffset;
		offset.x += speed * (Time.deltaTime/10);
		offset.x = (offset.x)%1;
		GetComponent<Renderer>().material.mainTextureOffset = offset;
		

	}
	
	
}
