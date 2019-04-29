using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Labyrinth : MonoBehaviour
{
    public GameObject key1, key2,key3;
    public GameObject soul;
    public GameObject[] rooms;

    int random1 = 0, random2 = 0, random3 = 0;

    private void Start()
    {
        rooms = GameObject.FindGameObjectsWithTag("Room");

        generateKeys();
        generateSouls();
    }

    private void generateKeys()
    {
        GameObject[] roomsKeys;

        roomsKeys = searchRoomKey();

        while (random1 == random2 || random2 == random3 || random1 == random3)
        {
            random1 = UnityEngine.Random.Range(0, roomsKeys.Length);
            random2 = UnityEngine.Random.Range(0, roomsKeys.Length);
            random3 = UnityEngine.Random.Range(0, roomsKeys.Length);
        }

        key1.transform.parent = roomsKeys[random1].transform;
        key2.transform.parent = roomsKeys[random2].transform;
        key3.transform.parent = roomsKeys[random3].transform;

        Vector3 offset = new Vector3(0, 0, -1);

        key1.transform.position = roomsKeys[random1].transform.position + offset;
        key2.transform.position = roomsKeys[random2].transform.position + offset;
        key3.transform.position = roomsKeys[random3].transform.position + offset;
    }

    private GameObject[] searchRoomKey()
    {
        int i = 0;
        bool haveOneExit = false;

        foreach (GameObject g in rooms)
        {
            haveOneExit = g.GetComponent<AddDoors>().canKey;
            if (haveOneExit)
            {
                i++;
            }
        }

        GameObject[] res = new GameObject[i];
        int j = 0;

        foreach (GameObject g in rooms)
        {
            haveOneExit = g.GetComponent<AddDoors>().canKey;
            if (haveOneExit)
            {
                res[j] = g;
                j++;
            }
        }

        return res;
    }

    private void generateSouls()
    {
        int[] randomNumers = new int[11];

        for (int i = 0; i < randomNumers.Length; i++)
        {
            randomNumers[i] = UnityEngine.Random.Range(0, rooms.Length - 1);
            Instantiate(soul, rooms[randomNumers[i]].transform.position, Quaternion.identity, rooms[randomNumers[i]].transform);
        }
    }
}
