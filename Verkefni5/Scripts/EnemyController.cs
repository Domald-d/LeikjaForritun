using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    //breytur fyrir hljóð,stig og texta
    public AudioClip takeDamage;
    public TextMeshProUGUI textar;
    public static int stig = 0;

    // Start is called before the first frame update
    void Start()
    {
        textar.text = "Stig: " + stig.ToString();

    }

    // Update is called once per frame
    void Update()
    {
    }

    //fall sem eyðir óvin og bætir stigi við stiga töflu
    public void kill()
    {
        Destroy(gameObject);
        stig += 2;
        textar.text = "Stig: " + stig.ToString();
    }

    //collision  fall ef player snertir óvin þá missum við stig
    //og bretytum stiga töflu og ef spilari er með minna en 0 stig þá sendum við spilara í dauða scenu
    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            stig -= 2;
            textar.text = "Stig: " + stig.ToString();
            player.PlaySound(takeDamage);
            if (stig < 0)
            {
                SceneManager.LoadScene(2);
                stig = 0;
            }
        }
    }

}
