using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocity = 20f;
    public Rigidbody2D rb;
    public GameObject portal;

    private Transform[] currentAndLastTransform;
    private Vector3 lastMovedTrajectory;
    private RaycastHit2D checkForWall;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * velocity;
        currentAndLastTransform[0] = rb.transform;
        currentAndLastTransform[1] = rb.transform;
    }

    private void Update()
    {
        // get projectile position and vector between them
        currentAndLastTransform[0] = currentAndLastTransform[1];
        currentAndLastTransform[1] = rb.transform;
        lastMovedTrajectory = currentAndLastTransform[1].position - currentAndLastTransform[0].position;

        // shoot raycast to chech for a thin wall
        checkForWall = Physics2D.Raycast(rb.transform.position, lastMovedTrajectory);
        if(checkForWall.collider != null)
        {
            Instantiate(portal, new Vector3(rb.transform.position.x, rb.transform.position.y, -1), checkForWall.transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Instantiate(portal, new Vector3(rb.transform.position.x, rb.transform.position.y, -1), hitInfo.transform.rotation);
        Destroy(gameObject);
    }
}
