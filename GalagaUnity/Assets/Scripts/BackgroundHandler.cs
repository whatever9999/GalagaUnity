using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundHandler : MonoBehaviour
{
    public float speed;
    public float backgroundHeight;

    public static BackgroundHandler instance;

    private void Awake()
    {
        instance = this;
    }

    void FixedUpdate()
    {
        transform.Translate(0, -speed * Time.deltaTime, 0);
        if (transform.position.y <= -backgroundHeight)
        {
            Vector3 restartPos = transform.position;
            restartPos.y = backgroundHeight * 2;
            transform.SetPositionAndRotation(restartPos, Quaternion.Euler(0, 0, 0));
        }
    }
}