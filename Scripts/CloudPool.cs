using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudPool : MonoBehaviour {

    public GameObject cloudPrefab;

    private int cloudPoolSize = 5;
    private float spawnRate = 5f;
    private float cloudMin = -2f;
    private float cloudMax = 3.5f;
    private GameObject[] clouds;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    private float spawnXPosition = -1f;
    private int currentCloud = 0;

    // Use this for initialization
    void Start ()
    {
        clouds = new GameObject[cloudPoolSize];
        for (int i = 0; i < cloudPoolSize; i++)
        {
            clouds[i] = (GameObject)Instantiate(cloudPrefab, objectPoolPosition, Quaternion.identity);
        }
    }
    
    // Update is called once per frame
    void Update ()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (PlaneControll.instance.GameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(cloudMin, cloudMax);
            clouds[currentCloud].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentCloud++;

            if (currentCloud >= cloudPoolSize)
            {
                currentCloud = 0;
            }
        }
    }
}
