using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Menu : MonoBehaviour
{
    //Varabiles
    public string levelToLoad;
    public string creditsMenu;

    public void OnClickedStart()
    {
        SceneManager.LoadScene(levelToLoad);
    }


    public void OnClickedCredits()
    {
        SceneManager.LoadScene(creditsMenu);
    }

    public void OnClickedExit()
    {
        Application.Quit();
    }


}
