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
    public Sprite BoogArm5;
    public Sprite BoogArm6;
    public Sprite BoogArm7;
    public Sprite BoogArm8;
    public AudioEvent boogerAudioEvent;
    int clickCount = 0;
    int nosePickCount = 0;
    Vector3 playerSpawnPoint;
    //   public HoldButton but;
//    HoldButton values = FindObjectOfType<HoldButton>();

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

           
        
        }

        if(nosePickCount == 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = BoogArm3;

        

        }
        if(nosePickCount == 4)
        {
            this.GetComponent<SpriteRenderer>().sprite = BoogArm4;

        
        }
        if (nosePickCount == 5)
        {
            this.GetComponent<SpriteRenderer>().sprite = BoogArm5;


        }
        if (nosePickCount == 6)
        {
            this.GetComponent<SpriteRenderer>().sprite = BoogArm6;


        }
        if (nosePickCount == 7)
        {
            this.GetComponent<SpriteRenderer>().sprite = BoogArm7;


        }
        if (nosePickCount >= 8)
        {
            this.GetComponent<SpriteRenderer>().sprite = BoogArm8;


        }

//        HoldButton butScript = GetComponent<HoldButton>(); // may cause issues


        //if(but.GetComponent<HoldButton>().requiredHoldTime)                   butScript.GetComponent<HoldButton>().pointerDownTimer >= butScript.GetComponent<HoldButton>().requiredHoldTime





        if (Input.GetButtonDown("Fire2") && clickCount == 1)
		{
			transform.Translate(startPos);
            boogerAudioEvent.Play(playerSpawnPoint);
			clickCount--;
		}


		if (Input.GetButtonDown ("Fire1") && clickCount == 0   ) //&& (GameObject.Find("Button").GetComponent<HoldButton>().pointerDownTimer >= GameObject.Find("Button").GetComponent<HoldButton>().requiredHoldTime)) 
		{

            transform.Translate(pos);
            nosePickCount++;
            clickCount++;
        }



	}
}
