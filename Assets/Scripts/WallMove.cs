using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    private float vertical;
    private float speed = 12f;
    private bool isWall;
    private bool isClimbing;

    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");

        if (isWall && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 7f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            isWall = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            isWall = false;
            isClimbing = false;
        }
    }
}
