using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skipti : MonoBehaviour
{
    void Start()
    {
        Debug.Log("byrja");
    }
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        StartCoroutine(Bida());
    }
    //fall sem lætur spilara bíða svokallað cool down
    IEnumerator Bida()
    {
        yield return new WaitForSeconds(3);
        Endurræsa();
    }
    // sendum spilara á næsta level þegar hann snertir trigger
    public void Endurræsa()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//næsta sena
    }

}