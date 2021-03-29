using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureSlider : MonoBehaviour
{

    public float temperature;
    public Text temperatureUI;

    public float seatHeat;
    public int maxHeat = 100;
    public bool seatOn;
    public Text seatHeatUI;
    public Slider seatHeatSlider;

    public Slider stressSlider;

    public float timer;

    void Start()
    {
        SetMaxHeat(maxHeat);
    }

    // Update is called once per frame
    void Update()
    {
        temperatureUI.text = temperature.ToString("0");

        if(temperature > 80)
        {
            Debug.Log("TOO HOT!!!");
            stressSlider.value += 1f;
        } 
        else if(temperature < 20)
        {
            Debug.Log("TOO COLD!!!");
        }
        else if (temperature < -20)
        {
            Debug.Log("I'M FREEZING!!!");
        }
        else if (temperature > 120)
        {
            Debug.Log("I'M MELTING!!!");
        }


        if (seatOn)
        {
            seatHeat += 5 * Time.deltaTime;
        } 
        else if (!seatOn && seatHeat > 0)
        {
            seatHeat -= 5 * Time.deltaTime;

            if(seatHeat < 0)
            {
                seatHeat = 0;
            }
        }

        if(seatHeat > 100)
        {
            Debug.Log("MY BUTT... IT BURNS!!!!");
            seatHeat = maxHeat;
        }

        SetHeat(seatHeat);
    }

    public void TemperatureUp()
    {
        temperature += 1;
    }

    public void TemperatureDown()
    {
        temperature -= 1;
    }

    /*
    public void SeatHeatPress()
    {
        if (seatOn)
        {
            seatOn = false;
            seatHeatUI.text = "Seat Heat: Off";
        } 
        else if (!seatOn)
        {
            seatOn = true;
            seatHeatUI.text = "Seat Heat: On";
        }
    }
    */

    public void SetMaxHeat(int heat)
    {
        seatHeatSlider.maxValue = heat;
        seatHeatSlider.value = heat;
    }

    public void SetHeat(float heat)
    {
        seatHeatSlider.value = heat;
    }
}
