using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocity = 20f;
    public Rigidbody2D rb;
    public GameObject portal;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * velocity;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Instantiate(portal, new Vector3(rb.transform.position.x, rb.transform.position.y, -1), hitInfo.transform.rotation);
        Debug.Log(hitInfo.transform.position);
        Destroy(gameObject);
    }
}
