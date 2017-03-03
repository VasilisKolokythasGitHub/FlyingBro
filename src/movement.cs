using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using admob;
public class movement : MonoBehaviour {
	//Vector3 rmovement = Vector3.right * 0.1f;
 
	public bool erwthseis;
	public float forwardSpeed = 2f;
	public float upSpeed = 20f;
	public Text  energy_text;
	public float downSpeed = 20f;
	public bool mov, dos_grandes = false;
	public bool pause;
	public bool nok = false;
	public bool nok_1 = false;
	public bool nok_3 = false;
	public bool sms = false;
	Vector3 velocity;
	public AudioSource audio;
	float direction;
	float ddirection;
	Animator animator;
	public bool changed;
	public bool bounidi;
	public  Text Points;
	public bool exei_laser;
	public int Score=0;
	public int total = 0;
	int sc1,sc2,sc3;
	public int current_score=0;
	public Image pause_stage;
	public Image restart_image;
	public Image continue_playing;
	public Image main_menu_image;
	public int Total_Points_Nokia,grandT;
	public Text pause_text;
	bool thug_life;
	public int highscore,energy ;
	public bool destroyed1;
	public GameObject glasses;
	public GameObject hat;
	public int using_hat,using_glasses;
	public bool destroyed2;
	public bool destroyed3;
	string quit_Time;
	bool hapi;

	void Start(){
		using_hat = PlayerPrefs.GetInt("using_hat");
		using_glasses = PlayerPrefs.GetInt("using_glasses");
		grandT = PlayerPrefs.GetInt("Grand_Total");
		energy_text = energy_text.GetComponent<Text> ();
		destroyed1 = false;
		destroyed2 = false;
		destroyed3 = false;
		sc1 = 0;
		sc2 = 0;
		sc3 = 0;
		  highscore = PlayerPrefs.GetInt("highscore");

		thug_life = false;
		pause = false;
		//audio = audio.GetComponent<AudioSource>();
	 
		pause_stage = pause_stage.GetComponent<Image> ();
	
		restart_image = restart_image.GetComponent<Image> ();
		continue_playing = continue_playing.GetComponent<Image> ();
		main_menu_image = main_menu_image.GetComponent<Image> ();
	 
		pause_text = pause_text.GetComponent<Text> ();
		 
		 
		pause_stage.enabled = false;
		restart_image.enabled = false;
		continue_playing.enabled = false;
		main_menu_image.enabled = false;
	 
	 
		pause_text.enabled = false;


		Points.text = "Points = " + Score;
		 
		
		 
		 


		animator = transform.GetComponentInChildren<Animator>();
	}
	// Use this for initialization
	

