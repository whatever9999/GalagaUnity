using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemSpawn : MonoBehaviour
{
    public Item[] items;
    public int secondsBetweenSpawns;

    void Update()
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
            }
        }
        yield return new WaitForSeconds(secondsBetweenSpawns);
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
}