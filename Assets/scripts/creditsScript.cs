using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class creditsScript : MonoBehaviour
{
    GameObject credits;
    float init;
    public float displayTime;
    public GameObject mainMenu;
    
    // Update is called once per frame
    void Update()
    {
        init += Time.deltaTime;

        if(init > displayTime)
        {
            transform.gameObject.SetActive(false);
            mainMenu.SetActive(true);
        }
    }
}
