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

    bool isWall;
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
        Move();
        Jump();
        CheckIfGrounded();
        Debug.Log(isWall);
    }

    private void Move()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        if ((inputX == -1) && (isWall == true))
        {
            player.transform.rotation = Quaternion.Euler(0, -180, 0);
        }

        else if ((inputX == -1) && (isWall == true))
        {
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        float velocity = inputX * speed;
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("Collision!");
            isWall = true;
            Debug.Log(isWall);
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

