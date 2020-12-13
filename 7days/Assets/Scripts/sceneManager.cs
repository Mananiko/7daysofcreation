using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    private float timer = 0;
    [SerializeField]
    private float resetLimit = 40;

    //reset level when player inactive for more than X seconds
    void Update()
    {
        //check if there is any Input
        if (Input.anyKeyDown || Input.GetAxisRaw("Mouse X") != 0 || Input.GetAxisRaw("Mouse Y") != 0 || Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
            resetTimer();
        else
            tick();
        if (timer > resetLimit)
            SceneManager.LoadScene("Day 0");
       
    }

    void resetTimer()
    {
        timer = 0;
    }

    void tick()
    {
        timer += Time.deltaTime;
    }

    // load next level when player enters portal
    private void OnTriggerEnter(Collider other)
    {
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 7);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
