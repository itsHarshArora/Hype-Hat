using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    private Rigidbody rb;

    public Transform groundPos;
    public static bool isGrounded;
    public float checkRadius;

    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    private bool doubleJump;
    private Animator anim;

    public float speedIncrement = 0.05f;
    public float maximumSpeed = 15f;

    public GameObject jumpSfx;
    public GameObject doubleJumpSfx;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundPos.position, checkRadius, whatIsGround, QueryTriggerInteraction.Ignore);

        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void Update()
    {
        speed += speedIncrement * Time.deltaTime;
        if (speed >= maximumSpeed)
        {
            speed = maximumSpeed;
        }

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            anim.SetTrigger("singleJump");
            rb.velocity = Vector2.up * jumpForce;
            Instantiate(jumpSfx, gameObject.transform.position, Quaternion.identity);
        }

        if (isGrounded == true)
        {
            doubleJump = false;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        if (isGrounded == false && doubleJump == false && Input.GetKeyDown(KeyCode.Space) && CoinTextScript.coinAmount >= 5)
        {
            anim.SetTrigger("doubleJump");
            isJumping = true;
            doubleJump = true;
            isJumping = true;
            jumpTimeCounter = jumpTime;
            CoinTextScript.coinAmount -= 5;
            rb.velocity = Vector2.up * jumpForce;
            Instantiate(doubleJumpSfx, gameObject.transform.position, Quaternion.identity);
        }
    }
}
