using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperController : MonoBehaviour
{
    private Rigidbody playerRb;
    private bool isOnGround = true;
    [SerializeField] private float jumpForce = 250;
    [SerializeField] private float gravityMultiplier = 1.5f;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    private AudioSource audioSource;
    private PrototypeGameManager gameManager;
    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
       playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityMultiplier;
        gameManager = GameObject.Find("GameManager").GetComponent<PrototypeGameManager>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && gameManager.isGameActive)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetBool("Jump_b",true);
            dirtParticle.Stop();
            audioSource.PlayOneShot(jumpSound, 1.0f);
        }
        gameManager.UpdateScore(playerRb);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround=true;
            playerAnim.SetBool("Jump_b", false);
            dirtParticle.Play();
        }
        if (collision.gameObject.CompareTag("Obsticle"))
        {
            gameManager.GameOver();
            playerAnim.SetBool("Death_b", true);
            explosionParticle.Play();
            dirtParticle.Stop();
            audioSource.PlayOneShot(crashSound,1.0f);
        }
        
    }
}
