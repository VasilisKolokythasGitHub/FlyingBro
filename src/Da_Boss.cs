using UnityEngine;
using System.Collections;

public class Da_Boss : MonoBehaviour {
	public float forwardSpeed;
	public float distance;
	// Use this for initialization
	 

	void Start()

	{
		forwardSpeed = 4f;
	}
	void Update()
	{



		GameObject player = GameObject.Find ("Bro");
		GameObject Boss = GameObject.Find ("nokia2");
		Vector3 pos = player.transform.position;
		Vector3 boss_pos = Boss.transform.position;
		 
		 
		distance = boss_pos.x -  pos.x;
	//	Debug.LogError (distance);
		if (pos.x > 5 && pos.x < 6) 
		{
			boss_pos.x = pos.x  + 20;

 		if(boss_pos.x > distance)
		 {
			forwardSpeed = 4f;
	 	}
			Boss.transform.position = boss_pos;
		//	Debug.LogError (boss_pos.x);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GameObject gameObject = GameObject.Find ("nokia2");
		Vector3 temp = gameObject.transform.position;
		temp.x += forwardSpeed * Time.deltaTime;
		gameObject.transform.position = temp;
	}
	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.tag == "Player"){
		 
	 
	
	 
	
	GetComponent<Rigidbody2D>().AddForce( Vector2.up * 300f );
		}
	}
	 
}
