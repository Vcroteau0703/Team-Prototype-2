using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchController : MonoBehaviour
{
    public Slider slider;

    private bool dragActive = false;

    Vector2 screenPosition;

    Vector3 worldPosition;

    public GameObject selectedObject;

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
                if(hit.collider.tag == "Drag")
                {
                    Debug.Log("You hit draggable object");
                    selectedObject = hit.transform.gameObject;
                    if (selectedObject != null)
                    {
                        //lastCoffee = coffee;
                        InitDrag();
                    }
                }

                if (!changeRadio)
                {
                    if (hit.collider.tag == "Phone")
                    {
                        hit.collider.gameObject.GetComponent<AudioSource>().clip = trashMusic;
                        hit.collider.gameObject.GetComponent<AudioSource>().Play();
                        slider.value += 40;
                        changeRadio = true;
                    }
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
        selectedObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, -3.25f);
    }

    void Drop()
    {
        dragActive = false;
    }
}
