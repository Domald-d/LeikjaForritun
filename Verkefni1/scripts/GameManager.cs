using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
//public og private breytur fyrir textmesh,stig,bool breytur og fleira
    public TextMeshProUGUI scoreText;
    private int score;
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    public TextMeshProUGUI gameOverText;
    public Button startButton;
    public bool isGameActive;
    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
    //notum IEnumerator aðferð til að spawna hluti
        while(isGameActive)
        {
        //while lykkja sem keyrir og spawnar hluti meðan leikur er í gangi
        //notum yield aðferð og instantiate
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
    //void fall til að uppfæra stig
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
    //void fall fyrir leik lokið og keyrir restart takka og leik lokið texta
        startButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
    // fall til að restarta leik og notum scenemanager til að ná í active scene sem við erum í
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
    //void fall sem byrjar leik og setur hversu hratt hlutir spawna þegar ákveðið erfiðleika stig er sett inn
        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);

    }
}
