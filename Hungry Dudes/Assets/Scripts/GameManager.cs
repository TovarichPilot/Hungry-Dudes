using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public int currentScore, currentLives = 3;

    public Text score;
    public Text highScore;
    public Text lives;

    private void Update()
    {
        score.text = "Score: " + currentScore;
        lives.text = "Lives: " + currentLives;
        highScore.text = "High Score: " + DetectCollisions.maxScoreValue;
    }

   
}
