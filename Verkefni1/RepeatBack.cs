using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBack : MonoBehaviour
{
    // Búum til private breytur til að láta bakgrun hreyfast og uppfæra sig svo hann lýtur út fyrir að vera endalaus
    private Vector3 startPos;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        // látum bakgrunn loopast
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // if skilyrði til að skoða hvort byrjunar staða bakgruns er meiri en staða x ás
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
