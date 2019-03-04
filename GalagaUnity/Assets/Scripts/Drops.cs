using UnityEngine;

/*
 * Drops a random Item from those passed in through the inspector
 * */
public class Drops : MonoBehaviour
{
    public Item[] items;

    public void Drop()
    {
        bool dropped = false;

        //Go through every item available
        for (int i = 0; i < items.Length; i++)
        {
            //Check to see if an item has already been dropped
            if (!dropped)
            {
                //Generates a random number between 0 and 100
                float num = Random.Range(0, 100);
                //If the number is less than the chance of the item being dropped it is dropped
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
        //Instantiates a prefab of the item at the location of the dropper i.e. the meteorite when hit
        Instantiate(item).transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0, 0, 0));
    }
}
