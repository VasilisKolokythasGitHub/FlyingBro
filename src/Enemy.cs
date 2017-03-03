using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D collider) {

		if(collider.tag == "Player") {
			GetComponent<Rigidbody2D>().AddForce( Vector2.up * 300f );
		}
	}
}
