using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float moveSpeed = 30;
    private PrototypeGameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<PrototypeGameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        
    }
}
