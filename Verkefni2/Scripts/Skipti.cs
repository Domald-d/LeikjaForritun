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
    //fall sem l�tur spilara b��a svokalla� cool down
    IEnumerator Bida()
    {
        yield return new WaitForSeconds(3);
        Endurr�sa();
    }
    // sendum spilara � n�sta level �egar hann snertir trigger
    public void Endurr�sa()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//n�sta sena
    }

}