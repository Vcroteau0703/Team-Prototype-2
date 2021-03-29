using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoffeeHit : MonoBehaviour
{
    public Slider slider;
    public Animator robo;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Drag"))
        {
            Animator coffee = other.gameObject.GetComponent<Animator>();
            coffee.SetTrigger("hitdude");

            robo.SetTrigger("sad");
            other.gameObject.GetComponent<AudioSource>().Play();
            slider.value += 30;
        }
    }

}
