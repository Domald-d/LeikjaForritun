using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hluturuppognidur : MonoBehaviour
{
    //private breytur til að fá hlut til að hreyfa sig upp og niður
    private float speed = 2f;
    private float height = 3f;
    private float startY = 4f;
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
