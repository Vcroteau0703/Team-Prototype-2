using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTouch : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Prefabs;

    private int randomPrefab;
    public Transform Spawn;
    public Transform frontview;

    // Update is called once per frame
    public void LunchBox() {
        Debug.Log("Start");
        randomPrefab = Random.Range(0, Prefabs.Length);
        Debug.Log(randomPrefab);
        Instantiate(Prefabs[randomPrefab], Spawn.position, Quaternion.identity, frontview);
      

        Debug.Log("instantiate object");
    }
}
