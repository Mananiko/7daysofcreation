using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pickupObjects : MonoBehaviour
{
    /*
    * This Script is supposed to be on the main camera and can pick up objects. the object needs to have the tag interactable
    */

    bool pickedUp = false;
    GameObject pickedUpObject;
    attatchMe attachScript;      

    private void Update()
    {
        putDown(pickedUpObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable") && pickedUp == false && (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1")))
        {
            pickUp(other.gameObject);
            //other.gameObject.GetComponent<attatchMe>().enabled = true;
            pickedUpObject = other.gameObject;

            if (other.GetComponent<AudioSource>())
            {
                other.GetComponent<AudioSource>().Play();
            }

        }                    
    }
    //pick up pickubable object
    public void pickUp(GameObject gameObject)
    {
        gameObject.transform.SetParent(this.transform); //sets the parent of the object to camera (object will be always in front of it)
        //gameObject.gameObject.GetComponent<Rigidbody>().isKinematic = true;                                                      //turns Kinematic on, so object will not interfere when picked up
        gameObject.transform.localPosition = new Vector3(0, 0, 1f);                      //sets local position in front of player, so it seems player is holding it
        gameObject.transform.localRotation = Quaternion.Euler(0, 0f, 0);                       //rotates the object
        gameObject.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        //check if other GameObject has attachMe Script and set it to attached
        gameObject.gameObject.GetComponent<attatchMe>().attached = true;              
        pickedUp = true;
    }
    //put down pickubable object
    void putDown(GameObject gameObject)
    {
        if ((Input.GetMouseButtonDown(1) || Input.GetButtonDown("Fire2")) && pickedUp == true)                            //if player clicked 'Right Mousebutton' and picked up object before
        {
            gameObject.transform.SetParent(null);                                                  //unleashes object from its parent
            //gameObject.GetComponent<Rigidbody>().isKinematic = false;          //turns kinematic off, so object can lightly fall on the ground
            gameObject.gameObject.GetComponent<BoxCollider>().isTrigger = false;  
            pickedUp = false;                                                           //object is not picked up
        }
    }


}
