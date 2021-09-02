using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 10.0f;
    private float spawnPosZ = 20.0f;
    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;
    private float spawnPositionAxesX = 26.0f;



    Vector3 spawnPosition;
    Quaternion spawnRotation;

    

    private void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    public void SpawnRandomAnimal()
    {
        //generate random position of the random animal
        int arrayIndex = Random.Range(0, animalPrefabs.Length);
        int typeOfSPawnPosition = Random.Range(1, 4);

        switch (typeOfSPawnPosition)
        {
            case 1:
                spawnPosition = new Vector3(spawnPositionAxesX, 0, Random.Range(2, 14));
                spawnRotation = Quaternion.Euler(0, 270, 0);
                break;

            case 2:
                spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
                spawnRotation = Quaternion.Euler(0, 180, 0);
                break;
            case 3:
                spawnPosition = new Vector3(-spawnPositionAxesX, 0, Random.Range(2, 14));
                spawnRotation = Quaternion.Euler(0, 90, 0);
                break;

            default:
                break;
        }

        //create animal
        Instantiate(animalPrefabs[arrayIndex], spawnPosition, spawnRotation);
    }
}
