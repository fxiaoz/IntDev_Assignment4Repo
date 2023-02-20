using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalMove;
    public float speed = 5f;

    Rigidbody2D myBody;

    bool grounded = false;
    public float castDist = 1f;

    public float jumpLimit = 2f;
    public float gravityScale = 5f; //rising
    public float gravityFall = 40f; //falling

    bool jump = false;

    //Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        //myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }

        //if (horizontalMove > 0.2f || horizontalMove < -0.2f)
        //{
        //    myAnim.SetBool("walking", true);
        //}

        //else
        //{
        //    myAnim.SetBool("walking", false);
        //}
    }

    void FixedUpdate()
    {
        float moveSpeed = horizontalMove * speed;

        if (jump)
        {
            myBody.AddForce(Vector2.up * jumpLimit, ForceMode2D.Impulse);
            jump = false;
        }

        if (myBody.velocity.y > 0)
        {
            myBody.gravityScale = gravityScale;
        }

        else if (myBody.velocity.y < 0)
        {
            myBody.gravityScale = gravityFall;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, castDist);
        Debug.DrawRay(transform.position, Vector2.down, Color.red);

        //if (hit.collider != null && hit.transform.name == "Ground")
        //{
        //    grounded = true;
        //}

        //else
        //{
        //    grounded = false;
        //}

        myBody.velocity = new Vector3(moveSpeed, myBody.velocity.y, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}
