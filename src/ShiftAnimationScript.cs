using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShiftAnimationScript : MonoBehaviour {

	Animator animator;
	Animator animator_justin;
	Animator animator_clouder;
	public Image nokia_stage;
	public Image justin_stage;
	public bool left_pressed;
	public bool right_pressed;
	 

	public void ShiftLeft()
	{

		right_pressed = false;
		left_pressed = true;


		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("shiftNokiaFromRight")) {
			animator.Play ("ShiftRightAnimation");
			animator_clouder.Play ("ShiftCloudRight");

		}

		if (animator_clouder.GetCurrentAnimatorStateInfo (0).IsName ("ShiftCloudRight")) {
			animator_justin.Play ("ShiftJustinFromLeft");
			animator_clouder.Play ("ShiftCloudAway");
		}
		 
		if (animator_clouder.GetCurrentAnimatorStateInfo (0).IsName ("ShiftCloudLeft")) {
			animator_clouder.Play ("ShiftCloudAway");
			animator_justin.Play ("ShiftJustinFromLeft");
		}
		
	}
	public void ShiftRight()
	{



		if (animator_justin.GetCurrentAnimatorStateInfo (0).IsName ("ShiftJustinFromRight")) {
			animator_clouder.Play ("ShiftCloudLeft");
			animator_justin.Play ("ShiftJustinLeft");
		}



		if (animator_clouder.GetCurrentAnimatorStateInfo (0).IsName ("ShiftCloudLeft")) {
			animator.Play ("shiftNokiaFromRight");
			animator_clouder.Play("synnefoAristera");
		}
		if (animator_clouder.GetCurrentAnimatorStateInfo (0).IsName ("ShiftCloudRight")) {
			animator_clouder.Play ("synnefoAristera");
			animator.Play ("shiftNokiaFromRight");
		}
		if (animator_justin.GetCurrentAnimatorStateInfo (0).IsName ("ShiftJustinFromLeft")) {
			animator_clouder.Play ("ShiftCloudLeft");
			animator_justin.Play ("ShiftJustinLeft");
		}
		if (animator.GetCurrentAnimatorStateInfo (0).IsName ("ShiftNokiaFromLeft")) {
			animator.Play ("shiftNokiaLeft");
			animator_justin.Play ("ShiftJustinFromRight");
			
		}
		
		
	}
	// Use this for initialization
	void Start () {	
		GameObject justins_stage = GameObject.Find("justin_stage");
		GameObject clouder_stage = GameObject.Find("clouder_stage");
		animator_justin = justins_stage.GetComponent<Animator> ();
		left_pressed = false;
		right_pressed = false;
		animator = transform.GetComponentInChildren<Animator>();
		animator_clouder = clouder_stage.GetComponent<Animator> ();
		nokia_stage = nokia_stage.GetComponent<Image>();
		justin_stage = justin_stage.GetComponent<Image> ();
	

	}

}
