using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {

    // Use this for initialization
    public static int type;
    public static int level;
    private static int[] limit = { 15, 15, 15, 30, 30}; //number of objects to be dropped from the sky 

	public static void increment_level()
    {
        level++;
    }
    public static int getlimit()
    {
        return limit[level];
    }
}
