using UnityEngine;
using System.Collections;

public class camera_shake_clouder : MonoBehaviour {
	
	
	public bool Shaking; 
	private float ShakeDecay;
	private float ShakeIntensity;    
	private Vector3 OriginalPos;
	private Quaternion OriginalRot;
	public bool kamenos3,kamenos2,kamenos = false;
	void Start()
	{
		Shaking = false;   
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		GameObject kapsimo = GameObject.Find ("clouds");
		clouder kahla = kapsimo.GetComponent<clouder> ();
		kamenos = kahla.kamenos;
		
		GameObject kapsimo2 = GameObject.Find ("clouds_2");
		clouder_2 kahla2 = kapsimo2.GetComponent<clouder_2> ();
		kamenos2 = kahla2.kamenos2;
		
		GameObject kapsimo3 = GameObject.Find ("clouds_3");
		clouder_3 kahla3 = kapsimo3.GetComponent<clouder_3> ();
		kamenos3 = kahla3.kamenos3;
		
		if (kamenos || kamenos2 || kamenos3) {
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
		ShakeDecay = 0.002f;
		Shaking = true;
	}    
	
	
}
