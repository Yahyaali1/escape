using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Consumption : MonoBehaviour {

    // Use this for initialization
    public int badpoints = 0;
    public int goodpoints = 0;
    public GameObject Botin;
    public GameObject Health;
    public GameObject Particles;
    public bool gameover = false;
    public bool levelend = false;
    private Transform ps;
    public Text []text;
    public Sprite fail;
    public Sprite Success;
    public Image screen;
    private Color m;
	void Start () {
       // for (int i = 0; i < text.Length; i++)
        //{
          //  text[i].CrossFadeAlpha(0, 0, true);

        //}
        screen.CrossFadeAlpha(0, 0, true);
        levelend = false;
        gameover = false;
        
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "good")
        {
            
            goodpoints++;
            GameObject.Instantiate(Particles);
            Particles.transform.position = coll.contacts[0].point;
            //Particles.transform.position.Set(ps.position.x, ps.position.y, ps.position.z); 
            GameObject.Destroy(coll.gameObject);
            float x = Health.transform.localScale.x;
            
            if (x < 7)
            {
                x = x + 0.5f;
                Health.transform.localScale = new Vector3(x, Health.transform.localScale.y, Health.transform.localScale.z);
            }
        }
        else if (coll.gameObject.tag == "bad")
        {
            badpoints++;
            GameObject.Destroy(coll.gameObject);
            float x = Health.transform.localScale.x;

            if (x > 0)
            {
                x = x - 0.5f;
                Health.transform.localScale = new Vector3(x, Health.transform.localScale.y, Health.transform.localScale.z);
            }
            if (x < 0)
            {
                print("gameover");
                Time.timeScale = 0;
                gameover = true;
            }
        }
        if (coll.gameObject.tag == "end")
        {
            Time.timeScale = 0;
            gameover = true;
            levelend = true;
            screen.GetComponent<Image>().sprite = Success;
            screen.CrossFadeAlpha(1, 2, true);

        }


    }
    void reset()
    {
        Time.timeScale = 1;
        gameover = false;
        levelend = false;
    }

   public void reload()
    {
        Application.LoadLevel(Application.loadedLevel);
        reset();
    }
    // Update is called once per frame
    void Update () {
        
        if (gameover == false)
        {
            float x = Health.transform.localScale.x;
            x = x - 0.002f;
            Health.transform.localScale = new Vector3(x, Health.transform.localScale.y, Health.transform.localScale.z);
            if (x < 0)
            {
                print("gameover");
                Time.timeScale = 0;
                gameover = true;
                //for (int i = 0; i < text.Length; i++)
                //{
                //    text[i].CrossFadeAlpha(1, 3, true);
                //}

                screen.GetComponent<Image>().sprite = fail;
                screen.CrossFadeAlpha(1, 2, true);
            }

        }
        
        //either the game has ended or the player has died
        if((Input.anyKey || Input.touchCount >0) && gameover == true && levelend!=true)
        {
            Application.LoadLevel(Application.loadedLevel);
            reset();
        }
        //you are stuck and simply load the level from the start 
        if (Input.GetKey(KeyCode.R))
        {
            //Application.LoadLevel(Application.loadedLevel);
            Application.LoadLevel("IntroToGame");
            reset();
        }
        if (Input.GetKey(KeyCode.S))
        {
            Application.LoadLevel("FlashScreen");

        }
        if (Input.GetKey(KeyCode.W))
        {
            Application.LoadLevel("Wheel");

        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
