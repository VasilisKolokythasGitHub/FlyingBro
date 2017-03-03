using UnityEngine;
using System.Collections;

public class da_follow_clouder : MonoBehaviour {
	Transform player;
	float offsetX;
	public bool kamenos,kamenos2,kamenos3 = false;
	public bool girl = false;
	// Use this for initialization
	void Start () {
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		if (player_go == null) {
			Debug.LogError ("Could not find tag Player please leave a message");
			return;
		} 
		
		player = player_go.transform;
		offsetX = transform.position.x - player.position.x;

	}
	// Update is called once per frame
	void Update () {

		GameObject girlll = GameObject.Find ("Bro");
		movement_clouder gf = girlll.GetComponent<movement_clouder> ();
		girl = gf.girl;


		GameObject kapsimo = GameObject.Find ("clouds");
		clouder kahla = kapsimo.GetComponent<clouder> ();
		kamenos = kahla.kamenos;
		
		GameObject kapsimo2 = GameObject.Find ("clouds_2");
		clouder_2 kahla2 = kapsimo2.GetComponent<clouder_2> ();
		kamenos2 = kahla2.kamenos2;
		
		GameObject kapsimo3 = GameObject.Find ("clouds_3");
		clouder_3 kahla3 = kapsimo3.GetComponent<clouder_3> ();
		kamenos3 = kahla3.kamenos3;


		if(player !=null && !kamenos && !kamenos2 && !kamenos3 && !girl){
			Vector3 pos = transform.position;
			pos.x = player.position.x + offsetX;
	
			transform.position = pos;
		}
	}
	
} 