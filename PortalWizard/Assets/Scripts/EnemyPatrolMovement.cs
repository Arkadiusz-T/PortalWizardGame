using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolMovement : MonoBehaviour
{

    public float movementSpeed;
    public Transform grountChecker;
    public static RaycastHit2D rcDown;
    public static RaycastHit2D rcForward;
    private bool facingLeft = true;
    private int maskLayer;
    // Start is called before the first frame update
    void Start()
    {
        maskLayer = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        rcDown = Physics2D.Raycast(grountChecker.position, Vector2.down);
        rcForward = Physics2D.Raycast(grountChecker.position, Vector2.left, 0.001f, maskLayer);

        if (rcDown.collider != null && rcForward.collider == null)
        {
            if(facingLeft) transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * movementSpeed;
            else transform.position += new Vector3(1, 0, 0) * Time.deltaTime * movementSpeed;
        }

        else if (rcDown.collider == null || rcForward.collider != null)
        {
            if (facingLeft) 
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                facingLeft = false;
            }

            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                facingLeft = true;
            }
            
        }
    }
}
