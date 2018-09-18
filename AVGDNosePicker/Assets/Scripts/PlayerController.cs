using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public GameObject Arm;
	public Vector3 pos;
	public Vector3 startPos;
	int clickCount = 0;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Fire1") && clickCount == 0  ) 
		{
			transform.Translate(pos);
			clickCount++;
		}
		if(Input.GetButtonDown("Fire2") && clickCount == 1)
		{
			transform.Translate(startPos);
			clickCount--;
		}

	}
}
