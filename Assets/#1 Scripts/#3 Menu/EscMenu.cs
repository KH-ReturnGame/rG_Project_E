using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscMenu : MonoBehaviour
{
    public GameObject _Settings;
    GameObject _Canvas;
    // Start is called before the first frame update
    void Start()
    {
        _Canvas = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableMenu()
    {
        this.gameObject.SetActive(false);
    }

    public void SettingGame()
    {
        Instantiate(_Settings, _Canvas.transform);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
