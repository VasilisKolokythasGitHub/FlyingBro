using UnityEngine;
using System.Collections;

public class nokia_3 : MonoBehaviour {
	public float forwardSpeed = 3f;
	public float SmsSpeed = 12f;
 
	bool destroyed3 ;
	Vector3 velocity;
	public bool nokia=false;
	public bool da_loop = true;
	Animator animator;
	public GameObject[] enemies;
	public int score;
	public int amount;
	Vector3 spawnPoint;
	public bool exei_laser;
	
	public Vector3 playerpos;
	void Start(){
		 
		destroyed3 = false;
		StartCoroutine(Spawner());
		animator = transform.GetComponentInChildren<Animator>();
		GameObject skori = GameObject.Find ("Bro");
		movement keimeno = skori.GetComponent<movement> ();
		 
	}
	
	
	void Update(){

		GameObject da_laser = GameObject.Find("Laserous");
		ChooseWeapon laser =  da_laser.GetComponent<ChooseWeapon>();
		exei_laser = laser.using_laser;

		GameObject skori = GameObject.Find ("Bro");
		movement keimeno = skori.GetComponent<movement> ();
		 
		
		 
		
		movement destroyedthree = skori.GetComponent<movement> ();
		 
		
		 
		
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		
		
		if(collider.tag == "Player"  && exei_laser){     //pethane
			
			animator.Play("break");
			score += 1600;
			
			
			GetComponent<Rigidbody2D>().AddForce( Vector2.up * 450f );
			destroyed3 = true;
		}

		if(collider.tag == "Player"  && !exei_laser){     //pethane
			
			animator.Play("break");
			score += 3000;
			
			
			GetComponent<Rigidbody2D>().AddForce( Vector2.up * 450f );
			destroyed3 = true;
		}

		if(collider.tag == "UnPunch" && !destroyed3 ){     //pethane
			
			nokia = true;
			GameObject gameObject = GameObject.Find ("nokia");
			//gameObject.GetComponent<Renderer>().enabled = false;
			GameObject.Find("Health Bar").GetComponent<HealthBar>().Damage(100);
			StartCoroutine(MyMethod());
			
			//Debug.LogError("Dead!");
		}
		
		
		
		if(collider.tag == "BGLooper"){
			
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			animator.Play("unbreakable");
			 
			destroyed3 = false;
			Vector3 pos = transform.position;
			
			pos.y = Random.Range(10, 20);        
			
			pos.x += Random.Range (1,3);
			
			
			transform.position = pos;
		}
		
	}
	
	IEnumerator MyMethod() {
		
		yield return new WaitForSeconds(1);
		Application.LoadLevel(1);
		
	}
	void FixedUpdate () {
		Vector3 temp = gameObject.transform.position;
		temp.x -= forwardSpeed * Time.deltaTime;
		gameObject.transform.position = temp;
	}
	public IEnumerator Spawner(){

		GameObject Sms_Handler_3;
		
		 
		GameObject nokia_3 = GameObject.Find ("nokia_3");
		
		
		while(da_loop){
			 
			 Sms_Handler_3 = Instantiate(Resources.Load("sms"),nokia_3.transform.position,Quaternion.identity) as GameObject;
		 
			Sms_Handler_3.GetComponent<Rigidbody2D>().AddForce(Vector2.left*800f);
			yield return new WaitForSeconds(0.5f);
		}
		
	}
	
	
}

