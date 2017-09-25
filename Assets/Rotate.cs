using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    // Use this for initialization
    bool once = false;
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
