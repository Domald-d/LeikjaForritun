using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hlutursnu : MonoBehaviour
{
    void Update()
    {
        //transform til að snúa peningum og lyklum
        transform.Rotate(new Vector3(0,80,0) * Time.deltaTime);
    }
}
