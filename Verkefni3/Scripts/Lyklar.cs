using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Lyklar : MonoBehaviour
{
    //breytur fyrir texta og hlj��
    private TextMeshProUGUI texti;
    private AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        //n�um � texta objecti� og audio source
        texti = GameObject.Find("Text2").GetComponent<TextMeshProUGUI>();
        audiosource = GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        //trigger fyrir lykil sem gefur l�f og spilum hlj�� �egar leikma�ur snertir lykil
        //nota StartCoroutine a�fer� svo a� hlj�� spilast ��ur en vi� ey�um hlutnum
        if (other.CompareTag("Player"))
        {
            Debug.Log("Leikma�ur snertir lykil");
            if (audiosource != null && audiosource.clip != null) { audiosource.Play(); }
            Ovinur.health += 8;
            SetHealthText();
            StartCoroutine(AfterSound());
        }
    }

    public void SetHealthText()
    {
        //a�fer� til a� b�ta l�fi �egar vi� snertum lykil
        texti.text = "L�f: " + Ovinur.health.ToString();
    }

    //a�fer� sem �g kalla � svo a� hlj�� spilist fyrst og svo ey�um vi� lykla objecti
    IEnumerator AfterSound()
    {
        yield return new WaitForSeconds(audiosource.clip.length);
        gameObject.SetActive(false);
    }
}
