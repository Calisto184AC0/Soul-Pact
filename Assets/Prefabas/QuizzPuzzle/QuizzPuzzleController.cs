using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizzPuzzleController : PuzzleController
{
    public GameControl gameController;
    [Header("Questions")]
    public Dialogue Question1;

    bool d1Completed = false;

    DialogueManager dialogueManager;


    [Header("Answer Tiles")]
    public GameObject AnswerTiles;
    public GameObject correctAnswer;


    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!d1Completed)
            {
                dialogueManager.StartDialogue(Question1);
                AnswerTiles.gameObject.SetActive(true);
            }
        }
    }

    public void next(string tileName)
    {
        if (tileName.Equals(correctAnswer.name))
        {
            Debug.Log(tileName);
            d1Completed = true;
            summonSouls();
            AnswerTiles.gameObject.SetActive(false);

        } else
        {
            gameController.CheckDeath();
        }
    }



}
