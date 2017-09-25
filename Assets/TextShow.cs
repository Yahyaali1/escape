using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextShow : MonoBehaviour {

    // Use this for initialization

    private Text text;
    public Image image;
    bool hasstarted = false;
	void Start () {
        text = GetComponent<Text>();
        
        hasstarted = false;
	}
	
	// Update is called once per frame
	void Update () {
        

        if (Input.anyKey)
        {
           
            text.CrossFadeAlpha(0, 2, true);
            image.CrossFadeAlpha(0, 2, true);

        }

        
            
        
       

	}
}
