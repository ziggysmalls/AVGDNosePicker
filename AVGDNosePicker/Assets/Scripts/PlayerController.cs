using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public GameObject Arm;
	public Vector3 pos;
	public Vector3 startPos;
    public Sprite BoogArm;
    public Sprite BoogArm2;
    public Sprite BoogArm3;
    public Sprite BoogArm4;
    int clickCount = 0;
    int nosePickCount = 0;
    public AudioEvent boogerAudioEvent;
    Vector3 playerSpawnPoint;

	// Use this for initialization
	void Start () 
	{
		
        playerSpawnPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
        if(nosePickCount == 1)
        {
            this.GetComponent<SpriteRenderer>().sprite = BoogArm;
           
        }

        if(nosePickCount == 2)
        {
            this.GetComponent<SpriteRenderer>().sprite = BoogArm2;
            boogerAudioEvent.Play(playerSpawnPoint);
           
        
        }

        if(nosePickCount == 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = BoogArm3;
           boogerAudioEvent.Play(playerSpawnPoint);
        

        }
        if(nosePickCount >= 4)
        {
            this.GetComponent<SpriteRenderer>().sprite = BoogArm4;
         boogerAudioEvent.Play(playerSpawnPoint);
        
        }

		if (Input.GetButtonDown ("Fire1") && clickCount == 0  ) 
		{
			transform.Translate(pos);
            nosePickCount++;
            clickCount++;
		}
		if(Input.GetButtonDown("Fire2") && clickCount == 1)
		{
			transform.Translate(startPos);
            boogerAudioEvent.Play(playerSpawnPoint);
			clickCount--;
		}

	}
}
