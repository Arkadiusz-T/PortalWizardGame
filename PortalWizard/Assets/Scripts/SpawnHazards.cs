using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHazards : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    void Start()
    {
        InvokeRepeating("SpawnHazardsBullet", 1f, 3f);
    }

    void SpawnHazardsBullet()
    {
        Vector3 position = transform.position;
        position.z = 0;
        Instantiate(bullet, position, transform.rotation);
    }
}
