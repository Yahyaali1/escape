using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayIntro : MonoBehaviour {

    // Use this for initialization
    public MovieTexture mv;
    public int limit;
    public int sec;
    private int fixtime;
    void Awake()
    {
        fixtime = (int)Time.fixedTime;
    }
    void Start()
    {
        mv = (MovieTexture)GetComponent<Renderer>().material.mainTexture;
        mv.Play();

    }

    // Update is called once per frame
    void Update()
    {

        sec = (int)Time.fixedTime;
        if (sec > limit +fixtime || Input.anyKey)
        {
            Application.LoadLevel("Stage1");
        }
    }
}
