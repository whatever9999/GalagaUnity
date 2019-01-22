using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
    public GameObject Rocket;
    public int timeBetweenShots;

	void Update () {
        StartCoroutine(Shoot());
	}

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(timeBetweenShots);
    }
}
