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

    public Slider seatHeatSlider;
    public Slider stressSlider;


    float temperatureTimer;
    float seatWarmerTimer;

    void Start()
    {
        SetMaxHeat(maxHeat);

        temperatureTimer = 10;
        seatWarmerTimer = 10;
    }

    void Update()
    {
        TemperatureSystem();
        SeatWarmerSystem();
    }

    public void TemperatureUp()
    {
        temperature += 1;

        if (temperature > 120)
        {
            stressSlider.value += 1;
        }
    }

    public void TemperatureDown()
    {
        temperature -= 1;

        if (temperature < -120)
        {
            stressSlider.value += 1;
        }
    }


    public void SeatHeatPress()
    {
        if (seatOn)
        {
            seatOn = false;
        }
        else if (!seatOn)
        {
            seatOn = true;
        }
    }


    public void SetMaxHeat(int heat)
    {
        seatHeatSlider.maxValue = heat;
        seatHeatSlider.value = heat;
    }

    public void SetHeat(float heat)
    {
        seatHeatSlider.value = heat;
    }

    void TemperatureSystem()
    {
        temperatureUI.text = temperature.ToString("0");

        if (temperature > 80)
        {
            Debug.Log("TOO HOT!!!");
            stressSlider.value += 50 * Time.deltaTime;

            if (temperatureTimer > 0)
            {
                temperatureTimer -= 1 * Time.deltaTime;
            }


            if (temperature > 80 && seatHeat > 80)
            {
                Debug.Log("I'M MELTING!!!");
                stressSlider.value += 10 * Time.deltaTime;
                //temperatureTimer -= 1 * Time.deltaTime;
                //seatWarmerTimer -= 1 * Time.deltaTime;
            }
        }

        if (temperature < 20)
        {
            Debug.Log("TOO COLD!!!");
            stressSlider.value += 50 * Time.deltaTime;

            if (temperatureTimer > 0)
            {
                temperatureTimer -= 1 * Time.deltaTime;
            }

            /*if (temperature < 20 && seatHeat > 80)
            {
                Debug.Log("I'M MELTING!!!");
                stressSlider.value -= 40 * Time.deltaTime; //this goes down because the heat balances itself out
            }*/
        }

        if (temperatureTimer <= 0)
        {
            if (temperature > 50)
            {
                temperature -= 1;
                if (temperature < 50)
                {
                    temperature = 50;
                    //temperatureTimer = 10;
                }
            }

            if (temperature < 50)
            {
                temperature += 1;
                if (temperature > 50)
                {
                    temperature = 50;
                    //temperatureTimer = 10;
                }
            }

            if (temperature == 50)
            {
                temperatureTimer = 10;
            }
        }
    }

    void SeatWarmerSystem()
    {
        if (seatOn)
        {
            seatHeat += 5 * Time.deltaTime;
        }
        else if (!seatOn && seatHeat > 0)
        {
            seatHeat -= 5 * Time.deltaTime;

            if (seatHeat < 0)
            {
                seatHeat = 0;
            }
        }

        if (seatHeat > 100)
        {
            Debug.Log("MY BUTT... IT BURNS!!!!");
            stressSlider.value += 50 * Time.deltaTime;

            if (seatWarmerTimer > 0)
            {
                seatWarmerTimer -= 1 * Time.deltaTime;
            }

            seatHeat = maxHeat;
        }

        SetHeat(seatHeat);

        if (seatWarmerTimer <= 0)
        {
            seatOn = false;
            seatWarmerTimer = 0;

            if (seatHeat == 0)
            {
                seatWarmerTimer = 10;
            }

        }
    }

}

