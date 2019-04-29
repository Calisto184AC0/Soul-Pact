using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuGameControl : MonoBehaviour
{
    public Button play;
    public Button exit;
    public Button credits;

    public void Start()
    {
        // get the Navigation data
        Navigation navigation = exit.navigation;

        // switch mode to Explicit to allow for custom assigned behavior
        navigation.mode = Navigation.Mode.Explicit;

        // highlight the Save button if the up arrow key is pressed
        navigation.selectOnUp = play;

        // reassign the struct data to the button
        exit.navigation = navigation;

    }
    public void Update()
    {
        if(Input.GetButton("Exit"))
        {
            EndGame();
        }
    }

    public void pressPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }


    public void EndGame()
    {
        Application.Quit();
    }

}
