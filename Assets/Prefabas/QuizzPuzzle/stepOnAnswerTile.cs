﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepOnAnswerTile : MonoBehaviour
{
    QuizzPuzzleController puzzleController;
    // Start is called before the first frame update
    private void Start() { puzzleController = FindObjectOfType<QuizzPuzzleController>(); }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            puzzleController.next(gameObject.name);
            gameObject.SetActive(false);
        }
    }
}