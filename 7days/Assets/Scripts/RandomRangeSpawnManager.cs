using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRangeSpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    //public float spawnRangeX = 20;
    public float spawnPosX;
    public float spawnRangeZ_high;
    public float spawnRangeZ_low;

    public float startDelay = 2;
    public float spawnInterval = 1.5f;
        
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnRandomAnimal()
    {
       // Vector3 spawnPosTop = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
       Vector3 spawnPosLeft = new Vector3 (spawnPosX, 0, Random.Range(-spawnRangeZ_low, spawnRangeZ_high));
       // Vector3 spawnPosRight = new Vector3(16, 0, Random.Range(-1,16));

        int animalIndex = Random.Range(0, animalPrefabs.Length);
       // Instantiate(animalPrefabs[animalIndex], spawnPosTop, animalPrefabs[animalIndex].transform.rotation);
        Instantiate(animalPrefabs[animalIndex], spawnPosLeft, animalPrefabs[animalIndex].transform.rotation);
        // Instantiate(animalPrefabs[animalIndex], spawnPosRight, animalPrefabs[animalIndex].transform.rotation * Quaternion.Euler(0f, 90f, 0f));
    }
}
