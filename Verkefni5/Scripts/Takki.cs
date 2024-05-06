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
        //notum if skilyr�i til a� sko�a ef vi� erum � scene 4 �� birtum vi� lokastigspilara
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            texti.text = "Lokastig: " + EnemyController.stig.ToString();
        }

    }
    //�relt fallt ekki nota�
    private void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    //fall til a� byrja leik �egar smellt er � takka
    public void Byrja()
    {
        SceneManager.LoadScene(1);
        EnemyController.stig = 0;
    }
    //fall til a� enda leik og fara � byrjuna senu �egar smellt er � takka
    public void Endir()
    {
        SceneManager.LoadScene(0);

    }

}