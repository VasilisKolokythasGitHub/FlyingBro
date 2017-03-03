using UnityEngine;
using System.Collections;

public class camera_shake : MonoBehaviour {
	
	
	public bool Shaking; 
	private float ShakeDecay;
	private float ShakeIntensity;    
	private Vector3 OriginalPos;
	private Quaternion OriginalRot;
	public bool nok_1,nok_3 ,nok = false;
	void Start()
	{
		Shaking = false;   
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		GameObject nokia_3 = GameObject.Find ("nokia_3");
		nokia_3 n3 = nokia_3.GetComponent<nokia_3> ();
		nok_3 = n3.nokia;
		
		
		GameObject nokiaa_1 = GameObject.Find ("nokia_1");
		nokia_2 n1 = nokiaa_1.GetComponent<nokia_2> ();
		nok_1 = n1.nokia;
		
		GameObject nokia = GameObject.Find ("nokia");
		Nokia n = nokia.GetComponent<Nokia> ();
		nok = n.nokia;

		if (nok || nok_1 || nok_3) {
			DoShake();
		}
	
		if(ShakeIntensity > 0)
		{
			transform.position = OriginalPos + Random.insideUnitSphere * ShakeIntensity;
			transform.rotation = new Quaternion(OriginalRot.x + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f,
			                                    OriginalRot.y + Random.Range(-ShakeIntensity, ShakeIntensity)*.2f,
			                                    OriginalRot.z + Random.Range(-ShakeIntensity, ShakeIntensity)*.0f,
			                                    OriginalRot.w + Random.Range(-ShakeIntensity, ShakeIntensity)*.0f);
			
			ShakeIntensity -= ShakeDecay;
		}
		else if (Shaking)
		{
			Shaking = false;  
		}
	}
	
	
	      
	
	
	
	
	
	
	public void DoShake()
	{
		OriginalPos = transform.position;
		OriginalRot = transform.rotation;
		
		ShakeIntensity = 0.05f;
		ShakeDecay = 0;
		Shaking = true;
	}    
	
	
}
