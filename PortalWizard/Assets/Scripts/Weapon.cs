using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject greenPortal;
    [SerializeField] GameObject redPortal;
    [SerializeField] Animator animator;

    bool createRedPortal = false;

    void OnFire()
    {
        animator.SetTrigger("Attack");
        Instantiate(bullet, firePoint.position, transform.rotation);
    }

    void OnCreatePortal()
    {
        if (createRedPortal)
        {
            Instantiate(redPortal, firePoint.position, transform.rotation);
            createRedPortal = false;
        }
        else
        {
            Instantiate(greenPortal, firePoint.position, transform.rotation);
            createRedPortal = true;
        }
    }
}
