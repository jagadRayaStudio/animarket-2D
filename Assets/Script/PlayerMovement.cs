using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Animator animator;
    private float horizontalMove;
    private bool moveRight;
    private bool moveLeft;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveLeft = false;
        moveRight = false;
    }

    void Update()
    {
        Movement();
    }

    public void pointerDownLeft()
    {
        moveLeft = true;
    }
    public void pointerUpLeft()
    {
        moveLeft = false;
    }
    public void pointerDownRight()
    {
        moveRight = true;
    }
    public void pointerUpRight()
    {
        moveRight = false;
    }

    void Movement()
    {
        if (moveLeft)
        {
            horizontalMove = -speed;
            animator.SetBool("IsWalking", true);
            FlipSprite(false);
        }
        else if (moveRight)
        {
            horizontalMove = speed;
            animator.SetBool("IsWalking", true);
            FlipSprite(true);
        }
        else
        {
            horizontalMove = 0;
            animator.SetBool("IsWalking", false);
        }
    }

    void FlipSprite(bool flipLeft)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (flipLeft)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }
}
