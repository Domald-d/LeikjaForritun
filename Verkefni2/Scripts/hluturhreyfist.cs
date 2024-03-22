using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hluturhreyfist : MonoBehaviour
{
    private float speed = 2f;
    private float height = 6f;
    private float startX = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //notum vector 3 fyrir position � hlut
        Vector3 pos = transform.position;
        // geri n�ja breytu � y �s og nota math method til a� hreyfa hlut vinstri og h�gri
        //h�gt a� nota a�ra a�fer� en math er au�veldari
        float newX = startX + height * Mathf.Sin(Time.time * speed);
        //notum transform og hreyfum hlutin upp og ni�ur � x �s
        transform.position = new Vector3(newX, pos.y, pos.z);
    }
}
