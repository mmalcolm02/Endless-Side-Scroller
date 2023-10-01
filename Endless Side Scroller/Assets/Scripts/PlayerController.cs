using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>(); //call rigid body
        Physics.gravity *= gravityModifier; //call gravity
        playerAnim = GetComponent<Animator>(); // call animation
        playerAudio = GetComponent<AudioSource>(); // call sound
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) //conditions when player can jump
        {
            dirtParticle.Stop();
            PlayerJump(); //call jump method
            isOnGround = false;
            playerAudio.PlayOneShot(jumpSound, 1);
        }

          
    }

    void PlayerJump() //jump method
    {
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");

        }
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) //effect of collision with ground
        {
            isOnGround = true;
            dirtParticle.Play();
        }

        //collision with obstacle effects
        else if (collision.gameObject.CompareTag("Obstacle")) {
            dirtParticle.Stop();
            explosionParticle.Play();
            gameOver = true;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(crashSound, 1);
        }
    }
}
