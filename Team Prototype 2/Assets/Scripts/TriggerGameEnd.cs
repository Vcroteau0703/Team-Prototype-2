using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGameEnd : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject gameUI;
    public GameObject radio;

    public void EndGame()
    {
        gameUI.SetActive(false);
        radio.SetActive(false);
        gameOverScreen.SetActive(true);
    }
}
