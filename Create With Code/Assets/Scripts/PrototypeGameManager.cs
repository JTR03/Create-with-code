using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrototypeGameManager : MonoBehaviour
{
    [SerializeField] private GameObject obsticlePrefab;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject endScreen;
    private int score;
    public bool isGameActive = false;
    private float xLocation = 40;
    private float yLocation = 0f;
    private float spawnRate = 1.5f;
    private Animator playerAnim;

    private void Awake()
    {
        playerAnim = GameObject.Find("Player").GetComponent<Animator>();
    }
    public virtual void StartBtn()
    {
        isGameActive = true;
        startScreen.SetActive(false);
        scoreText.gameObject.SetActive(true);
        playerAnim.SetFloat("Speed_f", 1);
        playerAnim.SetBool("Death_b", false);
        score = 0;
        
        StartCoroutine(SpawnObsticle());
    }



    // Update is called once per frame
    public void UpdateScore(Rigidbody rb)
    {
        score += Mathf.RoundToInt(rb.velocity.magnitude);
        scoreText.text = $"Score: {score}";
    }

    private Vector3 GenerateSpawnPosition()
    {
        float zLocation = Random.Range(12, 41);
        Vector3 spawnPos = new Vector3(xLocation, yLocation, zLocation);
        return spawnPos;
    }

    public void GameOver()
    {
        isGameActive = false;
        endScreen.SetActive(true);
        playerAnim.SetFloat("Speed_f", 0.01f);
       
    }

    public void RestartBtn()
    {
        StartBtn();
        endScreen.SetActive(false);
    }
  

    IEnumerator SpawnObsticle()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(obsticlePrefab, GenerateSpawnPosition(), obsticlePrefab.transform.rotation);
        }
    }
}
