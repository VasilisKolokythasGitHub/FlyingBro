using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour {

	 
	public float Health=100;
	public float CurrentHealth;
	public int current_energy;
	public bool reduced = false;
	public int Total_Points_Nokia, Total_Points_Justin,gTotal;

	public void Damage(float value)
	{
		GameObject color = GameObject.Find("color");
		Image myImage = color.GetComponent<Image>();
		Health -= value;
		myImage.fillAmount = Health /100f;
		 
	 
	}
	 void Start()
	{
		gTotal = PlayerPrefs.GetInt("Grand_Total");

	}
	 public void Update(){
		GameObject color = GameObject.Find("color");
		Image myImage = color.GetComponent<Image>();
		CurrentHealth = myImage.fillAmount;
			current_energy = PlayerPrefs.GetInt ("energy");


			GameObject tot_n = GameObject.Find ("Bro");
			movement keimeno = tot_n.GetComponent<movement> ();
		if (keimeno != null) {
			Total_Points_Nokia = keimeno.Total_Points_Nokia;
		}
		GameObject tot_j = GameObject.Find ("Bro");
		movement_justin keimeno2 = tot_j.GetComponent<movement_justin> ();
		if (keimeno2 != null) {
			Total_Points_Justin = keimeno2.Total_Points_Justin;
		}

		if(CurrentHealth <= 0 && reduced == false){

			decrease();
			StartCoroutine(MyMethod());
		}
	}
	IEnumerator MyMethod() {
		
		yield return new WaitForSeconds(1);
		Application.LoadLevel(Application.loadedLevel);
		
	}
	void decrease()
	{
		GameObject tot_n = GameObject.Find ("Bro");
		movement keimeno = tot_n.GetComponent<movement> ();
		if (keimeno != null) {
			gTotal = gTotal + Total_Points_Nokia;
			PlayerPrefs.SetInt("Grand_Total",gTotal);

		}



		GameObject tot_j = GameObject.Find ("Bro");
		movement_justin keimeno2 = tot_j.GetComponent<movement_justin> ();
		if (keimeno2 != null) {
			gTotal = gTotal + Total_Points_Justin;
			PlayerPrefs.SetInt("Grand_Total",gTotal);

		}

		reduced = true;
		current_energy -= 1;

		PlayerPrefs.SetInt("energy",current_energy);
	}
	
	 
}
