using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gkomena : MonoBehaviour {

	public Image pause_butt;
	public Canvas shoes,love,fat,hello,lisa,i_love_u,break_up,died,Controls,Da_Points;
	public Image her,died2,hello_image,hello_her;
	public Text erwt,ans1,ans2,ans3,ans4,energy_text,hello_text;
	public int energy,current_score;
	public bool finished = false;
	private bool wrong = false;
	public Image heart1;
	public Image heart2;
	public int current_energy;
	// Use this for initialization
	void Start () {
		heart1 = heart1.GetComponent<Image>();
		heart2 = heart2.GetComponent<Image> ();
		energy_text = energy_text.GetComponent<Text> ();
		pause_butt = pause_butt.GetComponent<Image>();
		hello_image = 	hello_image.GetComponent<Image>();
		hello_her = 	hello_her.GetComponent<Image>();
		hello_text = hello_text.GetComponent<Text> ();
		died = died.GetComponent<Canvas>();
		love = love.GetComponent<Canvas>();
		fat = fat.GetComponent<Canvas>();
		shoes = shoes.GetComponent<Canvas>();
		lisa = lisa.GetComponent<Canvas>();
		her = her.GetComponent<Image>();
		died2 = died2.GetComponent<Image>();
		erwt = erwt.GetComponent<Text>();
		ans1 = ans1.GetComponent<Text>();
		ans2 = ans2.GetComponent<Text>();
		ans3 = ans3.GetComponent<Text>();
		ans4 = ans4.GetComponent<Text>();
		i_love_u = i_love_u.GetComponent<Canvas>();
		break_up = break_up.GetComponent<Canvas>();
		Da_Points = Da_Points.GetComponent<Canvas>();
		Controls = Controls.GetComponent<Canvas> ();
	 
		 
		hello.enabled = false;
		love.enabled = false;
		fat.enabled = false;
		shoes.enabled = false;
		lisa.enabled = false;
		 
		i_love_u.enabled = false;
		break_up.enabled = false;
		ans1.enabled = false;
		ans2.enabled = false;
		ans3.enabled = false;
		ans4.enabled = false;
		erwt.enabled = false;
		her.enabled = false;
		died2.enabled = false;
	}
	void Update()
	{
		current_energy = PlayerPrefs.GetInt ("energy");
		GameObject skori = GameObject.Find ("Bro");
		movement_clouder keimeno = skori.GetComponent<movement_clouder> ();
		current_score = keimeno.total;

		if (current_score < 16000) {
			hello_text.text = "Only "+current_score+" you could do better...";
		} else {

			hello_text.text = "Hmmm "+current_score+" your score was good...";
		}

		energy = PlayerPrefs.GetInt("energy");
 
		energy_text.text = "" + energy;

		if (energy == 0) {
			
			Application.LoadLevel(0);
		}

		GameObject player_object = GameObject.Find ("Bro");
		
		Vector3 player_pos_x = player_object.transform.position;
		
		
		Vector3 temp = player_object.transform.position;
		temp.x = player_object.transform.position.x;
		player_pos_x = temp;

		if (player_pos_x.x >148) {
			pause_butt.enabled = false;
			GameObject nokia_3 = GameObject.Find ("clouds_3");
			Rigidbody2D n3 = nokia_3.GetComponent<Rigidbody2D>();
			GameObject gk = GameObject.Find ("To_animation");
			Animator gkomenaki = gk.GetComponent <Animator>();
			gkomenaki.Play ("da_anim_gf");
			GameObject nokiaa_1 = GameObject.Find ("clouds_2");
			Rigidbody2D n2 = nokiaa_1.GetComponent<Rigidbody2D>();
			GameObject nokia = GameObject.Find ("clouds");
			Rigidbody2D n = nokia.GetComponent<Rigidbody2D>();
			BoxCollider2D b1 = n.GetComponent<BoxCollider2D> ();
			BoxCollider2D b2 = n2.GetComponent<BoxCollider2D> ();
			BoxCollider2D b3 = n3.GetComponent<BoxCollider2D> ();



			b1.enabled = false;
			b2.enabled = false;
			b3.enabled = false;
			StartCoroutine("wat2");
		}
		 
	}
	public IEnumerator wat() {
	
		yield return new WaitForSeconds (5);

		Application.LoadLevel(Application.loadedLevel);
	}
	public IEnumerator wat2() {
		yield return new WaitForSeconds (3);
		hello.enabled = true;
		yield return new WaitForSeconds (3);
		hello_text.enabled = false;
		hello_her.enabled = false;
		hello_image.enabled = false;
		finished = true;
		Controls.enabled = false;
		Da_Points.enabled = false;
		ans1.enabled = true;
		ans2.enabled = true;
		ans3.enabled = true;
		ans4.enabled = true;
		erwt.enabled = true;
		her.enabled = true;
		died2.enabled = true;
		 
	}

	public void died_swsto()
	{
		died.enabled = false;
	 
		fat.enabled = true;
	}
	public void fat_swsto()
	{
		fat.enabled = false;
		shoes.enabled = true;
	}
	public void shoes_swsto()
	{
		shoes.enabled = false;
		lisa.enabled = true;
	}
	public void love_swsto()
	{
		lisa.enabled = false;
		love.enabled = true;
	 
	}
	public void lisa_swsto()
	{
		love.enabled = false;
		i_love_u.enabled = true;
 
	}

	public void love_poulo()
	{
		heart1.enabled = false;
		if (wrong) {
			
			heart2.enabled = false;
			lisa.enabled = true;
			break_up.enabled = true;
			current_energy -= 1;
			PlayerPrefs.SetInt("energy",current_energy);
			
			StartCoroutine("wat");
		}
		wrong = true;
	}
	public void shoes_poulo()
	{
		heart1.enabled = false;
		if (wrong) {
			
			heart2.enabled = false;
			lisa.enabled = true;
			break_up.enabled = true;
			current_energy -= 1;
			PlayerPrefs.SetInt("energy",current_energy);
			
			StartCoroutine("wat");
		}
		wrong = true;
	}
	public void fat_poulo()
	{
		heart1.enabled = false;
		if (wrong) {
			
			heart2.enabled = false;
			lisa.enabled = true;
			break_up.enabled = true;
			current_energy -= 1;
			PlayerPrefs.SetInt("energy",current_energy);
			
			StartCoroutine("wat");
		}
		wrong = true;
	}
	public void lisa_poulo()
	{
		heart1.enabled = false;
		if (wrong) {
			
			heart2.enabled = false;
			lisa.enabled = true;
			break_up.enabled = true;
			current_energy -= 1;
			PlayerPrefs.SetInt("energy",current_energy);
			
			StartCoroutine("wat");
		}
		wrong = true;
	}
	public void died_poulo()
	{
	 
		heart1.enabled = false;
		if (wrong) {
			
			heart2.enabled = false;
			lisa.enabled = true;
			break_up.enabled = true;
			current_energy -= 1;
			PlayerPrefs.SetInt("energy",current_energy);
			
			StartCoroutine("wat");
		}
		wrong = true;
 

	}
	// Update is called once per frame
	 
}
