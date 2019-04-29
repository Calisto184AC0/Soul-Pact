using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    const int MAINMENUINDEX = 0;
    public GameObject player;
    public GameObject respawn;
    [Header("Dialogues")]
    public Dialogue initialDialogue;
    public Dialogue finalDialogue;
    DialogueManager manager;

    [Header("UI")]
    public GameObject keyBox;
    Text keyText;
    public GameObject soulBox;
    Text soulCountText;

    [Header("Soul Data")]
    public int playerSoulCount;
    public const int TOATALSOULCOUNT = 100;
    public int availableSouls;


    [Header("Keys")]
    public int keyCount;


    private void Start()
    {
        keyText = keyBox.transform.GetChild(1).GetComponent<Text>();
        soulCountText = soulBox.transform.GetChild(1).GetComponent<Text>();
        keyCount = 0;
        UpdateKeys();
        UpdatePlayerSouls();
        manager = FindObjectOfType<DialogueManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckButtonPress();
        CheckSoulCount();
    }

    void CheckSoulCount() {

        if(playerSoulCount < 1 && !player.GetComponent<CameraController>().IsDying)
        {
            
            player.GetComponent<CameraController>().targetPosition = respawn.transform.parent.transform.GetChild(0).transform.position;
            player.transform.position = respawn.transform.position;
            StartCoroutine(wait());
            
            manager.StartDialogue(finalDialogue);
            player.GetComponent<CameraController>().IsDying = true;
            Debug.Log("Memuerto");
            SceneManager.LoadScene(0);
        }
        
    }

    IEnumerator  wait()
    {
        
        yield return new WaitForSeconds(2);
    }
    public void CheckDeath()
    {
        playerSoulCount--;
        UpdatePlayerSouls();
    }
    void UpdateAvailableSouls()
    {
        availableSouls = TOATALSOULCOUNT - playerSoulCount;
    }
    void UpdatePlayerSouls()
    {
        soulCountText.text = "" + playerSoulCount;

    }

    public void UseKey()
    {
        keyCount--;
        UpdateKeys();
    }

    public void PickKey()
    {
        keyCount++;
        UpdateKeys();
    }


    void UpdateKeys()
    {
        if(keyCount == 0)
        {
            keyBox.transform.GetChild(0).gameObject.SetActive(false);
            keyBox.transform.GetChild(1).gameObject.SetActive(false);
            keyBox.transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (keyCount == 1)
        {
            keyBox.transform.GetChild(0).gameObject.SetActive(true);
            keyBox.transform.GetChild(1).gameObject.SetActive(false);
            keyBox.transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (keyCount == 2)
        {
            keyBox.transform.GetChild(0).gameObject.SetActive(true);
            keyBox.transform.GetChild(1).gameObject.SetActive(true);
            keyBox.transform.GetChild(2).gameObject.SetActive(false);
        }
        else if (keyCount == 3)
        {
            keyBox.transform.GetChild(0).gameObject.SetActive(true);
            keyBox.transform.GetChild(1).gameObject.SetActive(true);
            keyBox.transform.GetChild(2).gameObject.SetActive(true);
        }

    }

    public void PickSoul()
    {
        playerSoulCount++;
        UpdatePlayerSouls();
    }

    void CheckButtonPress()
    {

        //Close Game
        if (Input.GetButtonDown("Exit"))
        {
            SceneManager.LoadScene(MAINMENUINDEX);
        }
    }


}
