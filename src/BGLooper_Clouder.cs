using UnityEngine;
using System.Collections;

public class BGLooper_Clouder : MonoBehaviour {
	
	int num_enemies = 2;
	
	
	
	
	void Start() {
		
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); //GAMEOBJECTS ME TAG ENEMY
		
		GameObject[] enemies_2 = GameObject.FindGameObjectsWithTag("Enemy_2"); //GAMEOBJECTS ME TAG ENEMY
		
		GameObject[] enemies_3 = GameObject.FindGameObjectsWithTag("Enemy_3"); //GAMEOBJECTS ME TAG ENEMY
		
		foreach(GameObject enemy in enemies) {
			Vector3 pos = enemy.transform.position;
			
			pos.x = Random.Range(0, 7);        
			
			pos.y += Random.Range (1,3);
			
			
			enemy.transform.position = pos;
		}
		
		foreach(GameObject enemy1 in enemies_2) {
			Vector3 pos = enemy1.transform.position;
			
			pos.y += Random.Range (1,3);
			pos.x = Random.Range(9, 14);   
			Vector3 destination = new Vector3(0,0,0);
			enemy1.transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, 
			                                            destination, 
			                                            Time.deltaTime);
			enemy1.transform.position = pos;
			
		}
		foreach(GameObject enemy3 in enemies_3) {
			Vector3 pos = enemy3.transform.position;
			
			pos.y += Random.Range (1,3);
			pos.x = Random.Range(16, 19);    
			Vector3 destination = new Vector3(0,0,0);
			enemy3.transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, 
			                                            destination, 
			                                            Time.deltaTime);
			enemy3.transform.position = pos;
		}
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
