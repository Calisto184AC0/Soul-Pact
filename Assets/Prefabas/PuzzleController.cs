using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleController : MonoBehaviour
{
    public int numberSouls;
    public GameObject soulPrefab;
    public float disperseDistance = 5;


    public void summonSouls()
    {
        for(int i = 0; i < numberSouls; i++)
        {
            Instantiate(soulPrefab, transform.position + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0).normalized * Random.Range(0, disperseDistance), new Quaternion(0, 0, 0, 0));

        }

    }
}
