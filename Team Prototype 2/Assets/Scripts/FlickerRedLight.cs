using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerRedLight : MonoBehaviour
{
    
    Light RedLight;
    //Red light Flicker
    void Start()
    {
        RedLight = GetComponent<Light>();
        StartCoroutine(Flashing());
    }

    //Time set for flicker
    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.3f);
            RedLight.enabled = !RedLight.enabled;
        }
    }

}

