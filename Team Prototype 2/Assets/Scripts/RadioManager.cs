using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioManager : MonoBehaviour
{

    public AudioSource[] radioStations;

    // Start is called before the first frame update
    void Start()
    {
        radioStations = gameObject.GetComponentsInChildren<AudioSource>();

        radioStations[1].mute = !radioStations[1].mute;
    }

    public void RadioChangePress()
    {
        radioStations[0].mute = !radioStations[0].mute;
        radioStations[1].mute = !radioStations[1].mute;
    }
}
