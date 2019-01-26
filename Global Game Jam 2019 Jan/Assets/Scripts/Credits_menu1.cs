using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits_menu1 : MonoBehaviour
{
    //Variables
    public string levelToLoad;

    public void OnClickedMenu()
    {
        SceneManager.LoadScene(levelToLoad);
    }
	
}
