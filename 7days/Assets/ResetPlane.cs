using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlane : MonoBehaviour
{
    GameObject player;
    Vector3 starpos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        starpos = player.transform.position;
    }   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
         player.gameObject.transform.position = starpos;
        }
       
    }
}
