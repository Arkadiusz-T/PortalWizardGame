using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject greenPortal;
    public GameObject redPortal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shootGreenPortal();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            shootRedPortal();
        }
    }

    private void shootRedPortal()
    {
        Instantiate(redPortal, firePoint.position, firePoint.rotation);
    }

    void shootGreenPortal()
    {
        Instantiate(greenPortal, firePoint.position, firePoint.rotation);
    }
}
