using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingEnemyScript : MonoBehaviour
{
    public Transform path;
    public Transform player;

    public float walkspeed = 0.1f;

    private List<Vector3> pathPositions;
    public int currentPosition = 0;
    private int nextPosition;
    private float margin = 0.5f;
    private bool forwardMovement = true;


    // Use this for initialization
    void Start()
    {
        pathPositions = new List<Vector3>();

        for (int i = 0; i < path.childCount; i++)
        {
            pathPositions.Add(path.GetChild(i).position);
        }
        if (pathPositions.Count > 1) nextPosition = currentPosition + 1;
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        int side = transform.position.x < pathPositions[nextPosition].x ? 1 : -1;

        if (Vector3.Distance(transform.position, pathPositions[nextPosition]) > margin)
        {
            transform.position = Vector2.Lerp(transform.position, pathPositions[nextPosition], walkspeed);
        }
        else
        {
            CalculateNextPosition();
        }
    }
    
    private void CalculateNextPosition()
    {
        currentPosition = nextPosition;

        if (forwardMovement)
        {
            if (currentPosition == pathPositions.Count - 1)
            {
                forwardMovement = false;
                nextPosition--;
            }
            nextPosition++;
        }
        else
        {
            if (currentPosition == 0)
            {
                forwardMovement = true;
                nextPosition++;
            }
            nextPosition--;
        }


    }
}
