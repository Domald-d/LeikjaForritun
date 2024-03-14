using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBack : MonoBehaviour
{
    // B�um til private breytur til a� l�ta bakgrun hreyfast og uppf�ra sig svo hann l�tur �t fyrir a� vera endalaus
    private Vector3 startPos;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        // l�tum bakgrunn loopast
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        // if skilyr�i til a� sko�a hvort byrjunar sta�a bakgruns er meiri en sta�a x �s
        if (transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
