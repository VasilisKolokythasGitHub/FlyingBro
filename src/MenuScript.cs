using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using admob;
public class MenuScript : MonoBehaviour {

	public Canvas quitMenu,energizer,Reminder;
	public Button Play;
	public Button Exit;
	public Button X;   //exit button
	public Canvas stages;
	public Text fly, exit_game;
	public Text title;
	public Text nokia_skori,your_energy;
	public Text cloud_skori;
	public Text justin_skori;
	int highscore_nokia;
	int highscore_justin;
	int highscore_cloud;
	public int energy;
	public int firstRun = 0;
	public Text Energy_Points;
	public bool bgike = false;
	Button fly_butt;
	float timer = 300.0f;
    string paused_Time,quit_Time,remaining_Time,current_Time;
	public int Grand_Total;
	public Text tPoints;
	public Text Shop;

	// Use this for initialization
	void Start () {
		tPoints = tPoints.GetComponent<Text>();
		Shop = Shop.GetComponent<Text>();
		Grand_Total = PlayerPrefs.GetInt("Grand_Total");
		firstRun = PlayerPrefs.GetInt("savedFirstRun") ;
		energizer = energizer.GetComponent<Canvas> ();
		Reminder = Reminder.GetComponent<Canvas> ();
		your_energy = your_energy.GetComponent<Text> ();
		Reminder.enabled = false;
		if (firstRun == 0) {  
			energy = 20;
			PlayerPrefs.SetInt ("energy", energy);
			firstRun =  1;
			PlayerPrefs.SetInt("savedFirstRun",firstRun) ;
			current_Time = System.DateTime.Now.ToString();
			PlayerPrefs.SetString ("quit_Time",current_Time);


		} else {
			energy = PlayerPrefs.GetInt ("energy");
			PlayerPrefs.SetInt ("energy", energy);
		}
		Energy_Points = Energy_Points.GetComponent<Text>();
		Energy_Points.text = ""+energy;
		nokia_skori = nokia_skori.GetComponent<Text>();
		cloud_skori = cloud_skori.GetComponent<Text>();

		justin_skori = justin_skori.GetComponent<Text>();
		quitMenu = quitMenu.GetComponent<Canvas>();
		stages = stages.GetComponent<Canvas>();
		Play = Play.GetComponent<Button>();
		title = title.GetComponent<Text> ();
		fly = fly.GetComponent<Text> ();
			exit_game = exit_game.GetComponent<Text>();
		Exit = Exit.GetComponent<Button>();
		X = X.GetComponent<Button>();
		stages.enabled = false;

		quitMenu.enabled = false;
		X.enabled = false;


		highscore_nokia = PlayerPrefs.GetInt("highscore");
		highscore_justin = PlayerPrefs.GetInt("highscore_justin");
		highscore_cloud = PlayerPrefs.GetInt("highscore_cloud");

		nokia_skori.text = "HighScore = " + highscore_nokia;
		justin_skori.text = "HighScore = " + highscore_justin;
		cloud_skori.text = "HighScore = " + highscore_cloud;
		quit_Time = "0";


	}


	void Update()
	{
		

		GameObject zzz = GameObject.Find ("glasses");
		shop_anim keimena = zzz.GetComponent<shop_anim> ();
		Grand_Total = keimena.gTotal;

 
		 
		GameObject zzz2 = GameObject.Find ("glasses");
		shop_anim keimena2= zzz2.GetComponent<shop_anim> ();
		energy = keimena2.das_energy;
		Energy_Points.text = ""+energy;
		PlayerPrefs.SetInt ("Grand_Total",Grand_Total); 
		tPoints.text = "Total Points = " + Grand_Total;
		 
		current_Time = System.DateTime.Now.ToString();
		 
			
			
			 
		if (energy == 0) {
			fly.enabled = false;
			Reminder.enabled = true;
			DateTime da_quit = Convert.ToDateTime (PlayerPrefs.GetString ("quit_Time"));
				
			DateTime date_current_Time = Convert.ToDateTime (current_Time);
				 
			TimeSpan difference = date_current_Time - da_quit;
			if (difference.TotalSeconds > 300) {
				reload ();
			}
			timer -= Time.deltaTime;
			int minutes = Mathf.FloorToInt (timer / 60F);
			//	Debug.LogError(difference);

			your_energy.text = "You will have +5 energy in: " + minutes + " minutes";
		} else {
			Reminder.enabled = false;
			fly.enabled = true;
		}


		 
		//		Debug.LogError (final_dif);
 
	}
	 
	void OnApplicationQuit()
	{
		PlayerPrefs.SetInt ("Grand_Total",Grand_Total); 
		if (energy == 0 && !bgike) {
			bgike = true;
			quit_Time = System.DateTime.Now.ToString ();
			PlayerPrefs.SetString ("quit_Time", quit_Time);
		//	Debug.LogError(quit_Time);
		}
	}

	void reload()
	{
		fly.enabled = true;
		Reminder.enabled = false;
		timer = 300.0f;
		energy += 5;
		PlayerPrefs.SetInt ("energy",energy);
		current_Time = System.DateTime.Now.ToString();
		PlayerPrefs.SetString ("quit_Time", current_Time);
		bgike = false;
	}
	public void ExitPress()
	{
		PlayerPrefs.SetInt ("Grand_Total",Grand_Total); 
		quitMenu.enabled = true;
		Play.enabled = false;
		Exit.enabled = false;
		X.enabled = true;
	}
	public void NoPress()
	{
		quitMenu.enabled = false;
		Play.enabled = true;
		Exit.enabled = true;
		X.enabled = false;
	}
	public void StartLevel()
	{
		Shop.enabled = false;
		quitMenu.enabled = false;
		X.enabled = false;
		title.enabled = false;
		Play.enabled = false;
		Exit.enabled = false;
		exit_game.enabled = false;
		fly.enabled = false;
		stages.enabled = true;
		//Application.LoadLevel(1);
	}

	public void Nokia_Stage()
	{
		Admob.Instance().removeBanner();
		Application.LoadLevel(1);
	}

	public void Justin_Stage()
	{
		Admob.Instance().removeBanner();
		Application.LoadLevel(2);
	}
	public void Load_Zero_Lvl()
	{
		Application.LoadLevel (0);
	}
	public void Clouder_Stage()
	{
		Admob.Instance().removeBanner();
		Application.LoadLevel (3);
	}

	public void ExitGame()

	{

		Application.Quit();

	}




}
