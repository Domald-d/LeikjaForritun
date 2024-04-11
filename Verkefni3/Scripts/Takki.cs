using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Takki : MonoBehaviour
{
    //public breyta fyrir texta
    public TextMeshProUGUI texti;


    public void Start()
    {
        //notum if skilyrði til að skoða ef við erum á scene 3 þá birtum við lokastig og líf spilara
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            texti.text = "Lokastig: " + Kassi.count.ToString() + " Lifes Left: " + Ovinur.health.ToString();
        }

    }
    //úrelt fallt ekki notað
    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    //fall til að byrja leik þegar smellt er á takka
    public void Byrja()
    {
        SceneManager.LoadScene(1);
    }
    //fall til að enda leik og fara á byrjuna senu þegar smellt er á takka
    public void Endir()
    {
        SceneManager.LoadScene(0);
       
    }
    
}
