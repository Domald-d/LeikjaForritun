using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vatn : MonoBehaviour
{
    //void fall fyrir trigger þegar spilari snertir vatn
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //við skoðum hvort tag er jafnt og player og ef svo þá sendum við spilara á drukknað senu
            Debug.Log("Drukknaði");
            SceneManager.LoadScene(4);
        }
    }
}
