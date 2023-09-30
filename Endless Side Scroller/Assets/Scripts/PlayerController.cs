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

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>(); //call rigid body
        Physics.gravity *= gravityModifier; //call gravity
        playerAnim = GetComponent<Animator>(); // call animation
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) //conditions when player can jump
        {

            PlayerJump(); //call jump method
            isOnGround = false;
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
        }

        //collision with obstacle effects
        else if (collision.gameObject.CompareTag("Obstacle")) {
            gameOver = true;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }
}
