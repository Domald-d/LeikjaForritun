using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Peningar : MonoBehaviour
{
    //private breytur fyrir texta og hljóð
    private TextMeshProUGUI countText;
    private AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        //náum í texta object og hljóð
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
            //skoðum hvort leikmaður snertir pening
            //ef leikmaður snertir pening þá spilum við hljóð og bætum við okkur stigi
            //kalla á coroutine fall svo að hljóð spilast
            audiosource.Play();
            Kassi.count = Kassi.count + 2;
            SetCountText();//kallar í aðferðina
            StartCoroutine(AfterSound());
        }
    }

    //nota ienumerator aðferð sem spilar hljóð og eyðir svo peningum
    IEnumerator AfterSound()
    {
        yield return new WaitForSeconds(audiosource.clip.length);
        Destroy(gameObject);    
        gameObject.SetActive(false);
    }

    public void SetCountText()//hér er aðferðin
    {
        //fall til að bæta við stiga gjöf
        countText.text = "Stig: " + Kassi.count.ToString();
    }
}
