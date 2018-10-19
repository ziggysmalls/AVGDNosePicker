using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour 
{
private AAnimation head;
 private AAnimation currentAnimation;
 private SpriteRenderer spriteRenderer;
 public GameObject player;
	// Use this for initialization
	void Start () 
	{
		spriteRenderer = player.GetComponent<SpriteRenderer>();
		head = currentAnimation;
	}
	
	// Update is called once per frame
	void Update () 
	{
		LinkedList(currentAnimation);
		
		if (currentAnimation != null)
        {
            currentAnimation.timer += Time.deltaTime;
            if (currentAnimation.timer > currentAnimation.interval )
            {
                currentAnimation.timer = 0;
                currentAnimation.currentFrameIndex++;

                if (currentAnimation.currentFrameIndex < currentAnimation.sprites.Count - 1)
                    spriteRenderer.sprite = currentAnimation.sprites[currentAnimation.currentFrameIndex];
                else
                {
                    
                    currentAnimation.currentFrameIndex = 0;
                }

           
            }
		}
	}
	void LinkedList(AAnimation animation)
	{
		
	}




}







