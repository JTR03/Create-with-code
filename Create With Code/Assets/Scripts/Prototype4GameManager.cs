using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Prototype4GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject powerupPrefab;
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject endScreen;
    private int score;
    public bool isGameActive = false;
    private float xLocation = 9;
    private float zLocation = 9;
    private float yLocation = 0f;
    public int enemyCount;
    private int powerupCount;
    private int waveNum;
   

  
    public virtual void StartBtn()
    {
        isGameActive = true;
        startScreen.SetActive(false);
        scoreText.gameObject.SetActive(true);
        player.transform.position = Vector3.zero;
        waveNum = 1;
        score = 0;
        SpawnEnemy(waveNum);
    }

    public void UpdateScore(Rigidbody rb)
    {
        score += Mathf.RoundToInt(rb.velocity.magnitude);
        scoreText.text = $"Score: {score}";
    }

    private Vector3 GenerateSpawnPosition()
    {
        float zRange = Random.Range(-zLocation, zLocation);
        float xRange = Random.Range(-xLocation, xLocation);
        Vector3 spawnPos = new Vector3(xRange, yLocation, zRange);
        return spawnPos;
    }

    public void GameOver()
    {
        isGameActive = false;

        GameObject[] powerups = GameObject.FindGameObjectsWithTag("Powerup");
        foreach (var item in powerups)
        {
            Destroy(item);
        }
        endScreen.SetActive(true);


    }

    public void RestartBtn()
    {
        StartBtn();
        endScreen.SetActive(false);
    }


    public void SpawnEnemy(int length)
    {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        powerupCount++;
            for (int i = 0; i < length; i++)
            {
                Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);    
            }
    }

    private void Update()
    {
        enemyCount = FindObjectsOfType<FollowPlayer>().Length;
        if(enemyCount == 0 && isGameActive)
        {

            SpawnEnemy(waveNum);
            waveNum++;
        }
    }
}
