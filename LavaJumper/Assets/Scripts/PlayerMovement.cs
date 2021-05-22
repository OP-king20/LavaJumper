using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float jumpForce = 5f;

    public Rigidbody2D rb;
    
    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    public GameObject player;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Move()
    {
        float inputX = Input.GetAxisRaw("Horizontal");

        if (inputX == -1)
        {
            player.transform.rotation = Quaternion.Euler(0, -180, 0);
        }

        else if (inputX == 1)
        {
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        float velocity = inputX * speed;
        rb.velocity = new Vector2(velocity, rb.velocity.y);

        if (inputX == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
    }

    // Update is called once per frame

    void Update()
    {
        Move();
        Jump();
        CheckIfGrounded();

        //animator.SetFloat("Speed", Mathf.Abs("Horizontal"));

    }

    private void Jump()
    {
        //Must be reworked
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            //takeoff animation
            anim.SetTrigger("TakeOff");

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //float inputY = Input.GetAxisRaw("Vertical");
            //float jump = inputY * jumpForce;
            //rb.velocity = new Vector2(rb.velocity.x, jump);
        }

        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }

    }

    void CheckIfGrounded()
    {
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        if (collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }



}

