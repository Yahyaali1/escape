using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    // Use this for initialization
    bool once = false;
    private float stage;
    public int count;
    public bool stopped = false;
    int y = 0;
    //AsyncOperation sr;
    void Spin()
    {
        int x = 1000;
        if (y < count)
        {
            y++;
            GetComponent<Transform>().RotateAround(Vector3.forward, x);
        }else
        {
            stopped = true;
            stage = GetComponent<Transform>().localEulerAngles.z;
            //print(stage);
            if(stage>240 && stage < 360)
            {
                stage = 0;
            }else if (stage >= 0 && stage < 120)
            {
                stage = 1;
            }else
            {
                stage = 2;
            }
            //if case 1 then Diabeties, 2 for Blood Pressure , 3 for thelesemia 
            Data.type =(int) stage;
            Data.level = 1;
            print(stage);
        }
    }
    void Start () {
        count = Random.RandomRange(50, 150);
        
	}
	
	// Update is called once per frame
	void Update () {
       
        if (Input.anyKey)
        {
            once = true;
        }

       if(once==true && stopped==false)
        {
            Spin();
        }

        if(stopped==true && once == true && Input.anyKey)
        {
            Application.LoadLevel("IntroToGame");
            
        }
        
	}
}
