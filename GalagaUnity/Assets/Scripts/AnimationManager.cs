using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager instance;

    public void Awake()
    {
        instance = this;
    }

    public void ExplodeMeteorite(GameObject meteorite)
    {
        meteorite.GetComponent<Animator>().SetTrigger("Exploding");
    }
}
