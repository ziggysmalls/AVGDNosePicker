﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public GameObject Arm;
	public Vector3 pos;
	public Vector3 startPos;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			transform.Translate(pos);
		}
		if(Input.GetButtonDown("Fire2"))
		{
			transform.Translate(startPos);
		}

	}
}