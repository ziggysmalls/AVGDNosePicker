using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAgainButton : MonoBehaviour 
{
	public void Start()
	{
		GetComponent<Button>().onClick.AddListener(PlayAgain);
	}

	public void PlayAgain()
	{
		GameMessages.AddMessage("resetPlayerController");
	}

	public void Update()
	{
		GetComponent<Button>().enabled = GameMessages.GetMessage("dd",false);
		GetComponent<Image>().enabled = GameMessages.GetMessage("dd",false);
		gameObject.transform.GetChild(0).gameObject.SetActive(GameMessages.GetMessage("dd",false));
	}
}
