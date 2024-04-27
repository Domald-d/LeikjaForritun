using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    //breyta fyrir hlj��
    public AudioClip collectedClip;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //collision fall fyrir l�f pickups
    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            //if skilyr�i ef l�f er minna en max l�f
            //ef l�f er minna en max lif �� b�tum vi� 1 vi� l�f og ey�um l�f pickuppinu
            // og spilum hlj��
            if (controller.health < controller.maxHealth)
            {
                controller.ChangeHealth(1);
                Destroy(gameObject);
                controller.PlaySound(collectedClip);
            }
        }

    }
}
