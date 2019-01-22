using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawn : MonoBehaviour
{
    public GameObject Ship;
    public int chance;
    public int numShips;

    void Update()
    {
        int num = (int)Random.Range(0, 1000);

        if(num <= chance)
        {
            SpawnShips();
        }
    }

    void SpawnShips()
    {
        for (float i = 0; i < numShips; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-4, 4), 7.5f + i, 0);
            GameObject.Instantiate(Ship).transform.SetPositionAndRotation(pos, Quaternion.Euler(0, 0, 0));
        }
    }
}