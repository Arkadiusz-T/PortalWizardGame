using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    Rigidbody2D myRigidbody;
    Vector3 startScale;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        startScale = transform.localScale;
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Player")
        {
            moveSpeed = -moveSpeed;
            FlipEnemyFacing();
        }
    }

    void FlipEnemyFacing()
    {
        transform.localScale = new Vector3(Mathf.Sign(myRigidbody.velocity.x) * startScale.x, startScale.y, startScale.z);
    }
}
