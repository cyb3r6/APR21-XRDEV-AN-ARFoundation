using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int lives = 10;

    public TMP_Text livesText;

    public Canvas gameOverCanvas;

    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        gameOverCanvas.gameObject.SetActive(false);
        livesText.text = lives.ToString();
    }

    public void DecreaseLives()
    {
        // lives = lives -1
        lives--;

        livesText.text = lives.ToString();

        if(lives <= 0)
        {
            // gameover
            gameOverCanvas.gameObject.SetActive(true);

        }
    }

    public GameObject RobotPlayer()
    {
        RobotTouchController robotPlayer = FindObjectOfType<RobotTouchController>();
        if (robotPlayer)
        {
            return robotPlayer.gameObject;
        }

        return default;
    }


}
