using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class justin_1 : MonoBehaviour {
	public float forwardSpeed = 3f;
	public bool destroyed2;
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
		
		destroyed2 = false;
		

		animator = transform.GetComponent<Animator>();
		animator.Play("justinos");
		GameObject skori = GameObject.Find ("Bro");
		movement_justin keimeno = skori.GetComponent<movement_justin> ();
		
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
		
		if(collider.tag == "Player" && !destroyed2  && efage_laser) { // an pesei panw kai dn exei katastrafei to nokia
			destroyed2 = true;						//katastrafhke
			animator.Play("burned 1");
			score += 50;
			
			
			GetComponent<Rigidbody2D>().AddForce( Vector2.down * 300f );
			
			
			
			
			
		}
	
		if(collider.tag == "Player" && !destroyed2  && efage_bounidi) { // an pesei panw kai dn exei katastrafei to nokia
			destroyed2 = true;						//katastrafhke
			animator.Play("justinos_hit");
			score += 80;
			
			
			GetComponent<Rigidbody2D>().AddForce( Vector2.up * 300f );
			
			
			
			
			
		}
		if(collider.tag == "UnPunch" && !destroyed2 ){     
			just = true;
			
			
		}
		
		if(collider.tag == "BGLooper"){
			
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			animator.Play("justinos");
			destroyed2 = false;
			xtypise=false;

			 
			Vector3 pos = transform.position;
			Quaternion rot = transform.rotation;
			pos.y= Random.Range(6, 12);        
			
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