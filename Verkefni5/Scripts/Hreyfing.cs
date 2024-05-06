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
        //notum vector 3 fyrir position á hlut
        Vector3 pos = transform.position;
        // geri nýja breytu á y ás og nota math method til að hreyfa hlut upp og niður
        //hægt að nota aðra aðferð en math er auðveldari
        float newY = startY + height * Mathf.Sin(Time.time * speed);
        //notum transform og hreyfum hlutin upp og niður á y ás
        transform.position = new Vector3(pos.x, newY, pos.z);
    }
}
