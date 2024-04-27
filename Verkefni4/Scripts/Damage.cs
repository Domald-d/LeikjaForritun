using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    //breyta fyrir hljóð
    public AudioClip takeDamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //collision fall fyrir player ef hann snertir hindrun þá tökum við líf af player og spilum hljóð
    void OnTriggerStay2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            controller.ChangeHealth(-1);
            controller.PlaySound(takeDamage);
        }
    }

}
