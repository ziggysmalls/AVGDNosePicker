using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour 
{

	public AudioEvent backgroundAudio;
	public Vector3 dontknowhyitneedsitbutokay;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		backgroundAudio.Play(dontknowhyitneedsitbutokay);
	}
}
