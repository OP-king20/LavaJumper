using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{



    [SerializeField]
    float speed = 5f, jumpForce = 5f, dashCooldown, dashDistance = 10f;
  
    public Rigidbody2D rb;
    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    public GameObject player;
    
    //Player needs to be facing right when instantiated
    //-1 = left and 1 = right
    private float direction = 1;
    private float dashTime;
    private int jumpCount;
    private float gravity;

    bool isDashing;
    
    private Animator anim;
    
    //Constants
    private float constantGravityTimer = 0.2f;

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>(); //this is for animations
        rb = GetComponent<Rigidbody2D>();
        gravity = rb.gravityScale;
        
    }

    void Update()
    {
        
        Move();
        Jump();
        CheckIfGrounded();
        Dashes();

    }

    private void Move()
    {
        float inputX = Input.GetAxisRaw("Horizontal");

        if (inputX == -1)
        {
            player.transform.rotation = Quaternion.Euler(0, -180, 0);
            direction = -1;
        }

        else if (inputX == 1)
        {
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
            direction = 1;
        }
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
        if (Input.GetKeyDown(KeyCode.W) && (isGrounded || jumpCount < 1))
        {

            anim.SetTrigger("TakeOff"); //this is for animations

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            ++jumpCount;
            //float inputY = Input.GetAxisRaw("Vertical");
            //float jump = inputY * jumpForce;
            //rb.velocity = new Vector2(rb.velocity.x, jump);

        }


        if (isGrounded == true) //this is for animations
        {
            anim.SetBool("isJumping", false);
            jumpCount = 0;
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
        
        if (rb.velocity.y <-0)
        {
            anim.SetTrigger("Fall");
        }
        else
        {
            anim.SetBool("isFalling", false);
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
        rb.velocity = new Vector2(0, rb.velocity.y);
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        
        rb.gravityScale = 0;
        //Gravity timer decides för how long player will float;
        yield return new WaitForSeconds(constantGravityTimer);
        isDashing = false;
        rb.gravityScale = gravity;

    }

    void Dashes()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time > dashTime)
        {
            anim.SetTrigger("DashSide");
            dashTime = Time.time + dashCooldown;
            StartCoroutine(Dash(direction));
        }
        else
        {
            anim.SetBool("isDashingSide", false);
        }

    }
}

