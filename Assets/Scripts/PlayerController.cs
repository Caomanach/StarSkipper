using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Flip f_script;

    //public float jumpForce;

    private float moveInput;
    private Rigidbody2D rb;
    public bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public Vector3 currentLocation;

    //private int extraJumps;
    //public int extraJumpsValue;

    private void Start()
    {
        //extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        currentLocation = transform.position;

        if (facingRight == false && moveInput > 0)
        {
            f_script.flip();
        }
        else if(facingRight == true && moveInput < 0)
        {
            f_script.flip();
        }
    }

    private void Update()
    {
        //if(isGrounded == true)
        //{
        //    extraJumps = extraJumpsValue;
        //}

        //if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        //{
        //    rb.velocity = Vector2.up * jumpForce;
        //    extraJumps--;
        //}
        
    }




    public void Jump(Vector2 launchDir, float LaunchForce)
    {
        rb.AddForce(launchDir*LaunchForce);
    }

        //rb.AddForce(launchDir * LaunchForce);

}
