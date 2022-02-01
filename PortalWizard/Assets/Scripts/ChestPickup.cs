using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestPickup : MonoBehaviour
{
    Animator animator;
    GameSession gameSession;

    void Start()
    {
        animator = GetComponent<Animator>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger("Open");
            gameSession.AddKey();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger("Close");
        }
    }
}
