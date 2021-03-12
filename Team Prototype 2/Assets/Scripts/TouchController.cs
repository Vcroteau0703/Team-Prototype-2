﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{

    private bool dragActive = false;

    Vector2 screenPosition;

    Vector3 worldPosition;

    public GameObject lastCoffee;

    public AudioClip trashMusic;

    bool changeRadio;


    void Awake()
    {
        TouchController[] controllers = FindObjectsOfType<TouchController>();
        if(controllers.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        //Debug.Log(screenPosition);
        //Debug.Log(worldPosition);

        if (dragActive)
        {
            if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                Drop();
                return;
            }
        }
        
        if(Input.touchCount > 0)
        {
            screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if (dragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
            if(hit.collider != null)
            {
                if(hit.collider.tag == "Coffee")
                {
                    Debug.Log("You hit Coffee");
                }

                if (!changeRadio)
                {
                    if (hit.collider.tag == "Phone")
                    {
                        hit.collider.gameObject.GetComponent<AudioSource>().clip = trashMusic;
                        hit.collider.gameObject.GetComponent<AudioSource>().Play();
                        changeRadio = true;
                    }
                }
                

                GameObject coffee = hit.transform.gameObject;
                if(coffee != null)
                {
                    //lastCoffee = coffee;
                    InitDrag();
                }
            }
        }
    }

    void InitDrag()
    {
        dragActive = true;
    }

    void Drag()
    {
        lastCoffee.transform.position = new Vector2(worldPosition.x, worldPosition.y);
    }

    void Drop()
    {
        dragActive = false;
    }
}
