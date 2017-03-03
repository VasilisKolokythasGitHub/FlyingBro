using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class shop_anim : MonoBehaviour {
	Animator glasses;
	Animator animator_xmas;
	Animator energy;
	public Text Buy,Remove,Use,Fly,Shopi,Exit,money,me_points,me_lefta; 
	public Image check,wind;
	public Canvas shopify,msg,payment_method;
	public int bought_g,bought_h,gTotal,removed_h,removed_g,used_h,used_g;
	public int using_glasses=0,using_hat=0;
	public int das_energy;
	// Use this for initialization
 


	void Start () 
	{
		GameObject los_money = GameObject.Find ("With Money");
		if (los_money != null) {
			money = los_money.GetComponent<Text> ();
		} else {
			Debug.LogError("Error");
		}
		das_energy = PlayerPrefs.GetInt("energy");
		used_h = PlayerPrefs.GetInt("used_h");
		used_g = PlayerPrefs.GetInt("used_g");
		removed_h = PlayerPrefs.GetInt("removed_h");
		removed_g = PlayerPrefs.GetInt("removed_g");
		gTotal = PlayerPrefs.GetInt ("Grand_Total");
		bought_g = PlayerPrefs.GetInt ("bought_g");
		bought_h = PlayerPrefs.GetInt ("bought_h");
		Buy = Buy.GetComponent<Text>();
		Fly = Fly.GetComponent<Text>();
		payment_method = payment_method.GetComponent<Canvas> ();
		Shopi= Shopi.GetComponent<Text>();
		me_points = me_points.GetComponent<Text>();
		Exit= Exit.GetComponent<Text>(); 
		shopify = shopify.GetComponent<Canvas>();
		msg = msg.GetComponent<Canvas>();
		check = check.GetComponent<Image>();
		wind = wind.GetComponent<Image>();
		Remove = Remove.GetComponent<Text>();
		Use = Use.GetComponent<Text>();
		me_lefta = me_lefta.GetComponent<Text>();
		check.enabled = false;
		Remove.enabled = false;
		Use.enabled = false;
		msg.enabled = false;
		shopify.enabled = false;
		GameObject da_energy = GameObject.Find("energy_img");
		energy = da_energy.GetComponent<Animator>();
		GameObject da_xmas = GameObject.Find("xmas_hat");
		animator_xmas = da_xmas.GetComponent<Animator>();
		 glasses = transform.GetComponent<Animator>();
		Remove.enabled = false;
		Use.enabled = false;
		Buy.enabled = false;
		check.enabled = false;
		payment_method.enabled = false;
	}
	public void CloseDaShop()
	{
		Fly.enabled = true;
		Shopi.enabled = true;
		Exit.enabled = true;
		shopify.enabled = false;

	}
	public void FreeEnergy()
	{
		das_energy += 10;
		PlayerPrefs.SetInt ("energy", das_energy);

		AdManager.Instance.ShowVideo();



	}
	public void ClosePayment()
	{

		payment_method.enabled = false;
	}
	void Update()
	{
		
		if (glasses.GetCurrentAnimatorStateInfo (0).IsName ("glasses_idle") || glasses.GetCurrentAnimatorStateInfo (0).IsName ("glasses_from_left"))
		{

			if (bought_g == 1 ) {
 
				if (removed_g == 1) {
					using_glasses = 0;
					PlayerPrefs.SetInt("using_glasses",using_glasses);
					check.enabled =false;
					Buy.enabled = false;
					Use.enabled = true;
					Remove.enabled = false;
				} 
				if (used_g == 1) {
					using_glasses = 1;
					PlayerPrefs.SetInt("using_glasses",using_glasses);
					Buy.enabled = false;
					Remove.enabled = true;
					Use.enabled = false;
					check.enabled =true;
				}
			}

			 
			if (bought_g == 0) {
				using_glasses = 0;
				PlayerPrefs.SetInt("using_glasses",using_glasses);
				Remove.enabled = false;
				check.enabled = false;
				Buy.enabled = true;
			 
				Use.enabled = false;
			}
		}

		if (energy.GetCurrentAnimatorStateInfo (0).IsName ("go_left")) {
			check.enabled =false;
			Buy.enabled = true;
			Use.enabled = false;
			Remove.enabled = false;


		}
		if (animator_xmas.GetCurrentAnimatorStateInfo (0).IsName ("xmas_left") || animator_xmas.GetCurrentAnimatorStateInfo (0).IsName ("come_from_left")) {



				if (bought_h == 1 ) {

					if (removed_h == 1) {
						using_hat = 0;
						PlayerPrefs.SetInt("using_hat",using_hat);
						check.enabled =false;
						Buy.enabled = false;
						Use.enabled = true;
						Remove.enabled = false;
					} 
					if (used_h == 1) {
						using_hat = 1;
						PlayerPrefs.SetInt("using_hat",using_hat);
						Buy.enabled = false;
						Remove.enabled = true;
						Use.enabled = false;
						check.enabled =true;
					}
				}


				if (bought_h == 0) {
					using_hat = 0;
					PlayerPrefs.SetInt("using_hat",using_hat);
					Remove.enabled = false;
					check.enabled = false;
					Buy.enabled = true;

					Use.enabled = false;
				}
				
		}
	}

	public void closeW()
	{
		msg.enabled = false;
	}

	public void Use_()
			{
		if (animator_xmas.GetCurrentAnimatorStateInfo (0).IsName ("xmas_left") || animator_xmas.GetCurrentAnimatorStateInfo (0).IsName ("come_from_left")) {
					used_h = 1;
					PlayerPrefs.SetInt("used_h",used_h);
					removed_h = 0;
					PlayerPrefs.SetInt("removed_h",removed_h);
					Remove.enabled = true;
					Use.enabled = false;
				}
				if (glasses.GetCurrentAnimatorStateInfo (0).IsName ("glasses_idle") || glasses.GetCurrentAnimatorStateInfo (0).IsName ("glasses_from_left")) {
					used_g = 1;
					PlayerPrefs.SetInt("used_g",used_g);
					removed_g = 0;
					PlayerPrefs.SetInt("removed_g",removed_g);
					Remove.enabled = true;
					Use.enabled = false;
				}

			}
	public void Buy_()
	{
		if (glasses.GetCurrentAnimatorStateInfo (0).IsName ("glasses_idle") || glasses.GetCurrentAnimatorStateInfo (0).IsName ("glasses_from_left"))
		{
		
			if (gTotal >= 200000) {
	
				using_glasses = 1;
				PlayerPrefs.SetInt("using_glasses",using_glasses);
				Remove.enabled = true;
				used_g = 1;
				PlayerPrefs.SetInt("used_g",used_g);
				check.enabled = true;
				Buy.enabled = false;
				bought_g = 1;
				PlayerPrefs.SetInt("bought_g",bought_g);
				gTotal = gTotal - 200000;
				PlayerPrefs.SetInt("Grand_Total",gTotal);
				payment_method.enabled = false;
			}
			else
			{
				msg.enabled = true;

			}
			
		}

		if (animator_xmas.GetCurrentAnimatorStateInfo (0).IsName ("xmas_left") || animator_xmas.GetCurrentAnimatorStateInfo (0).IsName ("come_from_left")) {

			if (gTotal >= 50000) {

				using_hat = 1;
				used_h = 1;
				PlayerPrefs.SetInt("used_h",used_h);
				PlayerPrefs.SetInt("using_hat",using_hat);
				Remove.enabled = true;
				check.enabled = true;
				Buy.enabled = false;
				bought_h = 1;
				PlayerPrefs.SetInt ("bought_h", bought_h);
				gTotal = gTotal - 50000;
				PlayerPrefs.SetInt ("Grand_Total", gTotal);
				payment_method.enabled = false;
			}
			else
			{
				msg.enabled = true;
				
			}
		}
	}
	public void open_payment_method()
	{
		if (energy.GetCurrentAnimatorStateInfo (0).IsName ("go_left")) {
			money.enabled = false;
			me_lefta.enabled = true;
			me_points.enabled = false;
		} else {
			me_points.enabled = true;
			me_lefta.enabled = false;
			money.enabled = true;
		}
		payment_method.enabled= true;
	}
	public void Buy_With_Money()
	{
		if (energy.GetCurrentAnimatorStateInfo (0).IsName ("go_left")) {
			IPAManager.Instance.Buy_Energy();


		}
		if (glasses.GetCurrentAnimatorStateInfo (0).IsName ("glasses_idle") || glasses.GetCurrentAnimatorStateInfo (0).IsName ("glasses_from_left"))
		{


				IPAManager.Instance.Buy_Thug_Life_Glasses();
				
		}


		if (animator_xmas.GetCurrentAnimatorStateInfo (0).IsName ("xmas_left") || animator_xmas.GetCurrentAnimatorStateInfo (0).IsName ("come_from_left")) {


			IPAManager.Instance.Buy_Xmas_Hat();
		
			 
		}
	}

	public void Successfull_transaction()
	{
		if (energy.GetCurrentAnimatorStateInfo (0).IsName ("go_left")) {

			das_energy += 200;
			PlayerPrefs.SetInt ("energy",das_energy);
		}

		if (glasses.GetCurrentAnimatorStateInfo (0).IsName ("glasses_idle") || glasses.GetCurrentAnimatorStateInfo (0).IsName ("glasses_from_left"))
		{
		used_g = 1;
		PlayerPrefs.SetInt("used_g",used_g);
		using_glasses = 1;
		PlayerPrefs.SetInt("using_glasses",using_glasses);
		Remove.enabled = true;
		check.enabled = true;
		Buy.enabled = false;
		bought_g = 1;
		PlayerPrefs.SetInt("bought_g",bought_g);

		payment_method.enabled = false;

		}

		if (animator_xmas.GetCurrentAnimatorStateInfo (0).IsName ("xmas_left") || animator_xmas.GetCurrentAnimatorStateInfo (0).IsName ("come_from_left")) {
			using_hat = 1;
			PlayerPrefs.SetInt ("using_hat", using_hat);
			Remove.enabled = true;
			check.enabled = true;
			Buy.enabled = false;
			used_g = 1;
			PlayerPrefs.SetInt ("used_h", used_h);
			bought_h = 1;
			PlayerPrefs.SetInt ("bought_h", bought_h);
			payment_method.enabled = false;

		}
	}
	public void Start_Shop()
	{
		
		Fly.enabled = false;
		Shopi.enabled = false;
		Exit.enabled = false;
		shopify.enabled = true;
	}
	 public void remove_da()
	{

		if (animator_xmas.GetCurrentAnimatorStateInfo (0).IsName ("xmas_left") || animator_xmas.GetCurrentAnimatorStateInfo (0).IsName ("come_from_left")) {
			removed_h = 1;
			PlayerPrefs.SetInt("removed_h",removed_h);
			used_h = 0;
			PlayerPrefs.SetInt("used_h",used_h);
			Use.enabled = true;
			Buy.enabled=false;
			Remove.enabled= false;
			check.enabled= false;
		}
		if (glasses.GetCurrentAnimatorStateInfo (0).IsName ("glasses_idle") || glasses.GetCurrentAnimatorStateInfo (0).IsName ("glasses_from_left")) {
			removed_g = 1;
			used_g = 0;
			PlayerPrefs.SetInt("used_h",used_g);
			PlayerPrefs.SetInt("removed_g",removed_g);
			Use.enabled = true;
			Buy.enabled=false;
			Remove.enabled= false;
			check.enabled= false;
		}

	}
	public void Right()
	{
		if (animator_xmas.GetCurrentAnimatorStateInfo (0).IsName ("come_from_left")) {

			energy.Play ("go_left");
			animator_xmas.Play ("hat_left");
		}
		if (animator_xmas.GetCurrentAnimatorStateInfo (0).IsName ("xmas_left")) {

			energy.Play ("go_left");
			animator_xmas.Play ("hat_left");
		}
		if (glasses.GetCurrentAnimatorStateInfo (0).IsName ("glasses_idle")) {
			glasses.Play ("glasses_left");
			animator_xmas.Play ("xmas_left");
			
		}
		if (glasses.GetCurrentAnimatorStateInfo (0).IsName ("glasses_from_left")) {
			glasses.Play ("glasses_left");
			animator_xmas.Play ("xmas_left");
		}
	}
	public void Left()
	{
		if (animator_xmas.GetCurrentAnimatorStateInfo (0).IsName ("come_from_left")) {
			animator_xmas.Play ("xmas_right");
			glasses.Play ("glasses_from_left");


		}
		if (animator_xmas.GetCurrentAnimatorStateInfo (0).IsName ("xmas_left")) {
			animator_xmas.Play ("xmas_right");
			glasses.Play ("glasses_from_left");
			
		}
		if (energy.GetCurrentAnimatorStateInfo (0).IsName ("go_left")) {
			energy.Play ("go_right");
			animator_xmas.Play("come_from_left");
		}
	}
}
