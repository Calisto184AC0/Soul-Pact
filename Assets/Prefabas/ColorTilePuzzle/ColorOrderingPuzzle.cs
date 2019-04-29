using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorOrderingPuzzle : PuzzleController
{
    [Header("Solution Blocks")]
    public GameObject[] solutionTiles;
    bool completed = false;

    public int currentPosition = 0;

    private void Update()
    {
        checkOrder();
    }

    public void next(GameObject next)
    {
        if (!completed && solutionTiles[currentPosition].name.Equals(next.name))
        {
            currentPosition++;
        }
        else
        {
            currentPosition = 0;
        }
    }

    void checkOrder()
    {
        if (currentPosition == solutionTiles.Length && !completed)
        {
            summonSouls();
            completed = true;
        }
    }
}
