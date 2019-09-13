using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        //SceneManager.LoadScene("level"); //out of the 2 options, this one is better
        Debug.Log("START");
    }

    public void CreditsRoll()
    {
        Debug.Log("CREDITS");
    }
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}