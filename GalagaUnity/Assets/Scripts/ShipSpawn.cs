using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawn : MonoBehaviour
{
    public GameObject PurpleShip;
    public int purpleChance;
    public int numPurpleShips;

    public GameObject GreenShip;
    public int greenChance;
    public int numGreenShips;

    void Update()
    {
        int num = (int)Random.Range(0, 10000);
        if(num <= purpleChance)
        {
            SpawnShips(PurpleShip, numPurpleShips);
        }

        num = (int)Random.Range(0, 10000);
        if (num <= greenChance)
        {
            SpawnShips(GreenShip, numGreenShips);
        }
    }

    void SpawnShips(GameObject Ship, int numShips)
    {
        for (float i = 0; i < numShips; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-4, 4), 7.5f + i, 0);
            GameObject.Instantiate(Ship).transform.SetPositionAndRotation(pos, Quaternion.Euler(0, 0, 0));
        }
    }
}