using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemSpawn : MonoBehaviour
{
    public Item[] items;

    void Update()
    {
        for(int i = 0; i < items.Length; i++)
        {
            int num = (int)Random.Range(0, 10000);
            if (num <= items[i].chance)
            {
                SpawnItems(items[i].item, items[i].number);
            }
        }
    }

    void SpawnItems(GameObject item, int number)
    {
        for (float i = 0; i < number; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-4, 4), 7.5f + i, 0);
            GameObject.Instantiate(item).transform.SetPositionAndRotation(pos, Quaternion.Euler(0, 0, 0));
        }
    }

    [System.Serializable]
    public class Item
    {
        public GameObject item;
        public int chance;
        public int number;
    }
}