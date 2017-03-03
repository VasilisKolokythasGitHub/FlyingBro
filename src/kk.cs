using UnityEngine;
using System.Collections;

public class VisibilityChangeScript : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		foreach (Transform child in this.transform)
		{
			if (Input.GetKey(KeyCode.Q))
			{
				child.gameObject.SetActive(false);
			}
			else if (Input.GetKey(KeyCode.E))
			{
				child.gameObject.SetActive(true);
			}
		}
	}
}