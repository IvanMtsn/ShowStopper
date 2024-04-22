using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
   // Canvas _menuCanvas;
    void Start()
    {
        // Screen.SetResolution(_width, _height, _screenMode);
        //GameObject tempMenu = GameObject.Find("MainCanvas");
        //GameObject tempOptions = GameObject.Find("OptionsCanvas");

        //_menuCanvas = tempMenu.GetComponent<Canvas>();

    }
    public void Exit()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void Options()
    {
        SceneManager.LoadScene("OptionsScreen");
    }
}
