using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeHit : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Coffee"))
        {
            Debug.Log("spill");
            gameObject.GetComponent<AudioSource>().Play();
            other.gameObject.SetActive(false);
        }
    }

}
