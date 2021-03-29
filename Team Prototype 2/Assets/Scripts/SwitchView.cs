using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchView : MonoBehaviour
{
    public GameObject frontView;
    public GameObject dashView;
    public GameObject frontViewButton;
    public GameObject dashViewButtons;
    float fillAlpha;
    public Image fill;
    public Button carSeat;
    public GameObject heatImage;

    private void Awake()
    {
        fillAlpha = fill.color.a;
    }

    public void SwitchViews()
    {
        if (frontView.activeInHierarchy)
        {
            frontViewButton.SetActive(false);
            frontView.SetActive(false);
            dashView.SetActive(true);
            dashViewButtons.SetActive(true);
            fill.color = new Color(fill.color.r, fill.color.g, fill.color.b, fillAlpha);
            carSeat.interactable = true;
            heatImage.SetActive(true);
        }
        else
        {
            frontViewButton.SetActive(true);
            frontView.SetActive(true);
            dashView.SetActive(false);
            dashViewButtons.SetActive(false);
            fill.color = new Color(fill.color.r, fill.color.g, fill.color.b, 0f);
            carSeat.interactable = false;
            heatImage.SetActive(false);
        }
    }

}
