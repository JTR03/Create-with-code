using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float upperBound = 26f;
    private float lowerBound = -22;
    private GameManager manager;

    private void Start()
    {
        manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > upperBound)
        {
            Destroy(gameObject);
        }
        if(transform.position.z < lowerBound)
        {
            Destroy(gameObject);
            manager.GameOver();
        }
    }
}
