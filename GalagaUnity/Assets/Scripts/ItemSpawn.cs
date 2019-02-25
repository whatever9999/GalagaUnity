using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemSpawn : MonoBehaviour
{
    public Item[] items;
    public float secondsBetweenSpawns;

    private int spawnNum;

    private void Start()
    {
        StartCoroutine(CheckChance());
    }

    IEnumerator CheckChance()
    {
        for (int i = 0; i < items.Length; i++)
        {
            float num = Random.Range(0, 100);
            if (num <= items[i].chance)
            {
                SpawnItems(items[i].item, items[i].number);
                items[i].chance += items[i].changeChanceEverySpawn;

                //Divide by zero will occur if the feature is not used
                try
                {
                    if (spawnNum % items[i].spawnsToChangeNumber == 0)
                    {
                        items[i].number += items[i].changeNumber;
                    }
                } catch (System.DivideByZeroException) { };
            }
        }
        spawnNum++;
        yield return new WaitForSeconds(secondsBetweenSpawns);
        StartCoroutine(CheckChance());
    }

    void SpawnItems(GameObject item, int number)
    {
        for (float i = 0; i < number; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-4, 4), 7.5f + i, 0);
            GameObject.Instantiate(item).transform.SetPositionAndRotation(pos, Quaternion.Euler(0, 0, 0));
        }
    }
}

[System.Serializable]
public class Item
{
    public GameObject item;
    public float chance;
    public int number;

    //The amount added onto the chance every time there is a spawn
    public float changeChanceEverySpawn;
    //The amount added onto number when a certain amount of spawns occur
    public int changeNumber;
    //The number of spawns to occur before number changes
    public int spawnsToChangeNumber;
}