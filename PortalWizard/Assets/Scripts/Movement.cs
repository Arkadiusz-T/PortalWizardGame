using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 7f;
    [SerializeField] float jumpSpeed = 40f;
    [SerializeField] Animator animator;

    Rigidbody2D rb;
    BoxCollider2D feetCollider;
    Vector2 moveInput;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        Run();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            Debug.Log("Not Jump");

            return;
        }
        if (value.isPressed)
        {
            Debug.Log("Jump");
            rb.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * movementSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;

        animator.SetBool("isRunning", PlayerHasHorizontalSpeed());
    }

    bool PlayerHasHorizontalSpeed()
    {
        return Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
    }

    bool PlayerHasVerticalSpeed()
    {
        return Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;
    }
}
