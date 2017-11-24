using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjects : MonoBehaviour
{

    // Use this for initialization
    public Sprite[] images;
    public Sprite[] images2;
    public Sprite[] images3;
    public GameObject prefab;
    public int Timer;
    public int distance=2;
    int countbad=0;
    int countgood=0;
    int limit=15;
    public int fixtime;
    void Awake()
    {
        fixtime = (int)Time.fixedTime;
    }
    void Start()
    {
        Timer = (int) Time.time ;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position = GetComponent<Transform>().position + new Vector3(6, 0, 0);
        //if ((Timer>distance))
        if ((fixtime+distance < Time.fixedTime))
        {
            var rand = Random.RandomRange(0, images.Length);
            var t = "";
            if (rand == 0 || rand == 1 || rand == 2 || rand == 3)
            {
                t = "bad";
                countbad++;
                if (countbad > limit)
                {

                }else
                {
                    GameObject.Instantiate(prefab);
                    prefab.tag = t;
                    prefab.transform.position = GetComponent<Transform>().position;

                    if (Data.type == 0)
                    {
                        prefab.GetComponent<SpriteRenderer>().sprite = images[rand];
                    }
                    else if (Data.type == 1)
                    {
                        prefab.GetComponent<SpriteRenderer>().sprite = images2[rand];
                    }
                    else
                    {
                        prefab.GetComponent<SpriteRenderer>().sprite = images3[rand];
                    }
                    
                }

            }
            else
            {

                t = "good";
                countgood++;
                if (countgood > limit)
                {

                }
                else
                {
                    GameObject.Instantiate(prefab);
                    prefab.tag = t;
                    prefab.transform.position = GetComponent<Transform>().position;

                    if (Data.type == 0)
                    {
                        prefab.GetComponent<SpriteRenderer>().sprite = images[rand];
                    }
                    else if (Data.type == 1)
                    {
                        prefab.GetComponent<SpriteRenderer>().sprite = images2[rand];
                    }
                    else
                    {
                        prefab.GetComponent<SpriteRenderer>().sprite = images3[rand];
                    }
                    prefab.GetComponent<SpriteRenderer>().sortingOrder = 5;
                }
            }


            //distance += 100;
            fixtime = (int) Time.fixedTime;
            Timer = 0;
        }
        Timer += (int) Time.time;
    }
}
