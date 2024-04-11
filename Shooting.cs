using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //breytur fyrir hljóð kúlu og hraða
    private AudioSource audiosource;
    public GameObject bullet;
    public float speed = 4000f;

    private void Start()
    {
        //næ í hljóð
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // kóði sem skýtur ef ýtt er á z
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //spila hljóð þegar við skjótum
            Debug.Log("skjOtttttttt");
            audiosource.Play();

            //GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            // búum til kúlu objects með hraða og rigidbody og eyðum svo kúlum svo að við séum ekki með fullan skjá af kúlum
            GameObject instBullet = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
            Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
            instBulletRigidbody.AddForce(transform.forward * speed);
            Destroy(instBullet, 0.5f);//kúl eytt eftir 0.5sek
           
        }
    }
}
