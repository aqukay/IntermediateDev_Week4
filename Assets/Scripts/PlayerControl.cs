using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //movement variables
    float horizontalMove;
    public float speed = 20f;

    Rigidbody2D myBody;

    //jump variables
    //check if allowed to jump
    bool grounded = false;
    public float castDist = 1f;
    
    //jump physics
    public float jumpPower = 30f;
    public float gravityScale = 1f;
    public float gravityFall = 15f;

    bool jump = false;
    private bool doubleJump;

    //animation
    Animator myAnim;
    SpriteRenderer myRend;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && grounded)
        {
            myAnim.SetBool("jumping", true);
            jump = true;
        }
        if (Input.GetButtonDown("Jump") && !grounded)
        {
            myAnim.SetBool("jumping", true);
            doubleJump = true;
        }

        //running animation
        if(horizontalMove > 0.2f)
        {
            myAnim.SetBool("running", true);
            myRend.flipX = false;
        }

        else if(horizontalMove < -0.2f)
        {
            myAnim.SetBool("running", true);
            myRend.flipX = true;
        }

        else
        {
            myAnim.SetBool("running", false);
        }
    }

    void FixedUpdate()
    {
        float moveSpeed = horizontalMove * speed;

        if(jump)
        {
            myBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

            doubleJump = true;
            jump = false;
        }
        else if (doubleJump)
        {
            myBody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

            doubleJump = false;
        }

        if(myBody.velocity.y > 0)
        {
            myBody.gravityScale = gravityScale;
        }
        else if (myBody.velocity.y < 0)
        {
            myBody.gravityScale = gravityFall;
        }

        //raycast check if on ground
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, castDist);
        Debug.DrawRay(transform.position, Vector2.down * castDist, Color.red);

        if(hit.collider != null && hit.transform.name == "Ground")
        {
            myAnim.SetBool("jumping", false);
            grounded = true;
        }
        else
        {
            grounded = false;
        }

        myBody.velocity = new Vector3(moveSpeed, myBody.velocity.y, 0f);
    }
}
