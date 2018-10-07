using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
	public GameObject arm;
	public Vector3 pickPos;
    public Vector3 armStartEuler;
	public Vector3 startPos;
    public List<Sprite> boogers;
    public AudioEvent boogerAudioEvent;
    public SpriteRenderer spriteRenderer;
    public int pickMaxValue = 5;
    public int pickCurrentValue;

    public AAnimation brainAnimation;
    public AAnimation deathAnimation;

    private AAnimation currentAnimation;
 
    [System.Serializable]
    public class AAnimation
    {
        public List<Sprite> sprites;
        public int currentFrameIndex;
        public float interval;
        public float timer;
        public string messageOnEnd;
        public bool isPlaying;
    }

	// Use this for initialization
	void Start () 
	{
        spriteRenderer = arm.GetComponent<SpriteRenderer>();
        pickPos = new Vector3(6.38f,-3.65f,0);
		startPos = arm.transform.position;
        armStartEuler = arm.transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () 
	{
        // if(nosePickCount == 1)
        // {
        //     this.GetComponent<SpriteRenderer>().sprite = BoogArm;
           
        // }

        // if(nosePickCount == 2)
        // {
        //     this.GetComponent<SpriteRenderer>().sprite = BoogArm2;
            
           
        
        // }

        // if(nosePickCount == 3)
        // {
        //     this.GetComponent<SpriteRenderer>().sprite = BoogArm3;
          
        

        // }
        // if(nosePickCount >= 4)
        // {
        //     this.GetComponent<SpriteRenderer>().sprite = BoogArm4;
         
        // }

		// if (Input.GetButtonDown ("Fire1") && clickCount == 0  ) 
		// {
		// 	transform.Translate(pos);
        //     nosePickCount++;
        //     clickCount++;
		// }
		// if(Input.GetButtonDown("Fire2") && clickCount == 1)
		// {
		// 	transform.Translate(startPos);
        //     boogerAudioEvent.Play(playerSpawnPoint);
		// 	clickCount--;
		// }

        if (GameMessages.GetMessage("py",true) && currentAnimation == null)
        {
            

            arm.transform.position = pickPos;
            boogerAudioEvent.Play(Vector3.zero);
            spriteRenderer.sprite = boogers[Random.Range(1,boogers.Count)];

            if (pickCurrentValue >= pickMaxValue)
            {
                currentAnimation = brainAnimation;
                currentAnimation.isPlaying = true;
                GameMessages.AddMessage("pb");
            }


            pickCurrentValue++;

        }

        if (GameMessages.GetMessage("pn",true) && currentAnimation == null)
        {
            arm.transform.position = startPos;
        }

        //Animate
        if (currentAnimation != null)
        {
            currentAnimation.timer += Time.deltaTime;
            if (currentAnimation.timer > currentAnimation.interval && currentAnimation.isPlaying)
            {
                currentAnimation.timer = 0;
                currentAnimation.currentFrameIndex++;

                if (currentAnimation.currentFrameIndex < currentAnimation.sprites.Count - 1)
                    spriteRenderer.sprite = currentAnimation.sprites[currentAnimation.currentFrameIndex];
                else
                {
                    GameMessages.AddMessage(currentAnimation.messageOnEnd);
                    currentAnimation.isPlaying = false;
                    currentAnimation.currentFrameIndex = 0;
                }

           //     brainPickAnimationFrameChangeTimer = 0;
           //     currentBrainFrameIndex++;
           //     spriteRenderer.sprite = brains[currentBrainFrameIndex];
            }


            //Death Event
            if (GameMessages.GetMessage(brainAnimation.messageOnEnd,true))
            {

                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                gameObject.transform.GetChild(1).transform.eulerAngles = Vector3.zero;
                gameObject.transform.GetChild(1).transform.position =  gameObject.transform.GetChild(0).transform.position;
                currentAnimation = deathAnimation;
                currentAnimation.isPlaying = true;
            }

            if (GameMessages.GetMessage("resetPlayerController",true))
            {
                spriteRenderer.sprite = boogers[0];
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
                gameObject.transform.GetChild(1).transform.eulerAngles = armStartEuler;
                gameObject.transform.GetChild(1).transform.position = startPos;
                pickCurrentValue = 0;
                GameMessages.GetMessage("dd",true);
                GameMessages.GetMessage("pb",true);
                currentAnimation = null;

            }
        }

	}
}
