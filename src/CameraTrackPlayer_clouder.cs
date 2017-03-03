using UnityEngine;
using System.Collections;
public class CameraTrackPlayer_clouder : MonoBehaviour {
	Transform player;
	float offsetX;
	float offsetY;
	 
	public bool kamenos,kamenos2,kamenos3 = false;
	// Use this for initialization
	void Start () {


		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		if (player_go == null) {
			Debug.LogError ("Could not find tag Player please leave a message");
			return;
		} 
		
		player = player_go.transform;
		offsetX = transform.position.x - player.position.x;
		offsetY = transform.position.y - player.position.y;
		
		
	}
	// Update is called once per frame
	void Update () {


		GameObject kapsimo = GameObject.Find ("clouds");
		clouder kahla = kapsimo.GetComponent<clouder> ();
		kamenos = kahla.kamenos;
		
		GameObject kapsimo2 = GameObject.Find ("clouds_2");
		clouder_2 kahla2 = kapsimo2.GetComponent<clouder_2> ();
		kamenos2 = kahla2.kamenos2;
		
		GameObject kapsimo3 = GameObject.Find ("clouds_3");
		clouder_3 kahla3 = kapsimo3.GetComponent<clouder_3> ();
		kamenos3 = kahla3.kamenos3;
		if(player !=null && !kamenos && !kamenos2 && !kamenos3){
			Vector3 pos = transform.position;
			pos.x = player.position.x + offsetX;
			pos.y = player.position.y + offsetY;
			transform.position = pos;
		}
	}
	
}
