using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{
    public Item[] items;

    public void Drop()
    {
        bool dropped = false;

        for (int i = 0; i < items.Length; i++)
        {
            if (!dropped)
            {
                float num = Random.Range(0, 100);
                if (num <= items[i].chance)
                {
                    DropItem(items[i].item, items[i].number);
                    dropped = true;
                }
            }
        }
    }

    private void DropItem(GameObject item, int number)
    {
        GameObject.Instantiate(item).transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, 0));
    }
}
