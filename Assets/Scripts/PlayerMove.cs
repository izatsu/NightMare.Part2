using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    private float horizontal;
    private float speed = 12f;
    private float jumpingPower = 24f;
    private bool isFacingRight = true;

    public Animator anim;
    private bool doubleJump = true;
    private Transform respawm_point;

    /*private bool isWallSliding;
    private float wallSlidingSpeed = 0.5f;*/
   
    private bool canDash = true;
    private bool isDashing;
    private float DashingPower = 50f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;
    /*[SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;*/


  
    void Update()
    {


        horizontal = Input.GetAxis("Horizontal");
       

        if (isGrounded() && !Input.GetButton("Jump"))
        {
            doubleJump = false;
            CloseJump();           

        }

        if (isDashing)
        {
            return;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                
               
                doubleJump = !doubleJump;
            }
            anim.SetBool("isJump", true);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }


        if (Input.GetKey(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        /*WallSlide();*/
        anim.SetFloat("Speed", Mathf.Abs(horizontal));

        Flip();
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

   /* private bool isWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }*/
    /*private void WallSlide()
    {
        if(isWalled() && !isGrounded() && horizontal !=0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed,float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }*/
    public void CloseJump()
    {
        anim.SetBool("isJump", false);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * DashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "respawm_Point")
        {
            respawm_point = collision.transform;
        }
        if(collision.tag == "Thorn")
        {
            gameObject.transform.position = respawm_point.position;
        }
        if (collision.tag == "Pattrol")
        {
            gameObject.transform.position = respawm_point.position;
        }
    }  

}
