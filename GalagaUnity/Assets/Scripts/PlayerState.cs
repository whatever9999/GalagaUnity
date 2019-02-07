using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static bool isImmune;
    public float immunityLength;

    public float timeBetweenFlash;
    private float flashTimer;

    private bool toggleVisible;
    private float immunityTimer;
    private Collider2D c2D;
    private SpriteRenderer sr;

    private void Start()
    {
        c2D = this.GetComponent<Collider2D>();
        sr = this.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(isImmune)
        {
            c2D.enabled = false;

            flashTimer += Time.deltaTime;
            if (flashTimer > timeBetweenFlash)
            {
                sr.enabled = toggleVisible;
                toggleVisible = !toggleVisible;
                flashTimer = 0;
            }

            immunityTimer += Time.deltaTime;
            if (immunityTimer > immunityLength)
            {
                sr.enabled = true;
                toggleVisible = false;
                immunityTimer = 0;
                isImmune = false;
                c2D.enabled = true;
            }
        }
    }
}
