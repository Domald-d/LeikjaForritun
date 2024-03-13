using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // private breytur til a� l�ta hluti/bakgrun hreyfast
    private float speed = 30;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        // vi� l�tum hlut/bakgrun hreyfast � �tt a� player
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private float leftBound = -15;
    void Update()
    {
        // if skilyr�i til a� sko�a hvort leik er loki�
        if(playerControllerScript.GameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
