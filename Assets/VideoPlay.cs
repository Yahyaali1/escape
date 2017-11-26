using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoPlay : MonoBehaviour {


        // Use this for 
        public MovieTexture mv;
        public int limit;
        public int sec;
        void Start()
        {
            mv = (MovieTexture)GetComponent<Renderer>().material.mainTexture;
            mv.Play();

        }

        // Update is called once per frame
        void Update()
        {

        //move to next screen on touch count 
            sec = (int)Time.fixedTime;
            if (sec > limit || Input.anyKey || Input.touchCount>0)
            {
                Application.LoadLevel("Wheel");
            }
        }
    

}
