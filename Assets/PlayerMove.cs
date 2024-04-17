using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMove : MonoBehaviour
{
    private Animator animator;
    private float direction = 0f;
    private PhotonView photonView;

    public float speed = 400f;
    public Rigidbody2D playerRB;

    private PlayerController controls;

    private void Start()
    {
        animator = GetComponent<Animator>();
        photonView = GetComponent<PhotonView>();

        controls = new PlayerController();
        controls.Enable();

        controls.Main.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            animator.SetBool("IsWalking", direction != 0f);
            FlipSprite(direction > 0f);
        }
    }

    void FixedUpdate()
    {
        playerRB.velocity = new Vector2(direction * speed * Time.deltaTime, playerRB.velocity.y);
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
}
