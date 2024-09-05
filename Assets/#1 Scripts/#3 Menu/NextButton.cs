using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    public GameObject[] _AbleSettings;
    [SerializeField] private int _SettingIdx;
    int _ScreenWidth, _ScreenHeight;
    bool _FullScreenOn;
    float _VibrateRate;
    // Start is called before the first frame update
    void Start()
    {
        _SettingIdx = 0; // 나중에 GetInt 로 받아와야댐
        _ScreenWidth = 1920;
        _ScreenHeight = 1080;
        _FullScreenOn = true;
        _VibrateRate = 1;   
        Screen.SetResolution(_ScreenWidth, _ScreenHeight, _FullScreenOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextSetting(int _next)
    {
        _AbleSettings[_SettingIdx].SetActive(false);
        if(_SettingIdx + _next > _AbleSettings.Length - 1)
        {
            _SettingIdx = 0;
        }
        else if(_SettingIdx + _next < 0)
        {
            _SettingIdx = _AbleSettings.Length - 1;
        }
        else
        {
            _SettingIdx += _next;
        }
        Debug.Log(_SettingIdx);
        _AbleSettings[_SettingIdx].SetActive(true);
    }
    public void SetScreen()
    {
        switch (_SettingIdx)
        {
            case 0:
                _ScreenWidth = 1920;
                _ScreenHeight = 1080;
                break;
            case 1:
                _ScreenWidth = 1280;
                _ScreenHeight = 720;
                break;
            case 2:
                _ScreenWidth = 960;
                _ScreenHeight = 540;
                break;
            case 3:
                _ScreenWidth = 720;
                _ScreenHeight = 480;
                break;
            case 4:
                _ScreenWidth = 640;
                _ScreenHeight = 360;
                break;
            default:
                _ScreenWidth = 1920;
                _ScreenHeight = 1080;
                break;
        }    
        Screen.SetResolution(_ScreenWidth, _ScreenHeight, _FullScreenOn);
    }
    public void SetVSync()
    {
        QualitySettings.vSyncCount = _SettingIdx;
    }
    public void SetFullScreen()
    {
        if(_SettingIdx == 0)
        {
            _FullScreenOn = true;
        }
        else if(_SettingIdx == 1)
        {
            _FullScreenOn = false;
        }
        Screen.fullScreen = _FullScreenOn;
    }
    public void SetVibrate()
    {
        switch (_SettingIdx)
        {
            case 0:
                _VibrateRate = 1f;
                break;
            case 1:
                _VibrateRate = 0.8f;
                break;
            case 2:
                _VibrateRate = 0.6f;
                break;
            case 3:
                _VibrateRate = 0.4f;
                break;
            case 4:
                _VibrateRate = 0.2f;
                break;
            case 5:
                _VibrateRate = 0f;
                break;
            default:
                _VibrateRate = 1f;
                break;
        }
    }
}
