using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefab;

    private Vector3 spawnPos = new Vector3(38, 0, 0);
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
            indexOfPrefab = Random.Range(0, obstaclePrefab.Length);
            Instantiate(obstaclePrefab[indexOfPrefab], spawnPos, obstaclePrefab[indexOfPrefab].transform.rotation);
        }
    }
}