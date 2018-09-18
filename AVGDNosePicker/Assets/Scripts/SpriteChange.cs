using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour {


    public Sprite BoogerArm;

    void OnCollisionEnter(Collision2D col)
    {
        if (col.gameObject.name == "Head")
        {
            //Destroy(gameobject);
            //Destroy(col.gameObject);
            // this.GetComponent<SpriteRenderer>().sprite = Arm_Sprite_withBooger;  // problem is here
            this.GetComponent<SpriteRenderer>().sprite = BoogerArm;
            // col.gameObject.Sprite = BoogerArm;

        }


    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
