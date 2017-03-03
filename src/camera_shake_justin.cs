using UnityEngine;
using System.Collections;

public class camera_shake_justin : MonoBehaviour {
	
	
	public bool Shaking; 
	private float ShakeDecay;
	private float ShakeIntensity;    
	private Vector3 OriginalPos;
	private Quaternion OriginalRot;
	public bool justin_3,justin_1,nok = false;

	void Start()
	{
		Shaking = false;   

	}
	
	
	// Update is called once per frame
	void Update () 
	{
		GameObject nokia_3 = GameObject.Find ("justinos_3");
		justin_3 n3 = nokia_3.GetComponent<justin_3> ();
		justin_3 = n3.xtypise;
		
		
		GameObject nokia_1 = GameObject.Find ("justinos_2");
		justin_1 n1 = nokia_1.GetComponent<justin_1> ();
		justin_1 = n1.xtypise;
		
		GameObject nokia = GameObject.Find ("justinos");
		justin n = nokia.GetComponent<justin> ();
		nok = n.xtypise;

	 
		
		if (nok || justin_1 || justin_3) {
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
		
		ShakeIntensity = 0.01f;
		ShakeDecay = 0.5f;
		Shaking = true;
	}    
	
	
}

