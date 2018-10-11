using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    private float timerSpeed;
    private bool isPointerDown;
    private float requiredHoldTimeCurrent;
    public float requiredHoldTimeMin;
    public float requiredHoldTimeMax;
    private UnityEvent onLongClick;
    private Image fillImage;
    private Image indicator;



    public void Start()
    {
        requiredHoldTimeCurrent = 0;
        fillImage = gameObject.transform.GetChild(1).GetComponent<Image>();
        indicator = gameObject.transform.GetChild(0).GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameMessages.GetMessage("pb",false))
            return;

        timerSpeed = Random.Range(0.75f,2.75f);
        requiredHoldTimeMin = Random.Range(0.6f,0.9f);
        indicator.fillAmount = requiredHoldTimeMin;
        isPointerDown = true;
        GameMessages.AddMessage("pn");
     
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;

    
        
        if ( requiredHoldTimeCurrent >= requiredHoldTimeMin && requiredHoldTimeCurrent <= requiredHoldTimeMax)
        {
           GameMessages.AddMessage("py");
        }

        requiredHoldTimeCurrent = 0;
        fillImage.fillAmount =  requiredHoldTimeCurrent / requiredHoldTimeCurrent;
        

    }



   
	// Update is called once per frame
	public void Update () 
    {

        fillImage.gameObject.SetActive(!GameMessages.GetMessage("pb",false));
        indicator.gameObject.SetActive(!GameMessages.GetMessage("pb",false));
        GetComponent<Image>().enabled = !GameMessages.GetMessage("pb",false);

        if (isPointerDown)
            requiredHoldTimeCurrent+= Time.deltaTime * timerSpeed;


        fillImage.fillAmount =  requiredHoldTimeCurrent / 1;    
        
          
    }

}
