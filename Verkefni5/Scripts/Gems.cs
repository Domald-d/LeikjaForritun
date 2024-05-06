using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class Gems : MonoBehaviour
{
    //breytur fyrir hlj�� og texta
    public AudioClip collectedClip;
    private TextMeshProUGUI countText;
    // Start is called before the first frame update
    void Start()
    {
        //n�um � texta object
        countText = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //collision fall fyrir stiga gj�f �egar player tekur upp demant
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
        //fall til a� b�ta vi� stiga gj�f
        countText.text = "Stig: " + EnemyController.stig.ToString();
    }
}
