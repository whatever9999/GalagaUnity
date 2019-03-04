using System.Collections;
using UnityEngine;

/* 
 * Makes all items (ships, meteorites etc.) appear on a clock in random locations
 * */
public class ItemSpawn : MonoBehaviour
{
    public Item[] items;

    public float secondsBetweenSpawns;
    //The number of spawns that have occured so far in the game
    private int spawnNum;

    private void Start()
    {
        StartCoroutine(CheckChance());
    }

    IEnumerator CheckChance()
    {
        //Go through each item passed in through the inspector
        for (int i = 0; i < items.Length; i++)
        {
            //Generate a random number between 0 and 100
            float num = Random.Range(0, 100);
            //Check to see if the number generated is less than the chance of the item appearing
            if (num <= items[i].chance)
            {
                SpawnItems(items[i].item, items[i].number);

                //Divide by zero will occur if the feature is not used
                try
                {
                    //We increase the number of the item spawned if the spawn number is divisible by 'spawnsToChangeNumber'
                    if (spawnNum % items[i].spawnsToChangeNumber == 0)
                    {
                        items[i].number += items[i].changeNumber;
                    }
                } catch (System.DivideByZeroException) { };
            }

            //Increase the chance of the item spawning for next time
            items[i].chance += items[i].changeChanceEverySpawn;
        }

        spawnNum++;

        yield return new WaitForSeconds(secondsBetweenSpawns);
        StartCoroutine(CheckChance());
    }

    void SpawnItems(GameObject item, int number)
    {
        //Instantiate a new prefab in a random position for each 'number'
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