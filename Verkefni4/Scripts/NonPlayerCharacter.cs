using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPlayerCharacter : MonoBehaviour
{
    //public breytur fyrir npc kall
    public float displayTime = 4.0f;
    public GameObject dialogBox;
    float timerDisplay;
    // Start is called before the first frame update
    void Start()
    {
        //setjum dialog box sem false
        //svo að box komi þegar notandi ýtir á x
        dialogBox.SetActive(false);
        timerDisplay = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //if skilyrði fyrir tíma á boxi svo að það sé ekki active alltaf
        if (timerDisplay >= 0)
        {
            timerDisplay -= Time.deltaTime;
            if (timerDisplay < 0)
            {
                dialogBox.SetActive(false);
            }
        }
    }

    //fall fyrir dialog boxið
    //setur dialog boxið active
    public void DisplayDialog()
    {
        timerDisplay = displayTime;
        dialogBox.SetActive(true);
    }
}
