using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] private float speed;
    [SerializeField] private GameObject focalPoint;
    [SerializeField] private GameObject powerupIndicator;
    [SerializeField] private bool hasPowerup;
    [SerializeField] private float powerupStrength = 15.0f;
    [SerializeField] private float powerupDuration = 7;
    private Prototype4GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
       // audioSource = GetComponent<AudioSource>();
        focalPoint = GameObject.Find("FocalPoint");
        gameManager = GameObject.Find("GameManager").GetComponent<Prototype4GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * verticalInput * speed);
        powerupIndicator.transform.position = transform.position;
        if(transform.position.y < -2)
        {
            gameManager.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(CountDown());
            powerupIndicator.SetActive(true);
           // audioSource.PlayOneShot(powerupSound, 0.7f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayDir = collision.gameObject.transform.position - transform.position;

            Debug.Log("Power up and enemy contact");
            enemyRb.AddForce(awayDir * powerupStrength, ForceMode.Impulse);
           // audioSource.PlayOneShot(enemyAudio, 0.7f);
        }
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(powerupDuration);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

}
