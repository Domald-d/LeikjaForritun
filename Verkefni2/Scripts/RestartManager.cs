using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class RestartManager : MonoBehaviour
{
    //public og private breytur fyrir restart takka og texta og bool breyta fyrir ef leikur er active
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    private PlayerMovment pMove;
    public bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //fall til a� byrja leik
    public void startGame()
    {
        isGameActive = true;
    }

    //fall fyrir leik loki� og birtum restart takka og leik loki� texta
    public void gameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    // fall til a� restarta leik og stillum stig sem 0 og l�f spilara sem 3
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        PlayerMovment.count = 0;
        PlayerMovment.lives = 3;
    }
}
