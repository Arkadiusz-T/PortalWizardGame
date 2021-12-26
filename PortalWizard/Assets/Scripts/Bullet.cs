using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocity = 20f;
    public Rigidbody2D rb;
    public GameObject portal;

    private Transform lastFrameTransform;
    private Vector3 lastRBTrajectory;
    private RaycastHit2D checkForWall;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * velocity;
        lastFrameTransform = rb.transform;
        lastRBTrajectory = new Vector3(0, 0, 0);
        checkForWall = Physics2D.Raycast(rb.transform.position, lastRBTrajectory);
    }

    void Update()
    {
        // get projectile position and vector between them
        // lastMovedTrajectory = currentAndLastTransform[1].position - currentAndLastTransform[0].position;

        //
        // shoot raycast to chech for a thin wall
        // checkForWall = Physics2D.Raycast(rb.transform.position, lastMovedTrajectory);
        // if (checkForWall.collider != null)
        // {
        //     Instantiate(portal, new Vector3(rb.transform.position.x, rb.transform.position.y, -1), checkForWall.transform.rotation);
        //     Destroy(gameObject);
        // }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Instantiate(portal, new Vector3(rb.transform.position.x, rb.transform.position.y, -1), new Quaternion(0,0,0,0));
        Destroy(gameObject);
    }
}
