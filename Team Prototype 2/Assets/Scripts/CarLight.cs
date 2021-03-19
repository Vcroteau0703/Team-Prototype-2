using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarLight : MonoBehaviour
{
    bool lightOn = false;
    public GameObject light;
    public Slider roadRageSlider;
    AudioSource audioSource;
    public Sprite bgLightOff;
    public Sprite bgLightOn;
    SpriteRenderer bg;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        bg = GetComponent<SpriteRenderer>();
    }

    public void ControlLights()
    {
        if (lightOn)
        {
            light.SetActive(false);
            lightOn = false;
            bg.sprite = bgLightOff;
            audioSource.Play();
            roadRageSlider.value += 10;
        }
        else
        {
            light.SetActive(true);
            lightOn = true;
            bg.sprite = bgLightOn;
            audioSource.Play();
            roadRageSlider.value += 10;
        }
    }
}
