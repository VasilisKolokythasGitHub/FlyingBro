using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class justin : MonoBehaviour {
	public float forwardSpeed = 3f;
	public bool destroyed = false;
	Vector3 velocity;
	public bool nokia=false;
	public bool da_loop = true;
	Animator animator;
	public GameObject[] enemies;
	public bool just = false;
	public int amount;
	public bool xtypise=false;
	public int score;
	public bool efage_bounidi = false;
	public bool efage_laser = false;
	
	public Vector3 playerpos;
	void Start(){
	 	
		GameObject skori = GameObject.Find ("Bro");
		movement_justin keimeno = skori.GetComponent<movement_justin> ();
		score = keimeno.Score;



		animator = transform.GetComponentInChildren<Animator>();
		animator.Play("justinos");
		
	}
	
	
	void Update(){

		GameObject bouketo = GameObject.Find ("Bro");
		movement_justin bounia = bouketo.GetComponent<movement_justin> ();
		efage_bounidi = bounia.bounidi;

		GameObject laseraki = GameObject.Find ("Bro");
		movement_justin laseria = laseraki.GetComponent<movement_justin> ();
		efage_laser = laseria.exei_laser;

		GameObject skori = GameObject.Find ("Bro");
		movement_justin keimeno = skori.GetComponent<movement_justin> ();
		keimeno.Score = score;
		if(just){

			xtypise=true;
				animator.Play("hit_bro");
			GameObject.Find("Health Bar").GetComponent<HealthBar>().Damage(15);
			//	GetComponent<Rigidbody2D>().AddForce(Vector2.left*forwardSpeed*2);

			just= false;
		}
		
		
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		
		if(collider.tag == "Player" && !destroyed  && efage_laser) { // an pesei panw kai dn exei katastrafei to nokia
			destroyed = true;						//katastrafhke
			animator.Play("burned 1");
			score += 50;
			
			
			GetComponent<Rigidbody2D>().AddForce( Vector2.down * 300f );
			
			
			
			
			
		}
		if(collider.tag == "Player" && !destroyed  && efage_bounidi) { // an pesei panw kai dn exei katastrafei to nokia
			destroyed = true;						//katastrafhke
			animator.Play("justinos_hit");
			score += 80;
			
			
			GetComponent<Rigidbody2D>().AddForce( Vector2.up * 300f );
			
			
			
			
			
		}
		if(collider.tag == "UnPunch" && !destroyed ){     
			
			just = true;


		}

		if(collider.tag == "BGLooper"){
			
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			animator.Play("justinos");
			destroyed = false;
			xtypise=false;
			Vector3 pos = transform.position;
			Quaternion rot = transform.rotation;
			pos.y = Random.Range(-1, 6);        
			
			pos.x += 6;
			
			rot.z = 0;
			
			transform.position = pos;
			transform.rotation = rot;
		}
		
	}
	void FixedUpdate () {
		Vector3 temp = gameObject.transform.position;
		temp.x -= forwardSpeed * Time.deltaTime;
		gameObject.transform.position = temp;
		
		
		
	}
	 
	
	
}
