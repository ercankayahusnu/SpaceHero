using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public int spawnCount;
    public float spawnWait;
    public float startSpawn;
    public float waveWait;

    public Text scoreText;
    public int score;
    public Text gameOverText;
    public Text restartText;


    private bool gameOver;
    private bool restart;

    void Update()
    {
        
        if (restart == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    IEnumerator SpawnValues()
    {
        while (true)
        {
            yield return new WaitForSeconds(startSpawn);

            for(int i = 0; i<spawnCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(1, 6), 0, 13);
                Quaternion spawnRotation = Quaternion.identity;
          
                Instantiate(hazard, spawnPosition, spawnRotation);
                //Coroutine
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if(gameOver == true)
            {
                restartText.text = " Press 'R' for Restart ";
                restart = true;
                break;
            }
        }
    }

    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score : " + score;
    }
    public void GameOver()
    {
        gameOverText.text = " Game Over ";
        gameOver = true;

    }

    void Start()
      
    {
        gameOverText.text = " ";
        restartText.text = " ";
        gameOver = false;
        restart = false;

        StartCoroutine(SpawnValues());
        
    }
    
}
