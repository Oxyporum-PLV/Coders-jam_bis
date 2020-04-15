using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 5f;
    [Range(1, 10)]
    public float jumpVelocity;

    private bool wallGrab = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(x, y);

        Walk(dir);

        wallGrab = CollabProxy.onWall && Input.GetKey(KeyCode.LeftShift);

        if (wallGrab)
        {
            rb.velocity = new Vector2(rb.velocity.x, y * speed);
        }

        if (CollabProxy.onWall && !CollabProxy.onGround)
        {
            WallSlide();
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (CollabProxy.onGround)
            {
                Jump();
            }
        }
    }

    private void WallSlide()
    {
        rb.velocity = new Vector2(rb.velocity.x, -current_slide_speed);
    }

    private void Walk(Vector2 dir)
    {
        rb.velocity = (new Vector2(dir.x * speed, rb.velocity.y));
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += Vector2.up * jumpVelocity;
    }
}
