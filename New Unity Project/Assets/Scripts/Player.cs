using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;

    private Rigidbody2D myBody;

    private Animator anim;

    private string Walk_Animation = "Walk";

    private SpriteRenderer sr;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
    }

    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();

    }

    void FixedUpdate()
    {
        PlayerJump();
    }
    
    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position +=
            new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;
    }


    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(Walk_Animation, true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            anim.SetBool(Walk_Animation, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(Walk_Animation, false);
        }
     }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
