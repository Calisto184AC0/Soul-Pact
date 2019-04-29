using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAdder : MonoBehaviour
{
    GameControl controller;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            controller.PickKey();
            gameObject.SetActive(false);
        }

    }
}
