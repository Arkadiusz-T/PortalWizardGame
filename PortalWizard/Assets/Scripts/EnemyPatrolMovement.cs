using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolMovement : MonoBehaviour
{

    public float movementSpeed;
    public static RaycastHit2D rc;
    // Start is called before the first frame update
    void Start()
    {
        rc = Physics2D.Raycast(transform.position, Vector2.left, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * movementSpeed;
    }
}
