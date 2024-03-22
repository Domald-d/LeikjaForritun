using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hlutursnu : MonoBehaviour
{
    void Update()
    {
        //notum Rotate aðferð til að láta hluti snúast um sjálfa sig
        transform.Rotate(new Vector3(0, 80, 0) * Time.deltaTime);
    }
}