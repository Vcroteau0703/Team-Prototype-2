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

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ControlLights()
    {
        if (lightOn)
        {
            light.SetActive(false);
            lightOn = false;
            audioSource.Play();
            roadRageSlider.value += 10;
        }
        else
        {
            light.SetActive(true);
            lightOn = true;
            audioSource.Play();
            roadRageSlider.value += 10;
        }
    }
}
