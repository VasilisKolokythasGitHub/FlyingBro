using UnityEngine;
using System.Collections;

public class ScrollScript : MonoBehaviour {
	 

	public  float speed;
	void  Update () {
		Application.targetFrameRate = 60;
		Vector2 offset = GetComponent<Renderer>().material.mainTextureOffset;
		//Vector2 offset2 = GetComponent<Renderer>().material.mainTextureOffset;
		offset.x += speed * (Time.deltaTime/10);
		offset.x = (offset.x)%1;
		GetComponent<Renderer>().material.mainTextureOffset = offset;
		
		
	}
	 
}
