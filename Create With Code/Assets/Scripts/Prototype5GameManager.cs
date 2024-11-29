using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prototype5GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject endScreen;
    private int score;
    public bool isGameActive = false;
    private float spawnRate = 1.5f;



    public void StartBtn(int difficulty)
    {
        isGameActive = true;
        spawnRate /= difficulty;
        startScreen.SetActive(false);
        scoreText.gameObject.SetActive(true);
        score = 0;

        StartCoroutine(SpawnTarget());
    }


    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = $"Score: {score}";
    }

    public void GameOver()
    {
        isGameActive = false;
        endScreen.SetActive(true);

    }

    public void RestartBtn()
    {
        //StartBtn();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        endScreen.SetActive(false);
    }


    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
