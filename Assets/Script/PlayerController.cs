using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject groundchecker;
    public LayerMask whatIsGround;

    float maxSpeed = 5.0f;
    bool isOnGround = false;
    bool doubleJump = true;

    //Create a reference to the Rigidbody2D so we can manipulate it
    Rigidbody2D playerObject;
    private object groundChecker;

    // Start is called before the first frame update
    void Start()
    {
        //Find the Rigidbody2D component that is attached to the same object as this script
        playerObject = GetComponent<Rigidbody2D>();
    }

    public AudioClip jump;
    public AudioClip backgroundMusic;

    public AudioSource sfxPlayer;
    public AudioSource musciPlayer;
  
// Update is called once per frame
void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            maxSpeed = 10.0f;
        }
        else
        {
            maxSpeed = 5.0f;
        }

       
        //Create a 'float' that will be equal to the players horizontal input
        //float movementValueX = Input.GetAxis("Horizontal");

        //Set movementValueX to 1.0f, so that we always run forward and no longer care about player input
        float movementValueX = 1.0f;

        //Change the X velocity of the Rigidbody2D to be equal to the movement value
        playerObject.velocity = new Vector2 (movementValueX *maxSpeed, playerObject.velocity.y);

        //Check to see if the ground check object is touching the ground
        isOnGround = Physics2D.OverlapCircle(groundchecker.transform.position, 0f, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            playerObject.AddForce(new Vector2(0.0f, 300.0f));
        }
        else if (Input.GetKeyDown(KeyCode.Space) && doubleJump)
        {
            playerObject.AddForce(new Vector2(0.0f, 300.0f));
            doubleJump = false;
        }

        if (isOnGround)
        {
            doubleJump = true;
        }

  
    }
}