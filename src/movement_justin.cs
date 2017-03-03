using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using admob;
public class movement_justin : MonoBehaviour {
	//Vector3 rmovement = Vector3.right * 0.1f;
 
	public bool erwthseis;
	public bool pause;
	public Text energy_text;
	public int energy;
	public float forwardSpeed = 2f;
	public float upSpeed = 20f;
	public float downSpeed = 20f;
	public bool mov;
	public bool instruct = false;
	public bool nok = false;
	public bool bieber = false;
	public bool destr;
	public int first_time = 0;
	public bool changed;
	Vector3 velocity;
	float direction;
	float ddirection;
	Animator animator;
	bool finished = false;
	public bool exei_laser;
	public bool bounidi;
	public  Text Points;
	public int Score=0;
	public int current_score=0;
	public Image pause_stage;
	public Image restart_image;
	public Image continue_playing;
	public Image main_menu_image;
	public Text pause_text;
	bool thug_life;
	public int highscore_justin ;
	public int total = 0;
	int sc1,sc2,sc3;
	public bool destroyed1;
	public bool destroyed2;
	public bool destroyed3;
	public GameObject glasses;
	public GameObject hat;
	public int using_hat,using_glasses;
	public bool justin_1 = false;
	public bool justin_3 = false;
	string quit_Time;
	public int Total_Points_Justin,grandT;
	bool mama;
	void Start(){
		using_hat = PlayerPrefs.GetInt("using_hat");
		using_glasses = PlayerPrefs.GetInt("using_glasses");
		grandT = PlayerPrefs.GetInt("Grand_Total");
		mama = false;
		energy_text = energy_text.GetComponent<Text> ();
		destroyed1 = false;
		destroyed2 = false;
		destroyed3 = false;
		highscore_justin = PlayerPrefs.GetInt("highscore_justin");
		thug_life = false;
		pause = false;
//	 
		sc1 = 0;
		sc2 = 0;
		sc3 = 0;
		first_time = PlayerPrefs.GetInt("ft") ;
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
	

		animator = transform.GetComponentInChildren<Animator>();


	}
	void OnApplicationQuit()
	{
		grandT += Total_Points_Justin;
		PlayerPrefs.SetInt("Grand_Total",grandT);
		quit_Time = System.DateTime.Now.ToString();
		PlayerPrefs.SetString ("quit_Time",quit_Time);
		
	}
	// Use this for initialization

	
	// Update is called once per frame
	void FixedUpdate () {
		if(!mama)
		{
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
	public void Pause_DaGame()
	{
	 
		
		Time.timeScale = 0.0f;
		continue_playing.enabled = true;
		pause_text.enabled = true;
		pause_stage.enabled = true;
		restart_image.enabled = true;
		main_menu_image.enabled = true;
		pause = true;
		
	}
	void Update(){
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

		GameObject vel = GameObject.Find ("Da_instructions");
		Animator velakia = vel.GetComponent <Animator> ();
	//	if(first_time == 0){
		
		if (velakia.GetCurrentAnimatorStateInfo (0).IsName ("idle_instr") && !finished) {
			Time.timeScale = 0.0f;
			instruct = true;
			velakia.Play ("use_instruction");
		}
		if (Input.GetMouseButtonDown (0) && velakia.GetCurrentAnimatorStateInfo (0).IsName ("use_instruction")) {

			velakia.Play ("change");
		}
		if (Input.GetMouseButtonDown (0) && velakia.GetCurrentAnimatorStateInfo (0).IsName ("change")) {
			velakia.Play ("anywhere");
		}
		if (Input.GetMouseButtonDown (0) && velakia.GetCurrentAnimatorStateInfo (0).IsName ("anywhere")) {
			velakia.Play ("idle_instr");
			Time.timeScale = 1.0f;
			instruct = false;
			finished = true;
			first_time = 1;
			PlayerPrefs.SetInt ("ft", first_time);
		}
	//}

	 
		energy = PlayerPrefs.GetInt("energy");
		
		energy_text.text = "" + energy;
		if (energy == 0) {
			Application.LoadLevel(0);
		}
		GameObject skori = GameObject.Find ("Bro");
		movement_justin keimeno = skori.GetComponent<movement_justin> ();
		current_score = keimeno.Score;

	 





		GameObject player_object = GameObject.Find ("myAnimationBros 1");
		Vector3 player_pos_x = player_object.transform.position;
		Vector3 temp = player_object.transform.position;
		temp.x = player_object.transform.position.x;
		player_pos_x = temp;

		if (player_pos_x.x > 98) {
			animator.Play ("Thug_Life");
			erwthseis = true;
			GameObject girly = GameObject.Find ("home");
			Animator girlish = girly.GetComponent <Animator> ();
			girlish.Play ("mama_animation");
			mama = true;
			
		}
		 
		GameObject nokia_3 = GameObject.Find ("justinos_3");
		justin_3 n3 = nokia_3.GetComponent<justin_3> ();
		justin_3 = n3.just;
		
		
		GameObject nokia_1 = GameObject.Find ("justinos_2");
		justin_1 n1 = nokia_1.GetComponent<justin_1> ();
		justin_1 = n1.just;
		
		GameObject nokia = GameObject.Find ("justinos");
		justin n = nokia.GetComponent<justin> ();
		nok = n.just;
		
		sc1 = n1.score;
		sc2 = n.score;
		sc3 = n3.score;


		total = sc1 + sc2 + sc3;
		Points.text = "Points = " + total;
		if(bieber ){

			animator.Play("bieber_hit");

			animator.SetTrigger("Idle");
			bieber = false;
		}
		GameObject player = GameObject.Find ("ControlButtons");
		Touch_justin gateController = player.GetComponent<Touch_justin> ();
		mov = gateController.moving;

		GameObject destroyed = GameObject.Find ("justinos");
		justin efage_bounidi = destroyed.GetComponent<justin> ();
		destr = efage_bounidi.destroyed;
		 
		if ( total > highscore_justin) {
			
			PlayerPrefs.SetInt ("highscore_justin", total);
			
			
		}
		Total_Points_Justin = total;
		GameObject change = GameObject.Find("Laserous");
		ChooseWeapon l = change.GetComponent<ChooseWeapon>();
		changed = l.change_weapon;



		GameObject da_laser = GameObject.Find("Laserous");
		ChooseWeapon laser =  da_laser.GetComponent<ChooseWeapon>();
		exei_laser = laser.using_laser;

		GameObject using_punch = GameObject.Find("Laserous");
		ChooseWeapon bounia =  using_punch.GetComponent<ChooseWeapon>();
		bounidi = bounia.using_punch;

		if(Input.GetMouseButtonDown(0)&& !mov && !nok && !changed && !pause && !thug_life && !instruct && !erwthseis){

			if(bounidi){
			animator.Play("myAnimationBros 1");
			}
			if(exei_laser){
				animator.Play("Laserino");

			}
			
			animator.SetTrigger("Idle");
			

		}
		if ( nok || justin_1 || justin_3){
			bieber = true;
		}
		 
	}
	public void Return_to_MainMenu(){
		Time.timeScale = 1.0f;
		grandT += Total_Points_Justin;
		PlayerPrefs.SetInt("Grand_Total",grandT);
		Application.LoadLevel (0);
	}
	public void Restart_Stage(){
		Time.timeScale = 1.0f;
		grandT += Total_Points_Justin;
		PlayerPrefs.SetInt("Grand_Total",grandT);
		Application.LoadLevel(Application.loadedLevel);
	}
	public void Continue_Playing()
	{

		 
		Time.timeScale = 1.0f;
		continue_playing.enabled = false;
		pause_text.enabled = false;
		pause_stage.enabled = false;
		restart_image.enabled = false;
		main_menu_image.enabled = false;
		 
		pause = false;
	}


	
	
}
