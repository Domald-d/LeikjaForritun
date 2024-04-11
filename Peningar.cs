using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Peningar : MonoBehaviour
{
    //private breytur fyrir texta og hlj��
    private TextMeshProUGUI countText;
    private AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        //n�um � texta object og hlj��
        countText = GameObject.Find("Text").GetComponent<TextMeshProUGUI>();
        audiosource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //sko�um hvort leikma�ur snertir pening
            //ef leikma�ur snertir pening �� spilum vi� hlj�� og b�tum vi� okkur stigi
            //kalla � coroutine fall svo a� hlj�� spilast
            audiosource.Play();
            Kassi.count = Kassi.count + 2;
            SetCountText();//kallar � a�fer�ina
            StartCoroutine(AfterSound());
        }
    }

    //nota ienumerator a�fer� sem spilar hlj�� og ey�ir svo peningum
    IEnumerator AfterSound()
    {
        yield return new WaitForSeconds(audiosource.clip.length);
        Destroy(gameObject);    
        gameObject.SetActive(false);
    }

    public void SetCountText()//h�r er a�fer�in
    {
        //fall til a� b�ta vi� stiga gj�f
        countText.text = "Stig: " + Kassi.count.ToString();
    }
}
