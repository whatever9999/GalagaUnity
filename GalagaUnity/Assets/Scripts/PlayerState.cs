using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * When the player loses a life (but does not die) they are given temporary immunity, which is shown with a flashing effect
 * */
public class PlayerState : MonoBehaviour
{
    public static bool isImmune;
    public float immunityLength;

    public float timeBetweenFlash;
    private float flashTimer;

    private bool toggleVisible;
    private float immunityTimer;

    private Collider2D c2d;
    private SpriteRenderer sr;

    private void Start()
    {
        c2d = this.GetComponent<Collider2D>();
        sr = this.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //If the player is not immune we do not need to make them flash or make the timer go down to check when immunity ends
        if(isImmune)
        {
            //Stop the ship from colliding
            c2d.enabled = false;

            //Flash
            flashTimer += Time.deltaTime;
            if (flashTimer > timeBetweenFlash)
            {
                sr.enabled = toggleVisible;
                toggleVisible = !toggleVisible;
                flashTimer = 0;
            }

            //Check if still immune
            //Makes sure that the player will be visible when they are not immune
            immunityTimer += Time.deltaTime;
            if (immunityTimer > immunityLength)
            {
                sr.enabled = true;
                toggleVisible = false;
                immunityTimer = 0;
                isImmune = false;
                c2d.enabled = true;
            }
        }
    }
}
