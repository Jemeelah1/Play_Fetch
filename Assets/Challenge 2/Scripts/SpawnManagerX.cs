using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;
    private float spawnPosZ = 0; 
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    private float dogSpawnCooldown = 1.5f;  // Time in seconds before allowing another dog spawn
    private float nextDogSpawnTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        // Start invoking the SpawnRandomBall method repeatedly
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);

        // Start invoking the SpawnDog method repeatedly
        InvokeRepeating("SpawnDog", dogSpawnCooldown, nextDogSpawnTime); 
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
            
        //     Debug.Log("Space bar pressed");
        //     SpawnDog();
        // }
    }

    void SpawnRandomBall()
    {
        // Ensure the array is not empty to avoid errors
        if (ballPrefabs.Length == 0)
        {
            Debug.LogWarning("ballPrefabs array is empty!");
            return;
        }
        // Randomize ball selection
        int ballIndex = Random.Range(0, ballPrefabs.Length);

        // Generate random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, spawnPosZ);

        // Instantiate a random ball prefab at the generated position
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }

    void SpawnDog()
    {
        
        Vector3 spawnPos = new Vector3(transform.position.x, 0, transform.position.z);
        Instantiate(dogPrefab, spawnPos, dogPrefab.transform.rotation);
        
    }
}
