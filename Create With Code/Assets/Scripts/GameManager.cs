using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> animalPrefabs;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject endScreen;
    private int score;
    public bool isGameActive = false;
    private float xRange = 22;
    private float zRange = 20;
    public float spawnRate = 2.5f;
    
    // Start is called before the first frame update
    public virtual void StartBtn()
    {
        isGameActive = true;
        startScreen.SetActive(false);
        scoreText.gameObject.SetActive(true);
        score = 0;
        UpdateScore(0);
        StartCoroutine(SpawnAnimals());
    }

    IEnumerator SpawnAnimals()
    {
        while (isGameActive)
        {yield return new WaitForSeconds(spawnRate);
        GameObject selectedAnimal = animalPrefabs[GenerateRandomIndex()];       
        Instantiate(selectedAnimal, GenerateSpawnPosition() , selectedAnimal.transform.rotation);

        }
        
    }

    // Update is called once per frame
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = $"Score: {score}";
    }

    private int GenerateRandomIndex()
    {
        int index = Random.Range(0, animalPrefabs.Count);
        return index;
    }

    private Vector3 GenerateSpawnPosition()
    {
        float xLocation = Random.Range(-xRange, xRange + 1);
        Vector3 spawnPos = new Vector3(xLocation, 0, zRange);
        return spawnPos;
    }

    public void GameOver()
    {
        isGameActive=false;
        endScreen.SetActive(true);
    }

    public void RestartBtn()
    {
        StartBtn();
        endScreen.SetActive(false);
    }
}
