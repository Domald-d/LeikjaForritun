using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
//private og public breytur fyrir erfiðleika stig á tökkum
    private Button button;
    private GameManager gameManager;
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
    //náum í takka component
    // tengjum gamemanager við skrá
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(setDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setDifficulty()
    {
    //void fall til að setja erfiðleika stig leiks
        gameManager.StartGame(difficulty);
    }
}
