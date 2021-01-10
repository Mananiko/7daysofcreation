using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCastScript : MonoBehaviour
{
    // Whatever is your max distance (remove if not needed).    
    float maxDistance = 100f;
    GameObject interactable;

    public float timeRemaining = 1;
    public bool timerIsRunning = false;

    void FixedUpdate()
    {

        // Will contain the information of which object the raycast hit
        RaycastHit hit;    

        // if raycast hits, it checks if it hit an object with the tag Player
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance) &&
                    hit.collider.gameObject.CompareTag("Interactable"))

        {
            interactable = hit.collider.gameObject;
            Activate();
            timerIsRunning = true;
        }

        if (timerIsRunning && interactable != null)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {               
                timeRemaining = 1;
                timerIsRunning = false;
                Deactivate();
            }
        }
        Debug.Log(timeRemaining);

    }

    void Activate()
    {
        foreach (Transform child in interactable.transform.GetComponentsInChildren<Transform>())
        {
            if (child.gameObject.GetComponent<Outline>() != null)
            {
                child.gameObject.GetComponent<Outline>().enabled = true;
            }
        }
    }

    void Deactivate()
    {
        foreach (Transform child in interactable.transform.GetComponentsInChildren<Transform>())
        {
            if (child.gameObject.GetComponent<Outline>() != null)
            {
                child.gameObject.GetComponent<Outline>().enabled = false;
            }
        }
    }      
}
