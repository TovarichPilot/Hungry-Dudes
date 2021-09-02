using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollisions : MonoBehaviour
{
    private float topBoundary = 32.0f;
    private float lowBoundary = -10.0f;
    private float RightAndLeftXBoundary = 26.5f;
    private bool GameOver = true;

    public int eatingSize = 3;
    public int currentEatingSize;
    public HealthBarScript healthBar;

    static public int maxScoreValue = 0;
    private void Start()
    {
        currentEatingSize = 0;
        healthBar.SetMaxHealth(eatingSize, 0);

    }
    // Update is called once per frame
    void Update()
    {
        //if an object goes past the player's view in the game, remove this object
        if (transform.position.z > topBoundary)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowBoundary || (transform.position.x > RightAndLeftXBoundary || transform.position.x < -RightAndLeftXBoundary))
        {
            Destroy(gameObject);

            if (GameManager.currentLives > 0)
            {
                GameManager.currentLives--;

                if (GameManager.currentLives < 1)
                {
                    Debug.Log("Game Over");
                    GameOver = false;
                    GameManager.currentLives = 3;
                    if (GameManager.currentScore > maxScoreValue)
                    {
                        maxScoreValue = GameManager.currentScore;

                    }               
                    GameManager.currentScore = 0;
                }
            }  

            Debug.Log("Lives = " + GameManager.currentLives);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((gameObject.CompareTag("Animal")) && (other.gameObject.CompareTag("Food")))
        {
            if (eatingSize > currentEatingSize)
            {
                currentEatingSize++;
                healthBar.SetHealth(currentEatingSize);
                Destroy(other.gameObject);
            }

            if (eatingSize == currentEatingSize)
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
                GameManager.currentScore++;
                Debug.Log("Score = " + GameManager.currentScore);

            }  
        }

        if ((gameObject.CompareTag("Animal")) && (other.gameObject.CompareTag("Player")))
        {
            if (GameManager.currentLives > 0)
            {
                GameManager.currentLives--;

            }
            Debug.Log("Lives = " + GameManager.currentLives);
            Destroy(gameObject);

            if (GameManager.currentLives < 1 && GameOver)
            {
                
                Debug.Log("Game Over");
                GameOver = false;
                GameManager.currentLives = 3;
                if (GameManager.currentScore > maxScoreValue)
                {
                    maxScoreValue = GameManager.currentScore;

                }
                GameManager.currentScore = 0;
            }
        }
    }
}