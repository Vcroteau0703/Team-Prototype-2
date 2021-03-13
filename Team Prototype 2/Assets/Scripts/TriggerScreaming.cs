using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerScreaming : MonoBehaviour
{
    Slider slider;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value >= slider.maxValue)
        {
            audioSource.Play();
            slider.value = 0;
        }
    }
}
