using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerFollower : MonoBehaviour
{
    // Start is called before the first frame update
    // public og private breytur fyrir myndav�l til a� elta player
    public Transform player;
    public Vector3 offset;
    private Space offsetPositionSpace = Space.Self;
    private bool lookAt = true;
    // Update is called once per frame
    void Update()
    {
        //if skilyr�i fyrir myndav�l �egar spilari hreyfir sig e�a hoppar
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = player.TransformPoint(offset);
        }
        else
        {
            transform.position = player.position + offset;

        }

        // h�rna reiknum vi� �t hvert spilari er a� horfa �egar hann sn�r s�r
        if (lookAt)
        {
            transform.LookAt(player);
        }
        else
        {
            transform.rotation = player.rotation;
        }

    }

}
