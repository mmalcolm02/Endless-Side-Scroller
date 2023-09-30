using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 15;
    private PlayerController playerControllerScript;
    private Animator obstacleAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        obstacleAnim = GetComponent<Animator>(); //I chose to have a character as obstacle thus had extra script

    }

    // Update is called once per frame
    void Update()
    {
        if (CompareTag("Obstacle") && playerControllerScript.gameOver == false) //movement forwards of obstacle
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        else if (CompareTag("Obstacle") && playerControllerScript.gameOver == true) //death animation of obstacle
        {
            obstacleAnim.SetBool("Death_b", true);
            obstacleAnim.SetInteger("DeathType_int", 1);
        }

        else if (playerControllerScript.gameOver == false) //movement left of background
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}