	void OnApplicationQuit()
	{
		grandT += Total_Points_Nokia;
		PlayerPrefs.SetInt("Grand_Total",grandT);
		quit_Time = System.DateTime.Now.ToString();
		PlayerPrefs.SetString ("quit_Time",quit_Time);
		
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (!hapi) {
			Vector3 temp = gameObject.transform.position;
			temp.x += forwardSpeed * Time.deltaTime;
			gameObject.transform.position = temp;
		}
		
		
		
		
		
		
		
		
	}
	public void Up(float upSpeed){
		GetComponent<Rigidbody2D>().AddForce(Vector3.up*upSpeed);

		
	}
	public void Down(float downSpeed){
		
		GetComponent<Rigidbody2D>().AddForce(Vector3.down*downSpeed);
		
	}
	void Update()
	{ 
		
		Renderer rend = glasses.GetComponent<Renderer>();
		Renderer rend2 = hat.GetComponent<Renderer>();
		if (using_glasses == 1) {
			rend.enabled = true;
		} else {
			rend.enabled = false;
		}
		if (using_hat == 1) {
			rend2.enabled = true;
		} else {
			rend2.enabled = false;
		}
		energy = PlayerPrefs.GetInt("energy");
		
		energy_text.text = "" + energy;
		if (energy == 0) {
			Application.LoadLevel(0);
		}

		 
		GameObject player_object = GameObject.Find ("myAnimationBros 1");
		Vector3 player_pos_x = player_object.transform.position;
		Vector3 temp = player_object.transform.position;
		temp.x = player_object.transform.position.x;
		player_pos_x = temp;
		if (player_pos_x.x > 168) {
			animator.Play ("Thug_Life");
			erwthseis = true;
			GameObject broly = GameObject.Find ("bro_figure");
			Animator broish = broly.GetComponent <Animator> ();
			broish.Play ("happy_da_bro");
			hapi = true;
		}
		 
		//	if (player_pos_x.x > 4) 
//		{

		 
		//		GameObject nokiaz = GameObject.Find("Nokias");
		//		Vector3 scale = transform.localScale;
		//		scale.x = 1.7f; 
		//		scale.y = 1.7f;
		//		nokiaz.transform.localScale = scale;
		//	}


		GameObject skori = GameObject.Find ("Bro");
		movement keimeno = skori.GetComponent<movement> ();
		current_score = keimeno.total;
		
		 
		 

		 
		GameObject player = GameObject.Find ("ControlButtons");
		Touch gateController = player.GetComponent<Touch> ();
		mov = gateController.moving;


		
		 

	 

		if(sms){
			
			GameObject.Find("Health Bar").GetComponent<HealthBar>().Damage(10);
			
			sms= false;
		}

		GameObject nokia_3 = GameObject.Find ("nokia_3");
		nokia_3 n3 = nokia_3.GetComponent<nokia_3> ();
		nok_3 = n3.nokia;


		GameObject nokiaa_1 = GameObject.Find ("nokia_1");
		nokia_2 n1 = nokiaa_1.GetComponent<nokia_2> ();
		nok_1 = n1.nokia;

		GameObject nokia = GameObject.Find ("nokia");
		Nokia n = nokia.GetComponent<Nokia> ();
		nok = n.nokia;

		sc1 = n1.score;
		sc2 = n.score;
		sc3 = n3.score;
		total = sc1 + sc2 + sc3;
		Points.text = "Points = " + total;


		if ( total > highscore) {
			
			PlayerPrefs.SetInt ("highscore", total);
			
			
		}
		Total_Points_Nokia = total;


		GameObject change = GameObject.Find("Laserous");
		ChooseWeapon l = change.GetComponent<ChooseWeapon>();
		changed = l.change_weapon;
		
		GameObject da_laser = GameObject.Find("Laserous");
		ChooseWeapon laser =  da_laser.GetComponent<ChooseWeapon>();
		exei_laser = laser.using_laser;
		
		GameObject using_punch = GameObject.Find("Laserous");
		ChooseWeapon bounia =  using_punch.GetComponent<ChooseWeapon>();
		bounidi = bounia.using_punch;
		
		if(nok || nok_1 || nok_3){
			GetComponent<Rigidbody2D>().AddForce(Vector2.left*100f);
			Vector3 destination = new Vector3(0,0,30);
			transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, 
			                                     destination, 
			                                     Time.deltaTime);

			animator.Play ("almost_dead");
			Almost_dead();
				
			// gameObject.GetComponentInChildren<Renderer>().enabled = false;
			// animator.enabled = false;
			
		}

		 
		
		if(Input.GetMouseButtonDown(0)&& !pause && !mov && !nok && !nok_1 && !nok_3 && !sms && !changed && !thug_life && !erwthseis)
		{
			
			if(bounidi){
				animator.Play("myAnimationBros 1");
			}
			if(exei_laser){
				animator.Play("Laserino");
				
			}
			
			animator.SetTrigger("Idle");
			
			
		}
		
		
		
		
	}

	IEnumerator Almost_dead()
	{
		 
		yield return new WaitForSeconds(1/2);
		if (!dos_grandes) {
			grandT += Total_Points_Nokia;
			PlayerPrefs.SetInt ("Grand_Total", grandT);
			dos_grandes = true;
		}
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.velocity = Vector3.zero;
		rb.angularVelocity = 0f;
	}
	
	
	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.tag == "Sms"){
			sms = true;
			
		}

		 

	}


	
	public void Return_to_MainMenu(){
		Time.timeScale = 1.0f;
		grandT += Total_Points_Nokia;
		PlayerPrefs.SetInt("Grand_Total",grandT);
		Application.LoadLevel (0);
	}
	public void Restart_Stage(){
		Time.timeScale = 1.0f;
		grandT += Total_Points_Nokia;
		PlayerPrefs.SetInt("Grand_Total",grandT);
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void Pause_DaGame()
	{
		
		//audio.mute = true;
		
		Time.timeScale = 0.0f;
		continue_playing.enabled = true;
		pause_text.enabled = true;
		pause_stage.enabled = true;
		restart_image.enabled = true;
		main_menu_image.enabled = true;
		pause = true;
	}
	public void Continue_Playing()
	{
		
		//audio.mute = true;
		Time.timeScale = 1.0f;
		continue_playing.enabled = false;
		pause_text.enabled = false;
		pause_stage.enabled = false;
		restart_image.enabled = false;
		main_menu_image.enabled = false;
		//audio.Play();
		pause = false;
	}
	
}
