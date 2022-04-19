using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefab;


    private PlayerController playerControllerScript;
    private int indexOfPrefab;


    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", 2f, 2f);
    }


    // Update is called once per frame
    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Vector3 spawnPos = new Vector3(Random.Range(25, 60), 0, 0);
            indexOfPrefab = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[indexOfPrefab], spawnPos, obstaclePrefab[indexOfPrefab].transform.rotation);
        }
    }
}