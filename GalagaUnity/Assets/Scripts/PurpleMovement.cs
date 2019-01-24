using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleMovement: MonoBehaviour {
    public float speed = 0.5f;

    private void Update() {
        Vector2 playerPosition = GameObject.Find("Player").transform.position;
        transform.position = Vector2.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
    }
}
