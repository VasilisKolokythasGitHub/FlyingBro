using UnityEngine;
using System.Collections;

public class clouder : MonoBehaviour {
	public float forwardSpeed = 3f;
	public float SmsSpeed = 12f;
	public bool destroyedd = false;
	Vector3 velocity;
	public bool kopanhse =false;
	public bool exei_laser = false;
	public bool da_loop = true;
	Animator animator;
	public GameObject[] enemies;
	public int score;
	public int amount;
	Vector3 spawnPoint;
	public bool kamenos= false;
	
	
	public Vector3 playerpos;
	void Start(){
		kamenos = false;
		 

		animator = transform.GetComponent<Animator>();
		GameObject skori = GameObject.Find ("Bro");
		movement_clouder keimeno = skori.GetComponent<movement_clouder> ();
		score = keimeno.Score;
	}
	
	
	void Update(){



		GameObject da_laser = GameObject.Find("Laserous");
		ChooseWeapon laser =  da_laser.GetComponent<ChooseWeapon>();
		exei_laser = laser.using_laser;

		GameObject skori = GameObject.Find ("Bro");
		movement_clouder keimeno = skori.GetComponent<movement_clouder> ();
		keimeno.Score = score;
		
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		collider = collider.GetComponentInParent<BoxCollider2D> ();
		if (collider.tag == "Player" && !destroyedd && !exei_laser) { //an paixtei bounidi  sto synnefo
			destroyedd = true;						//
//			animator.Play("break");
			score += 500;
			
			
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 200f);
			Vector3 destination = new Vector3 (0, 0, -645);
			transform.eulerAngles = Vector3.Lerp (transform.rotation.eulerAngles, destination, Time.deltaTime);
			
		}


			if(collider.tag == "Player" && !destroyedd && exei_laser ) {
								//
				//			animator.Play("break");
				score += 350;
				animator.Play ("clouder_fire");
				
				GetComponent<Rigidbody2D>().AddForce(Vector2.up*200f);
				Vector3 destination2 = new Vector3(0,0,-645);
				transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles,  destination2, Time.deltaTime);
				destroyedd = true;	

			}
	 
		if (collider.tag == "UnPunch" && this.animator.GetCurrentAnimatorStateInfo (0).IsName ("clouder_thunder"))
		{
			kamenos = true;

		}
		if(collider.tag == "UnPunch" && !destroyedd ){     //pethane

			kopanhse = true;
			GameObject gameObject = GameObject.Find ("clouds");
			animator.Play("clouder_thunder");


			//Debug.LogError("Dead!");
		}
		if(collider.tag == "BGLooper_Clouder"){
		 
			GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero;
			animator.Play("clouder_idle 1");
			destroyedd = false;
			Vector3 pos = transform.position;
			Quaternion rot = transform.rotation;
			pos.y = Random.Range(-1, 6);        
			
			pos.x += Random.Range (1,3);
			
			rot.z = 0;

			transform.position = pos;
			transform.rotation = rot;
		}
		
	}
	
	IEnumerator MyMethodd() {
		
		yield return new WaitForSeconds(1);
		Application.LoadLevel(3);
		
	}
	void FixedUpdate () {
		Vector3 temp = gameObject.transform.position;
		temp.x -= forwardSpeed * Time.deltaTime;
		gameObject.transform.position = temp;
	}

	
	
}
