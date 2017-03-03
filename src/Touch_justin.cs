using UnityEngine;
using System.Collections;

public class Touch_justin : MonoBehaviour {
	private movement_justin player;
	public bool moving;
	Animator animator_bro;
	public bool bieber = false;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<movement_justin>();
		GameObject bro = GameObject.Find("myAnimationBros 1");
		animator_bro = bro.GetComponent<Animator> ();
		moving=false;
		
	}

	void Update()
	{
		GameObject bieberino = GameObject.Find ("Bro");
		movement_justin j = bieberino.GetComponent<movement_justin> ();
		bieber = j.bieber;
	}
	public void UpArrow(){
		if (!bieber) {
			moving = true;
			animator_bro.Play ("up_motion_animation");
			player.Up (300);
		}
	}
	// Update is called once per frame
	public void DownArrow(){
		if (!bieber) {
			moving = true;
			animator_bro.Play ("down_motion_animation");
			player.Down (300);
		}
	}
	public void UnPressedUp(){
		if (!bieber) {
			animator_bro.Play ("Idle 1");
			moving = false;
			player.GetComponent<Rigidbody2D> ().Sleep ();
		}
	}
	public void UnPressedDown(){
		if (!bieber) {
			animator_bro.Play ("Idle 1");
			moving = false;
			player.GetComponent<Rigidbody2D> ().Sleep ();
		}
	}
}
