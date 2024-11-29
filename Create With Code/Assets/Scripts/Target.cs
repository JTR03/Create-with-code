using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private Prototype5GameManager gameManager;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -4;
    [SerializeField] private int pointValue;
    [SerializeField] private ParticleSystem exposionParticle;
    [SerializeField] private AudioClip audioClip;
    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<Prototype5GameManager>();
        targetRb = GetComponent<Rigidbody>();
        source = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        targetRb.AddForce(RandomForce(),ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(),ForceMode.Impulse);
        transform.position = RandomSpawnPos();
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(exposionParticle, transform.position, exposionParticle.transform.rotation);
        gameManager.UpdateScore(pointValue);
        source.PlayOneShot(audioClip, 1);
    }

    private void OnTriggerEnter(Collider other)
    {

        Destroy(gameObject );
        if (!gameObject.CompareTag("Enemy"))
        {
            gameManager.GameOver();
        }
        
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomSpawnPos()
    {
        float x = Random.Range(-xRange, xRange);
        return new Vector3(x, ySpawnPos);
    }
}
