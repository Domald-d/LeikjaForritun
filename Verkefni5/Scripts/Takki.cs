using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Takki : MonoBehaviour
{
    public TextMeshProUGUI texti;
    public void Start()
    {
        //notum if skilyrði til að skoða ef við erum á scene 4 þá birtum við lokastigspilara
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            texti.text = "Lokastig: " + EnemyController.stig.ToString();
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
        EnemyController.stig = 0;
    }
    //fall til að enda leik og fara á byrjuna senu þegar smellt er á takka
    public void Endir()
    {
        SceneManager.LoadScene(0);

    }

}