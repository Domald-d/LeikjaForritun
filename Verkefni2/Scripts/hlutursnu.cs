using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hlutursnu : MonoBehaviour
{
    void Update()
    {
        //notum Rotate a�fer� til a� l�ta hluti sn�ast um sj�lfa sig
        transform.Rotate(new Vector3(0, 80, 0) * Time.deltaTime);
    }
}