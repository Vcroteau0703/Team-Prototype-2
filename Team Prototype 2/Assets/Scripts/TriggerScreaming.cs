using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerScreaming : MonoBehaviour
{
    Slider slider;
    AudioSource audioSource;
    public GameObject cop;
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
            cop.SetActive(true);
            slider.value = 0;
        }
    }
}
