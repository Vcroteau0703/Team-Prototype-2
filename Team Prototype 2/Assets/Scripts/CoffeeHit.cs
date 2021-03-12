using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeHit : MonoBehaviour
{

    public GameObject coffee;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(coffee)
        {
            Debug.Log("spill");
            other.gameObject.GetComponent<AudioSource>().Play();
        }
    }

}
