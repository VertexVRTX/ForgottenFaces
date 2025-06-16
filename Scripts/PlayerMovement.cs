using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    public bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!canMove)
        {
            movement = Vector2.zero;
            animator.SetBool("Idle", false);
            rb.velocity = new Vector2(0f, rb.velocity.y);
            return;
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        movement = new Vector2(moveX, 0f);
        
        animator.SetBool("Idle", moveX != 0);
        
        if (moveX != 0)
            transform.localScale = new Vector3(Mathf.Sign(moveX), 1, 1);
    }

    void FixedUpdate()
    {
        if (!canMove)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
            return;
        }

        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }
}
