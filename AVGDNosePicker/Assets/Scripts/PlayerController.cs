using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerController : MonoBehaviour 
{
	public GameObject arm;
	public Vector3 pickPos;
    public Vector3 armStartEuler;
	public Vector3 startPos;
    public List<Sprite> boogers;
    public List<AudioEvent> boogerAudioEvent;
    public AudioEvent missEvent;
    public SpriteRenderer spriteRenderer;
    public AudioEvent deathAudioEvent;
    public AudioEvent backgroundMusic;
    public AudioEvent DeathBackgroundMusic;
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
        backgroundMusic.Play(Vector3.zero);
	}
	
	// Update is called once per frame
	void Update () 
	{
       

        if (GameMessages.GetMessage("py",true) && currentAnimation == null)
        {
            
            
            arm.transform.position = pickPos;
        
            spriteRenderer.sprite = boogers[Random.Range(1,boogers.Count)];
           boogerAudioEvent[boogers.Count - 1].Play(Vector3.zero);

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
            missEvent.Play(Vector3.zero);
            
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

           
            }


            //Death Event
            if (GameMessages.GetMessage(brainAnimation.messageOnEnd,true))
            {
                
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                gameObject.transform.GetChild(1).transform.eulerAngles = Vector3.zero;
                gameObject.transform.GetChild(1).transform.position =  gameObject.transform.GetChild(0).transform.position;
                currentAnimation = deathAnimation;
                deathAudioEvent.Play(Vector3.zero);
                
                backgroundMusic.Stop();
                backgroundMusic = DeathBackgroundMusic;
                backgroundMusic.Play(Vector3.zero);
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
