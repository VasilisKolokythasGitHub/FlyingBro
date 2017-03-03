using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using admob;

public class Scroll_Script_Main_Menu : MonoBehaviour {
	public float speed=0;

	public int energy;
	public Text Energy_Points,getFree;
	public Canvas Remind;
	void Start()
	{
		getFree = getFree.GetComponent<Text> ();
		Energy_Points = Energy_Points.GetComponent<Text>();
		energy = PlayerPrefs.GetInt ("energy");
		AdManager.Instance.ShowBanner ();
		Remind = Remind.GetComponent<Canvas> ();
	}
	void  Update () {
		Application.targetFrameRate = 60;
		GameObject zzz2 = GameObject.Find ("glasses");
		shop_anim keimena2= zzz2.GetComponent<shop_anim> ();
		energy = keimena2.das_energy;
		Energy_Points.text = ""+energy;
		Vector2 offset = GetComponent<Renderer>().material.mainTextureOffset;
		offset.x += speed * (Time.deltaTime/10);
		offset.x = (offset.x)%1;
		GetComponent<Renderer>().material.mainTextureOffset = offset;
		 

	}



}

