using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    bool isOpen = false;
    public GameControl controller;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && controller.keyCount > 0 && !isOpen)
        {
            controller.UseKey();
            animator.SetBool("IsOpen", true);
            isOpen = true;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
