using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioManager : MonoBehaviour
{

    public AudioSource[] radioStations;

    public Slider volumeSlider;

    [HideInInspector]public int stationIDs;
    public Text stationNames;

    public Text peaceSongText;
    public Text annoySongText;

    // Start is called before the first frame update
    void Start()
    {
        radioStations = gameObject.GetComponentsInChildren<AudioSource>();

        radioStations[1].mute = !radioStations[1].mute;
    }

    void Update()
    {
        foreach (AudioSource audioVol in radioStations)
        {
            audioVol.volume = volumeSlider.value;
        }

        switch (stationIDs)
        {
            case 0:
                stationNames.text = "PEACEFUL 17.1";
                peaceSongText.color = new Color(peaceSongText.color.r, peaceSongText.color.g, peaceSongText.color.b, 1);
                annoySongText.color = new Color(annoySongText.color.r, annoySongText.color.g, annoySongText.color.b, 0);
                break;
            case 1:
                stationNames.text = "ANNOYING 108.5";
                peaceSongText.color = new Color(peaceSongText.color.r, peaceSongText.color.g, peaceSongText.color.b, 0);
                annoySongText.color = new Color(annoySongText.color.r, annoySongText.color.g, annoySongText.color.b, 1);
                break;
        }
    }

    public void RadioChangePress()
    {
        switch (stationIDs)
        {
            case 0:
                stationIDs = 1;
                break;
            case 1:
                stationIDs = 0;
                break;
        }

        radioStations[0].mute = !radioStations[0].mute;
        radioStations[1].mute = !radioStations[1].mute;
    }
}
