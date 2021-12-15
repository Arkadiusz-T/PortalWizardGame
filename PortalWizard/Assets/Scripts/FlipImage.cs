using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipImage : MonoBehaviour
{
    public float horizAxis;
    public bool turned_right = true;
    public bool turned_left = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizAxis = Input.GetAxis("Horizontal");

        if(turned_right && horizAxis < 0)
        {
            turned_right = false;
            turned_left = true;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (turned_left && horizAxis > 0)
        {
            turned_right = true;
            turned_left = false;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
