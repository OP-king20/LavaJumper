using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float jumpForce = 5f;
    [SerializeField]
    float startDashTime;

    public Rigidbody2D rb;

    

    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    public GameObject player;

    public float dashDistance = 10f;
    bool isDashing;
    float doubleTapTime;
    KeyCode lastKeyCode;
    
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); //this is for animations
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        Move();
        Jump();
        CheckIfGrounded();

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A)
            {
                StartCoroutine(Dash(-1f));
            }

            else
            {
                doubleTapTime = Time.time + 0.5f;
            }

            lastKeyCode = KeyCode.A;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.D)
            {
                StartCoroutine(Dash(1f));
            }

            else
            {
                doubleTapTime = Time.time + 0.2f;
            }

            lastKeyCode = KeyCode.D;
        }

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
        ;
        if (!isDashing)
        {
            float velocity = inputX * speed;
            rb.velocity = new Vector2(velocity, rb.velocity.y);
        }
        

        if (inputX == 0) //this is for animations
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

    }
   

    // Update is called once per frame

   
    private void Jump()
    {
        //Must be reworked
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            
            anim.SetTrigger("TakeOff"); //this is for animations

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //float inputY = Input.GetAxisRaw("Vertical");
            //float jump = inputY * jumpForce;
            //rb.velocity = new Vector2(rb.velocity.x, jump);
        }
        
        if (isGrounded == true) //this is for animations
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

    IEnumerator Dash (float direction)
    {
        isDashing = true;
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        
        rb.gravityScale = 0;
        yield return new WaitForSeconds(0.2f);
        isDashing = false;
        rb.gravityScale = 3;


    }

}

