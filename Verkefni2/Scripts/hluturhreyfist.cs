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
        //notum vector 3 fyrir position á hlut
        Vector3 pos = transform.position;
        // geri nýja breytu á y ás og nota math method til að hreyfa hlut vinstri og hægri
        //hægt að nota aðra aðferð en math er auðveldari
        float newX = startX + height * Mathf.Sin(Time.time * speed);
        //notum transform og hreyfum hlutin upp og niður á x ás
        transform.position = new Vector3(newX, pos.y, pos.z);
    }
}
