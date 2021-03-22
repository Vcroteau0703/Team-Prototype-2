using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    Light BlueLight;
    // Blue light flickering
    void Start()
    {
        BlueLight = GetComponent<Light>();
        StartCoroutine(Flashing());
    }
    //Set time for light flicker
    IEnumerator Flashing() {
    while (true)
        {
            yield return new WaitForSeconds(0.4f);
            BlueLight.enabled = !BlueLight.enabled;
        }
    }
   
}
