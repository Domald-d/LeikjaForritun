using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //rigidbody breyta
    Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Awake()
    {
        //náum í rigidbody component
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if skilyrði ef procjectile fer útaf mappinu þá eyðum við því
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    //collision fall
    //þegar projectile hittir óvin þá lögum við róbotið
    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Fix();
        }

        Destroy(gameObject);
    }

    //fall sem skýtur projectile
    //setjum Addforce með rigidbody
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

}
