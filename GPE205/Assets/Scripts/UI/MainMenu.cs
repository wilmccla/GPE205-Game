using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject StartMenu;
    public GameObject OptionsMenu;

    public void Play()
    {
        //Play button function that loads the overworld scene
        SceneManager.LoadScene("Overworld");
    }

    public void Options()
    {
        StartMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void Quit()
    {
        //Quit button function that quits the game
        Application.Quit();
    }
}
