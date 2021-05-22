using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float jumpForce = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    bool isGrounded = false;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    // Update is called once per frame

    void Update()
    {
        
        Jump();
        CheckIfGrounded();

        //animator.SetFloat("Speed", Mathf.Abs(Horizontal));

    }
   

    public void MoveLeft()
    {
            Debug.Log(rb.position);
            //layer.transform.rotation = Quaternion.Euler(0, -180, 0);
            float velocity = -1 * speed;
            rb.velocity = new Vector2(velocity, rb.velocity.y);
    }

    public void MoveRight()
    {
        
        Debug.Log(rb.position);
        //layer.transform.rotation = Quaternion.Euler(0, -180, 0);
        float velocity = 1 * speed;
        rb.velocity = new Vector2(velocity, rb.velocity.y);
    }

    private void Jump()
    {
        //Must be reworked
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {   
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //float inputY = Input.GetAxisRaw("Vertical");
            //float jump = inputY * jumpForce;
            //rb.velocity = new Vector2(rb.velocity.x, jump);
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

