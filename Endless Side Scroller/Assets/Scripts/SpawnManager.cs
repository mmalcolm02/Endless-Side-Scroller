using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float firstSpawn = 1;
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        //call player controller script
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //invoke the first obstacle
        Invoke("SpawnObstacle", firstSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle() {
        if (playerControllerScript.gameOver == false) {
            float spawnRate = Random.Range(1.2f, 3); //generate random float
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation); //instantiate is effect of invoke
            Invoke("SpawnObstacle", spawnRate); //determine the next invocation of spawnObstacle  method
        }
        
    }
}
