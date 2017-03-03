using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {
	
	int num_enemies = 2;

	
	 
	
	void Start() {
	
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); //GAMEOBJECTS ME TAG ENEMY
	 	
		GameObject[] enemies_2 = GameObject.FindGameObjectsWithTag("Enemy_2"); //GAMEOBJECTS ME TAG ENEMY

		GameObject[] enemies_3 = GameObject.FindGameObjectsWithTag("Enemy_3"); //GAMEOBJECTS ME TAG ENEMY


	}

	
	void OnTriggerEnter2D(Collider2D collider) {


		float widthOfBGObject = ((BoxCollider2D)collider).size.x;
		
		Vector3 pos = collider.transform.position;

		if(collider.tag == "Sms"){
			GameObject current_sms = GameObject.FindGameObjectWithTag("Sms");
			Destroy(current_sms);
		}
		if (collider.tag!="Sms"){
 
		pos.x += widthOfBGObject * num_enemies*5  ; //JUST FOR NOW
		
			
		
		collider.transform.position = pos;
		}
	}
}
