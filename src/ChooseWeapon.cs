using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ChooseWeapon : MonoBehaviour {
 
	public Image Punch;
	public Image Laser;
	public bool change_weapon=false;
	public bool using_laser = false;
	public bool using_punch = false;
	int firstRun = 0;

	// Use this for initialization
	void Start () {
		firstRun = PlayerPrefs.GetInt("savedFirstRun") ;
		Punch = Punch.GetComponent<Image>();
		Laser = Laser.GetComponent<Image>();
		Punch.enabled = false;
		using_laser = true;

		if (firstRun == 0) { // remember "==" for comparing, not "=" which assigns value
			Debug.LogError ("Press arrows to move/Tap to fire/Press on weapons to change weapon");
			firstRun = 1;
		}
	 
	}
	// Update is called once per frame
	public void Laserino () {
		using_laser=true;
		using_punch=false;
		Laser.enabled = true;
		Punch.enabled = false;
		change_weapon = true;
	}

	public void Punchino(){
		using_laser=false;
		using_punch=true;
		Punch.enabled = true;
		Laser.enabled = false;
		change_weapon = true;

	}
	public void UnPressed(){
		change_weapon = false;
	}
}
