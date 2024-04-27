using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    //breyta fyrir hljóð
    public AudioClip collectedClip;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //collision fall fyrir líf pickups
    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            //if skilyrði ef líf er minna en max líf
            //ef líf er minna en max lif þá bætum við 1 við líf og eyðum líf pickuppinu
            // og spilum hljóð
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);
                controller.PlaySound(collectedClip);
            }
        }

    }
}
