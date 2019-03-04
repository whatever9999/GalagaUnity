using UnityEngine;
using System;

/**
 * Sets triggers of animations
 * */
public class AnimationManager : MonoBehaviour
{
    public static AnimationManager instance;

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
        }
    }

    //An instance of the meteorite prefab is passed into the function
    public void ExplodeMeteorite(GameObject meteorite)
    {
        //If the 'meteorite' hit is a meteorite drop (rocket) then a MissingComponentException will occur
        //In this case the rocket will just be destroyed (It has no animation)
        try
        {
            meteorite.GetComponent<Animator>().SetTrigger("Exploding");
        }
        catch (MissingComponentException) {
            Destroy(meteorite);
        };
    }
}
