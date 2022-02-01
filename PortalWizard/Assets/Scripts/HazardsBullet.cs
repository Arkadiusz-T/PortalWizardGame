using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardsBullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 10f;

    Rigidbody2D rb;
    float xSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        xSpeed = transform.localScale.x * bulletSpeed;
    }

    void Update()
    {
        rb.velocity = new Vector2(xSpeed, 0f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Invoke("DestroyBullet", 0.1f);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
