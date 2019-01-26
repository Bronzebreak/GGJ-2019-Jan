using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End_menu : MonoBehaviour
{
    //Variables
    public string levelToLoad;
    public string mainMenu;


    public void OnClickedRestart()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void OnclickMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
