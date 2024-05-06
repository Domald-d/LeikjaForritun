using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hreyfing : MonoBehaviour
{
    private float speed = 2f;
    private float height = 2f;
    private float startY = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //notum vector 3 fyrir position � hlut
        Vector3 pos = transform.position;
        // geri n�ja breytu � y �s og nota math method til a� hreyfa hlut upp og ni�ur
        //h�gt a� nota a�ra a�fer� en math er au�veldari
        float newY = startY + height * Mathf.Sin(Time.time * speed);
        //notum transform og hreyfum hlutin upp og ni�ur � y �s
        transform.position = new Vector3(pos.x, newY, pos.z);
    }
}
