using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineActivator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        foreach (Transform child in other.transform.GetComponentsInChildren<Transform>())
        {
            if (child.gameObject.GetComponent<Outline>() != null)
            {
                child.gameObject.GetComponent<Outline>().enabled = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        foreach (Transform child in other.transform.GetComponentsInChildren<Transform>())
        {
            if (child.gameObject.GetComponent<Outline>() != null)
            {
                child.gameObject.GetComponent<Outline>().enabled = false;
            }
        }
    }
}
