using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchView : MonoBehaviour
{
    public GameObject frontView;
    public GameObject dashView;
    public GameObject frontViewButton;
    public GameObject dashViewButtons;

    public void SwitchViews()
    {
        if (frontView.activeInHierarchy)
        {
            frontViewButton.SetActive(false);
            frontView.SetActive(false);
            dashView.SetActive(true);
            dashViewButtons.SetActive(true);
        }
        else
        {
            frontViewButton.SetActive(true);
            frontView.SetActive(true);
            dashView.SetActive(false);
            dashViewButtons.SetActive(false);
        }
    }

}
