using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is for instantiation of meteorites. Attach to the camera object
public class RockSpawn : MonoBehaviour
{//Lab 2 week 1
    public GameObject Rock;
    public int numRocks;

    // Use this for initialization
    void Start()
    {
        MakeRocks();
    }

    void MakeRocks()
    {
        for (float i = 0; i < numRocks; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-4, 4), 7.5f + i, 0);
            GameObject.Instantiate(Rock).transform.SetPositionAndRotation(pos, Quaternion.Euler(0, 0, 0));
        }
    }
}