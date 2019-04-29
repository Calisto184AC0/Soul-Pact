using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadyGuy : MonoBehaviour
{

    public Dialogue dialogue;

    public GameObject plate1, plate2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
        }
    }
}
