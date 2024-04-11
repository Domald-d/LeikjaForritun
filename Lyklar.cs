using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Lyklar : MonoBehaviour
{
    //breytur fyrir texta og hljóð
    private TextMeshProUGUI texti;
    private AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        //náum í texta objectið og audio source
        texti = GameObject.Find("Text2").GetComponent<TextMeshProUGUI>();
        audiosource = GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //trigger fyrir lykil sem gefur líf og spilum hljóð þegar leikmaður snertir lykil
        //nota StartCoroutine aðferð svo að hljóð spilast áður en við eyðum hlutnum
        if (other.CompareTag("Player"))
        {
            Debug.Log("Leikmaður snertir lykil");
            if (audiosource != null && audiosource.clip != null) { audiosource.Play(); }
            Ovinur.health += 8;
            SetHealthText();
            StartCoroutine(AfterSound());
        }
    }

    public void SetHealthText()
    {
        //aðferð til að bæta lífi þegar við snertum lykil
        texti.text = "Líf: " + Ovinur.health.ToString();
    }

    //aðferð sem ég kalla á svo að hljóð spilist fyrst og svo eyðum við lykla objecti
    IEnumerator AfterSound()
    {
        yield return new WaitForSeconds(audiosource.clip.length);
        gameObject.SetActive(false);
    }
}
