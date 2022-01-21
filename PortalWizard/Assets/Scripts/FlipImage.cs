using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipImage : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 startScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startScale = transform.localScale;
    }

    void Update()
    {
        if (PlayerHasHorizontalSpeed())
        {
            transform.localScale = new Vector3(-Mathf.Sign(rb.velocity.x) * startScale.x, startScale.y, startScale.z);
        }
    }

    bool PlayerHasHorizontalSpeed()
    {
        return Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
    }
}
