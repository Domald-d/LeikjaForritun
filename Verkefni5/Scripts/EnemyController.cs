using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    //breytur fyrir hlj��,stig og texta
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

    //fall sem ey�ir �vin og b�tir stigi vi� stiga t�flu
    public void kill()
    {
        Destroy(gameObject);
        stig += 2;
        textar.text = "Stig: " + stig.ToString();
    }

    //collision  fall ef player snertir �vin �� missum vi� stig
    //og bretytum stiga t�flu og ef spilari er me� minna en 0 stig �� sendum vi� spilara � dau�a scenu
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
