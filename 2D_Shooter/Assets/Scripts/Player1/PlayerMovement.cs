using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D body;

    public float accelerationPower;
    public float jumpPower;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObjects;
    public float checkRadius;
    public int maxJumpCount;

    float moveDirection;

    private bool facingRight = true;
    private bool isJumping = false;
    private bool isGrounded;
    private int jumpCount;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    // function better for input and updating stuff on screen
    void Update()
    {
        // get inputs
        ProcessPlayerInputs();

        // animate
        AnimatePlayer();

    }

    // function better for player movement and game physics
    void FixedUpdate()
    {
        // check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);

        // move
        PlayerMove();
    }

    void PlayerMove()
    {
        // A & D movement || left & right arrow keys
        body.velocity = new Vector2(moveDirection * accelerationPower, body.velocity.y);

        if (isJumping)
        {
            body.AddForce(new Vector2(0f, jumpPower), ForceMode2D.Impulse);
        }
        isJumping = false;
    }

    void AnimatePlayer()
    {
        // animate turn around
        if (moveDirection > 0 && !facingRight)
        {
            flipCharacter();
        }
        else if (moveDirection < 0 && facingRight)
        {
            flipCharacter();
        }
    }

    void ProcessPlayerInputs()
    {
        // get input
        moveDirection = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
    }


    private void flipCharacter() 
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }


}
