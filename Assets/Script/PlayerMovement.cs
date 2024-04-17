using UnityEngine;
using UnityEngine.EventSystems;
using Photon.Pun;
using TMPro;

public class PlayerMovement : MonoBehaviourPunCallbacks
{
    private Animator animator;
    private float horizontalMove;
    private bool moveRight;
    private bool moveLeft;

    public TMP_Text playerName;

    public float speed;
    private Rigidbody2D rb;

    PhotonView view;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        view = GetComponent<PhotonView>();
        moveLeft = false;
        moveRight = false;

        if (view.IsMine)
        {
            PlayerInteractionsUI.instance.ButtonLeft.gameObject.GetComponent<EventTrigger>().
                AddListener(EventTriggerType.PointerDown, pointerDownLeft);
            PlayerInteractionsUI.instance.ButtonLeft.gameObject.GetComponent<EventTrigger>().
                AddListener(EventTriggerType.PointerUp, pointerUpLeft);
            PlayerInteractionsUI.instance.ButtonRight.gameObject.GetComponent<EventTrigger>().
                AddListener(EventTriggerType.PointerDown, pointerDownRight);
            PlayerInteractionsUI.instance.ButtonRight.gameObject.GetComponent<EventTrigger>().
                AddListener(EventTriggerType.PointerUp, pointerUpRight);
        }

        if (view.IsMine)
        {
            playerName.text = PhotonNetwork.NickName;
        }
        else
        {
            playerName.text = view.Owner.NickName;
        }
    }

    void Update()
    {
        if (view.IsMine)
        {
            Movement();
        }
    }

    public void pointerDownLeft()
    {
        moveLeft = true;
        photonView.RPC("SetFlipSpriteRPC", RpcTarget.All, false);
    }

    public void pointerUpLeft()
    {
        moveLeft = false;
    }

    public void pointerDownRight()
    {
        moveRight = true;
        photonView.RPC("SetFlipSpriteRPC", RpcTarget.All, true);
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
        }
        else if (moveRight)
        {
            horizontalMove = speed;
            animator.SetBool("IsWalking", true);
        }
        else
        {
            horizontalMove = 0;
            animator.SetBool("IsWalking", false);
        }
    }

    [PunRPC]
    void SetFlipSpriteRPC(bool flipLeft)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = flipLeft;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }
}