using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManage : MonoBehaviour
{
    // private og public breytur fyrir spawner
    private PlayerController playerControllerScript;
    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;
    // Start is called before the first frame update
    void Start()
    {
        // notum invokerepeating aðferð til að spawna hindranir
        InvokeRepeating("spawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // búum til void fall sem spawnar hindrana hluti
    void spawnObstacle()
    {
        if(playerControllerScript.GameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
