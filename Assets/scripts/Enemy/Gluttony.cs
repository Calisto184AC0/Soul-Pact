using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gluttony : MonoBehaviour
{
    GameControl controller;
    static int burguerEaten = 0;

    private void Start()
    {
        burguerEaten = 0;
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControl>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (burguerEaten < 3)
            {
                controller.PickSoul();
                gameObject.SetActive(false);
                burguerEaten++;
            }
            else
            {
                controller.CheckDeath();
                gameObject.SetActive(false);
            }
        }
    }
}
