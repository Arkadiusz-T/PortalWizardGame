using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolMovement : MonoBehaviour
{

    public float movementSpeed = 5f;
    public Transform grountChecker;
    public static RaycastHit2D rcDown;
    public static RaycastHit2D rcForward;
    private bool facingLeft = true;
    private int maskLayer;

    Rigidbody2D rb;
    Vector3 startScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maskLayer = LayerMask.GetMask("Ground", "Enemy");
        startScale = transform.localScale;
    }

    void Update()
    {
        rb.velocity = new Vector2(-movementSpeed, 0f);
        rcDown = Physics2D.Raycast(grountChecker.position, Vector2.down);
        rcForward = Physics2D.Raycast(grountChecker.position, Vector2.left, 0.01f, maskLayer);

        if (rcDown.collider != null && rcForward.collider == null)
        {
            FlipEnemyFacing();
        }

        else if (rcDown.collider == null || rcForward.collider != null)
        {
            FlipEnemyFacing();
        }
    }

    void FlipEnemyFacing()
    {
        movementSpeed = -movementSpeed;
        transform.localScale = new Vector3(-Mathf.Sign(rb.velocity.x) * startScale.x, startScale.y, startScale.z);
    }
}
