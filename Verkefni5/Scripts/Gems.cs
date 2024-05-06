using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Gems : MonoBehaviour
{
    //breytur fyrir hljóð og texta
    public AudioClip collectedClip;
    private TextMeshProUGUI countText;
    // Start is called before the first frame update
    void Start()
    {
        //náum í texta object
        countText = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //collision fall fyrir stiga gjöf þegar player tekur upp demant
    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController e = other.collider.GetComponent<RubyController>();
        if (e != null)
        {
            e.PlaySound(collectedClip);
            EnemyController.stig += 1;
            SetCountText();
            Destroy(gameObject);

        }

    }

    public void SetCountText()
    {
        //fall til að bæta við stiga gjöf
        countText.text = "Stig: " + EnemyController.stig.ToString();
    }
}
