using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Takki : MonoBehaviour
{
    //public breyta fyrir texta
    public TextMeshProUGUI texti;

    public void Start()
    {
        //notum if skilyrði til að skoða ef við erum á scene 4 þá birtum við lokastig og líf spilara
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            texti.text = "Lokastig " + PlayerMovment.count.ToString() + " Lifes Left: " + PlayerMovment.lives.ToString();
        }

    }
    //úrelt föll sem eru ekki notuð
    public void Byrja()
    {
        SceneManager.LoadScene(1);
    }
    public void Endir()
    {
        SceneManager.LoadScene(0);
        PlayerMovment.count = 0;
    }

}