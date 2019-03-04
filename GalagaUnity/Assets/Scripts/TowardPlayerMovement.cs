using UnityEngine;
using System;

/*
 * Ship finds the player object and moves towards it
 * */
public class TowardPlayerMovement: ItemMovement {
    private void Update() {
        try
        {
            Vector2 playerPosition = FindObjectOfType<PlayerState>().transform.position;
            transform.position = Vector2.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
        } catch (NullReferenceException)
        {
            //When the player dies the purple ship won't be able to find the object and will just move in a straight line instead of towards the player
            Vector2 targetPostion = new Vector2(transform.position.x, -5);
            transform.position = Vector2.MoveTowards(transform.position, targetPostion, speed * Time.deltaTime);
        }
    }
}
