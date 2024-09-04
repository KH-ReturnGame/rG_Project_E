using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    public GameObject[] _AbleSettings;
    public int _next;
    public int _SettingIdx;
    // Start is called before the first frame update
    void Start()
    {
        _SettingIdx = 0; // 나중에 GetInt 로 받아와야댐
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextSetting()
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
        _AbleSettings[_SettingIdx].SetActive(true);
    }
}
