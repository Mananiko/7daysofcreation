using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupObjects : MonoBehaviour
{
    bool pickedUp = false;
    GameObject pickedUpObject;

    private void Update()
    {
        putDown(pickedUpObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable") && pickedUp == false && Input.GetMouseButtonDown(0))
        {
            pickUp(other.gameObject);
            pickedUpObject = other.gameObject;
        }                    
    }

    void pickUp(GameObject gameObject)
    {
        gameObject.transform.SetParent(Camera.main.transform); //sets the parent of the object to camera (object will be always in front of it)
        gameObject.gameObject.GetComponent<Rigidbody>().isKinematic = true;                                                      //turns Kinematic on, so object will not interfere when picked up
        gameObject.transform.localPosition = new Vector3(4f, -1.5f, 5f);                      //sets local position in front of player, so it seems player is holding it
        gameObject.transform.localRotation = Quaternion.Euler(0, 0f, 0);                       //rotates the object
        gameObject.gameObject.GetComponent<BoxCollider>().enabled = false;
        pickedUp = true;
    }

    void putDown(GameObject gameObject)
    {
        if (Input.GetMouseButtonDown(1) && pickedUp == true)                            //if player clicked 'E' and picked up object before
        {
            gameObject.transform.SetParent(null);                                                  //unleashes object from its parent
            gameObject.GetComponent<Rigidbody>().isKinematic = false;          //turns kinematic off, so object can lightly fall on the ground
            gameObject.gameObject.GetComponent<BoxCollider>().enabled = true;  
            pickedUp = false;                                                           //object is not picked up
        }
    }


}
