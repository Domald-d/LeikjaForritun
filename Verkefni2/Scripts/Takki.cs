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
        //notum if skilyr�i til a� sko�a ef vi� erum � scene 4 �� birtum vi� lokastig og l�f spilara
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            texti.text = "Lokastig " + PlayerMovment.count.ToString() + " Lifes Left: " + PlayerMovment.lives.ToString();
        }

    }
    //�relt f�ll sem eru ekki notu�
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