using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    [SerializeField] private int value;
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.isGameActive)
        {
Destroy(other.gameObject);
        Destroy(gameObject);
        gameManager.UpdateScore(value);
        }
        
    }
}
