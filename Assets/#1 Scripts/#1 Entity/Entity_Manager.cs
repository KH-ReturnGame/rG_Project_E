using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 엔티티들의 생성과 같은 기능 담당
/// </summary>
/// <returns></returns>
public class Entity_Manager : MonoBehaviour
{
    //플레이어 인스턴스
    private Player _player;
    //플레이어 Prefab
    [SerializeField]
    private GameObject playerPrefab1;

    private GameObject clone;
    
    //제일 처음 한번 호출
    void Awake()
    {
        //플레이어 생성
        clone = Instantiate(playerPrefab1);
        _player = clone.GetComponent<Player>();
        _player.Setup(1);
    }

    private void Update()
    {
        _player.Updated();
    }
}