using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attatchMe : MonoBehaviour
{
   public bool attached = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Interactable") && attached == false)
        {                    
                attached = true;                    
                //gameObject.GetComponent<Rigidbody>().isKinematic = true;              //turns Kinematic on, so object will not interfere when picked up
                gameObject.GetComponent<BoxCollider>().isTrigger = true;              // activate trigger so the object can pickUp the next one
                transform.SetParent(other.gameObject.transform);                       //sets the parent of the object 
           
            //if this object has a sound, play when being attached to something
            if (gameObject.GetComponent<AudioSource>())
            {
                gameObject.GetComponent<AudioSource>().Play();
            }
        }    
    }    
}
