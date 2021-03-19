using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnTouch : MonoBehaviour
{
    [SerializeField]
    private Image[] Prefabs;

    private int randomPrefab;
    public Transform Spawn;
    public Transform Canvas;

    // Update is called once per frame
    public void LunchBox() {
        Debug.Log("Start");
        randomPrefab = Random.Range(0, 5);
        Debug.Log(randomPrefab);
        Image FoodSpawn = Instantiate(Prefabs[randomPrefab], Spawn.position, Quaternion.identity) as Image;
        FoodSpawn.transform.SetParent(Canvas.transform);

        Debug.Log("instantiate object");
    }
}
