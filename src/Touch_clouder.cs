using UnityEngine;
using System.Collections;

public class Touch_clouder : MonoBehaviour {
	private movement_clouder player;
	public bool moving;
	Animator animator_bro;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<movement_clouder>();
		GameObject bro = GameObject.Find("myAnimationBros 1");
		animator_bro = bro.GetComponent<Animator> ();
		moving=false;
		
	}
	public void UpArrow(){
		moving=true;
		animator_bro.Play ("up_motion_animation");
		player.Up(300);
	}
	// Update is called once per frame
	public void DownArrow(){
		moving=true;
		animator_bro.Play ("down_motion_animation");
		player.Down(300);
	}
	public void UnPressedUp(){
		animator_bro.Play ("Idle 1");
		moving=false;
		player.GetComponent<Rigidbody2D>().Sleep();
	}
	public void UnPressedDown(){
		animator_bro.Play ("Idle 1");
		moving=false;
		player.GetComponent<Rigidbody2D>().Sleep();
	}
}