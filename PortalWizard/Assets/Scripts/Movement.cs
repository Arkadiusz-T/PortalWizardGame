using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 7f;
    [SerializeField] float jumpSpeed = 40f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Animator animator;

    Rigidbody2D rb;
    BoxCollider2D feetCollider;
    CapsuleCollider2D bodyCollider;
    Vector2 moveInput;
    bool isAlive = true;
    float gravityScaleAtStart;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        feetCollider = GetComponent<BoxCollider2D>();
        bodyCollider = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = rb.gravityScale;
    }

    void Update()
    {
        if (isAlive)
        {
            Run();
            ClimbLadder();
        }
        Die();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (isAlive)
        {
            if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                return;
            }
            if (value.isPressed)
            {
                rb.velocity += new Vector2(0f, jumpSpeed);
            }
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * movementSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;

        animator.SetBool("isRunning", PlayerHasHorizontalSpeed());
    }

    void Die()
    {
        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")) && isAlive)
        {
            isAlive = false;
            animator.SetTrigger("Dying");
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }

    void ClimbLadder()
    {
        if (!feetCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            rb.gravityScale = gravityScaleAtStart;
            return;
        }
        Vector2 climbVelocity = new Vector2(rb.velocity.x, moveInput.y * climbSpeed);
        rb.velocity = climbVelocity;
        rb.gravityScale = 0f;
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
