using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using admob;
public class movement_clouder : MonoBehaviour {
	//Vector3 rmovement = Vector3.right * 0.1f;
	Transform player;
	public bool erwthseis;
	public bool finished = false;
	public float forwardSpeed = 2f;
	public float upSpeed = 20f;
	public bool kamenos;
	public float downSpeed = 20f;
	public bool mov,dos_grandes = false;
	public bool pause;
	public bool kopanhse = false;
	public bool kopanhse2 = false;
	public bool kopanhse3 = false;
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
	public int Score=0,grandT;
	public int current_score=0;
	public Image pause_stage;
	public Image restart_image;
	public Image continue_playing;
	public Image main_menu_image;
	public Text pause_text;
	bool thug_life; 
	public int highscore_cloud ;
	public int total = 0;
	int sc1,sc2,sc3;
	public bool clouds_1 = false;
	public bool clouds_2 = false;
	public bool kamenos2 = false;
	public bool kamenos3 = false;
	public bool clouds_3 = false;
	public bool girl = false;
	string quit_Time;
	public GameObject glasses;
	public GameObject hat;
	public int using_hat,using_glasses;
	public int Total_Points_Clouder;
	void Start(){
		using_hat = PlayerPrefs.GetInt("using_hat");
		using_glasses = PlayerPrefs.GetInt("using_glasses");
		grandT = PlayerPrefs.GetInt("Grand_Total");
		highscore_cloud = PlayerPrefs.GetInt("highscore_cloud");
		thug_life = false;
		pause = false;

		 
		sc1 = 0;
		sc2 = 0;
		sc3 = 0;
		audio = audio.GetComponent<AudioSource>();
		 
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
	
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!girl) {
			Vector3 temp = gameObject.transform.position;
			temp.x += forwardSpeed * Time.deltaTime;
			gameObject.transform.position = temp;
		}
		
		
		
		
		
		
		
		
	}
	public void Up(float upSpeed){
		
		GetComponent<Rigidbody2D>().AddForce(Vector2.up*upSpeed);
		
	}
	public void Down(float downSpeed){
		
		GetComponent<Rigidbody2D>().AddForce(Vector2.down*downSpeed);
		
	}
	IEnumerator my_girl() {
		 
		yield return new WaitForSeconds(2);
		 
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
		GameObject player_object = GameObject.Find ("Bro");
 
		Vector3 player_pos_x = player_object.transform.position;


		Vector3 temp = player_object.transform.position;
		temp.x = player_object.transform.position.x;
		player_pos_x = temp;
		if(player_pos_x.x > 148)
		{
			animator.Play ("Thug_Life");
			erwthseis= true;
			my_girl();
			GameObject girly = GameObject.Find ("girl");
			Animator girlish = girly.GetComponent <Animator>();
			girlish.Play ("free_da_girl");
			girl = true;
 
			
		}
		 
		//	if (player_pos_x.x > 4) 
		//		{
		
		
		//		GameObject cloudz = GameObject.Find("Clouders");
		//		Vector3 scale = transform.localScale;
		//		scale.x = 1.7f; 
		//		scale.y = 1.7f;
		//		cloudz.transform.localScale = scale;
		//	}
		
		
		GameObject skori = GameObject.Find ("Bro");
		movement_clouder keimeno = skori.GetComponent<movement_clouder> ();
		current_score = keimeno.Score;

		GameObject fin = GameObject.Find ("Initial Hello");
		gkomena gf = fin.GetComponent<gkomena> ();
		finished = gf.finished;

		GameObject kapsimo = GameObject.Find ("clouds");
		clouder kahla = kapsimo.GetComponent<clouder> ();
		kamenos = kahla.kamenos;

		GameObject kapsimo2 = GameObject.Find ("clouds_2");
		clouder_2 kahla2 = kapsimo2.GetComponent<clouder_2> ();
		kamenos2 = kahla2.kamenos2;

		GameObject kapsimo3 = GameObject.Find ("clouds_3");
		clouder_3 kahla3 = kapsimo3.GetComponent<clouder_3> ();
		kamenos3 = kahla3.kamenos3;
		
		 


		
		GameObject player = GameObject.Find ("ControlButtons_clouder");
		Touch_clouder gateController = player.GetComponent<Touch_clouder> ();
		mov = gateController.moving;
		Points.text = "Points = " + Score;
		if(sms){
			
			GameObject.Find("Health Bar").GetComponent<HealthBar>().Damage(10);
			
			sms= false;
		}

		
		GameObject cloud3 = GameObject.Find ("clouds_3");
		clouder_3 c3 = cloud3.GetComponent<clouder_3> ();
		clouds_3 = c3.kopanhse3;
		
		
		GameObject cloud2 = GameObject.Find ("clouds_2");
		clouder_2 c2 = cloud2.GetComponent<clouder_2> ();
		clouds_2 = c2.kopanhse2;
		
		GameObject clouds1 = GameObject.Find ("clouds");
		clouder c = clouds1.GetComponent<clouder> ();
		clouds_1 = c.kopanhse;
		
		sc1 = c.score;
		sc2 = c2.score;
		sc3 = c3.score;
		total = sc1 + sc2 + sc3;
		Points.text = "Points = " + total;
		Total_Points_Clouder = total;


		if ( total > highscore_cloud) {
			
			PlayerPrefs.SetInt ("highscore_cloud", total);
			
			
		}
		GameObject change = GameObject.Find("Laserous");
		ChooseWeapon l = change.GetComponent<ChooseWeapon>();
		changed = l.change_weapon;
		
		GameObject da_laser = GameObject.Find("Laserous");
		ChooseWeapon laser =  da_laser.GetComponent<ChooseWeapon>();
		exei_laser = laser.using_laser;
		
		GameObject using_punch = GameObject.Find("Laserous");
		ChooseWeapon bounia =  using_punch.GetComponent<ChooseWeapon>();
		bounidi = bounia.using_punch;


		if (kamenos || kamenos2 || kamenos3) 
		{


			animator.Play ("kamenos");
			GetComponent<Rigidbody2D>().AddForce( Vector2.down * 5f );
			GameObject.Find("Health Bar").GetComponent<HealthBar>().Damage(100);
			setGrand();
			GameObject Floor = GameObject.Find ("Floor");
			Floor.GetComponent<BoxCollider2D>().isTrigger = true;
			 
		}
		if(kopanhse || kopanhse2 || kopanhse3){
			
			//animator.Play("Hit");
			// gameObject.GetComponentInChildren<Renderer>().enabled = false;
			// animator.enabled = false;
			
		}
		
		if(Input.GetMouseButtonDown(0)&& !pause && !mov && !sms && !changed && !thug_life && !kamenos && !kamenos2 && !kamenos3 && !finished && !erwthseis)
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
	public void setGrand(){
		if (!dos_grandes) {
			grandT += Total_Points_Clouder;
			PlayerPrefs.SetInt ("Grand_Total", grandT);
			dos_grandes = true;
		}
	}
	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.tag == "Sms"){
			sms = true;
			
		}

	}
	
	
	public void Return_to_MainMenu(){
		Time.timeScale = 1.0f;
		grandT += Total_Points_Clouder;
		PlayerPrefs.SetInt("Grand_Total",grandT);
		Application.LoadLevel (0);
	}
	public void Restart_Stage(){
		Time.timeScale = 1.0f;
		grandT += Total_Points_Clouder;
		PlayerPrefs.SetInt("Grand_Total",grandT);
		Application.LoadLevel(Application.loadedLevel);
	}
	public void LoadNewStage()
	{
		Application.LoadLevel (1);
	}
	
	public void Pause_DaGame()
	{
		
		audio.mute = true;
		
		Time.timeScale = 0.0f;
		continue_playing.enabled = true;
		pause_text.enabled = true;
		pause_stage.enabled = true;
		restart_image.enabled = true;
		main_menu_image.enabled = true;
		pause = true;
	}
	void OnApplicationQuit()
	{
		quit_Time = System.DateTime.Now.ToString();
		grandT += Total_Points_Clouder;
		PlayerPrefs.SetInt("Grand_Total",grandT);
		PlayerPrefs.SetString ("quit_Time",quit_Time);
	}
		public void Continue_Playing()
	{
		 
		 

		audio.mute = true;
		Time.timeScale = 1.0f;
		continue_playing.enabled = false;
		pause_text.enabled = false;
		pause_stage.enabled = false;
		restart_image.enabled = false;
		main_menu_image.enabled = false;
		audio.Play();
		pause = false;
	}
	
}
