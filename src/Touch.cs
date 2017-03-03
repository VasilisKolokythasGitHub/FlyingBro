using UnityEngine;
using System.Collections;

public class Touch : MonoBehaviour {
	private movement player;
	public bool moving;
	Animator animator_bro;
	public bool nok_3,nok_1,nok = false;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<movement>();
		moving=false;
		GameObject bro = GameObject.Find("myAnimationBros 1");
		animator_bro = bro.GetComponent<Animator> ();
		 
	
	}
	void Update()
	{
		GameObject nokiaa_3 = GameObject.Find ("nokia_3");
		nokia_3 n3 = nokiaa_3.GetComponent<nokia_3> ();
		nok_3 = n3.nokia;
		
		
		GameObject nokiaa_1 = GameObject.Find ("nokia_1");
		nokia_2 n1 = nokiaa_1.GetComponent<nokia_2> ();
		nok_1 = n1.nokia;
		
		GameObject nokia = GameObject.Find ("nokia");
		Nokia n = nokia.GetComponent<Nokia> ();
		nok = n.nokia;
	}
	public void UpArrow(){
		if (!nok && !nok_1 && !nok_3) {
		moving=true;
			player.Up (500);
			animator_bro.Play ("up_motion_animation");

		}
	}
	// Update is called once per frame
	public void DownArrow(){
		if (!nok && !nok_1 && !nok_3) {
			moving = true;
			animator_bro.Play ("down_motion_animation");
			player.Down (500);
		}
	}
	public void UnPressedUp(){
		if (!nok && !nok_1 && !nok_3) {
			animator_bro.Play ("Idle 1");
			moving = false;
			player.GetComponent<Rigidbody2D> ().Sleep ();
		}
	}
	public void UnPressedDown(){
		if (!nok && !nok_1 && !nok_3) {
			animator_bro.Play ("Idle 1");
			moving = false;
			player.GetComponent<Rigidbody2D> ().Sleep ();
		}
	}
}
