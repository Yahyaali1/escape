using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}
    public static bool ispressed =false;
    public void OnPointerDown(PointerEventData eventData)
    {
        ispressed = true;
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ispressed = false;
    }
}
