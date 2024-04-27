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
        //n�um � rigidbody component
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if skilyr�i ef procjectile fer �taf mappinu �� ey�um vi� �v�
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    //collision fall
    //�egar projectile hittir �vin �� l�gum vi� r�boti�
    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Fix();
        }

        Destroy(gameObject);
    }

    //fall sem sk�tur projectile
    //setjum Addforce me� rigidbody
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

}
