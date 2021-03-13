using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoffeeHit : MonoBehaviour
{
    public Slider slider;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Coffee"))
        {
            Debug.Log("spill");
            gameObject.GetComponent<AudioSource>().Play();
            slider.value += 30;
            other.gameObject.SetActive(false);
        }
    }

}
