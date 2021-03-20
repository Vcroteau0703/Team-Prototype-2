using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoffeeHit : MonoBehaviour
{
    public Slider slider;
    public Animator coffee;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Coffee"))
        {
            Debug.Log("spill");
            coffee.SetTrigger("hitdude");
            gameObject.GetComponent<AudioSource>().Play();
            slider.value += 30;
        }
    }

}
