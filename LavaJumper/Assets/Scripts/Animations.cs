using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{

    private Rigidbody2D rb;

    public Transform groundPos;
    private bool isGrounded;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundPos.position, checkRadius, whatIsGround);

        float moveInput = Input.GetAxisRaw("Horizontal");


        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
