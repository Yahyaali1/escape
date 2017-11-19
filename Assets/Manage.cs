using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manage : MonoBehaviour {
    public GameObject[] floors;
    public GameObject act_back;
    public Material[] backgrounds;
    private Vector3 floorT;
    void Awake ()
    {
        floorT = new Vector3(5087,-182,0);
        GameObject.Instantiate(floors[Data.type]);
        floors[Data.type].transform.position = floorT;
        act_back.GetComponent<Renderer>().material = backgrounds[Data.type];


    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
