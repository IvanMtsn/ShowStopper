using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    int _width = 1920;
    int _height = 1080;
    bool _screenMode = true;
    void Start()
    {
        
    }
    public void SetRes1280()
    {
        _width = 1280;
        _height = 720;
        Screen.SetResolution(_width, _height, _screenMode);
    }
    public void SetRes1920()
    {
        _width = 1920;
        _height = 1080;
        Screen.SetResolution(_width, _height, _screenMode);
    }
    public void SetRes2560()
    {
        _width = 2560;
        _height = 1440;
        Screen.SetResolution(_width, _height, _screenMode);
    }
    public void SetWindowed()
    {
        _screenMode = false;
        Screen.SetResolution(_width, _height, _screenMode);
    }
    public void SetFullscreen()
    {
        _screenMode = true;
        Screen.SetResolution(_width, _height, _screenMode);
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MenuScreen");
    }
}
