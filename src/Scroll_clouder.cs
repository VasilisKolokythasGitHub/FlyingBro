using UnityEngine;
using System.Collections;

public class Scroll_clouder : MonoBehaviour {
	public float speed = 2f;
	public float speed2;
	public bool nok = false;
	public bool kamenos,kamenos2,kamenos3= false;
	// Use this for initialization
	public bool girl = false;

	 
	// Update is called once per frame
	void  Update () {
		GameObject girlll = GameObject.Find ("Bro");
		movement_clouder gf = girlll.GetComponent<movement_clouder> ();
		girl = gf.girl;

		Vector2 offset = GetComponent<Renderer> ().material.mainTextureOffset;
		GameObject kapsimo = GameObject.Find ("clouds");
		clouder kahla = kapsimo.GetComponent<clouder> ();
		kamenos = kahla.kamenos;
		
		GameObject kapsimo2 = GameObject.Find ("clouds_2");
		clouder_2 kahla2 = kapsimo2.GetComponent<clouder_2> ();
		kamenos2 = kahla2.kamenos2;
		
		GameObject kapsimo3 = GameObject.Find ("clouds_3");
		clouder_3 kahla3 = kapsimo3.GetComponent<clouder_3> ();
		kamenos3 = kahla3.kamenos3;

		if ( kamenos || kamenos2 || kamenos3 || girl) {
			speed = 0;
		}
		Application.targetFrameRate = 60;
			//Vector2 offset2 = GetComponent<Renderer>().material.mainTextureOffset;
			offset.x += speed * (Time.deltaTime / 10);
 			offset.x = (offset.x)%1;
			GetComponent<Renderer> ().material.mainTextureOffset = offset;
		

	}
	
	
}
