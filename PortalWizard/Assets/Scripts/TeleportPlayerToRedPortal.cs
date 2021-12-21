using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayerToRedPortal : MonoBehaviour
{
    public GameObject exitPortal;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        exitPortal = GameObject.FindGameObjectWithTag("RedPortal");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D coll) 
    {
        Debug.Log("col happened");
        player.transform.position = exitPortal.gameObject.transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.transform.position = exitPortal.gameObject.transform.position;
    }
    
}
