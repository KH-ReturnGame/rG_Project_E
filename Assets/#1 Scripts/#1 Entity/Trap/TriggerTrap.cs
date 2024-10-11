using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrap : MonoBehaviour
{
    int WhatEvent;
    public GameObject Thorn;
    public GameObject LandMine;
    public GameObject SpiderWeb;
    public GameObject TimeBomb;
    // Start is called before the first frame update
    void Start()
    {
        WhatEvent = Random.Range(0,4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("kick"))
        {
            Event(WhatEvent);
        }
    }

    void Event(int eventIndex)
    {
        switch (eventIndex)
        {
            case 1:
                StartCoroutine(firstEvent());
                break;         
            case 2:
                StartCoroutine(secondEvent());
                break;
            case 3:
                StartCoroutine(thirdEvent(5));
                break;
            case 4:
                StartCoroutine(forthEvent());
                break;
            default:
                StartCoroutine(firstEvent());
                break;
        }
    }

    IEnumerator firstEvent() // 가시
    {
        int objectCount = Random.Range(7, 12); // 상한 미포함, 하한 포함
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = GenerateRandomPosition();
            Instantiate(Thorn, randomPosition, Quaternion.identity);
        }
        yield return null;
        yield return null;
    }

    IEnumerator secondEvent() // 지뢰
    {
        int objectCount = Random.Range(15, 21); // 상한 미포함, 하한 포함
        for (int i = 0; i < objectCount; i++)
        {
            Vector3 randomPosition = GenerateRandomPosition();
            Instantiate(LandMine, randomPosition, Quaternion.identity);
        }
        yield return null;
    }

    IEnumerator thirdEvent(int webs) // 거미줄 소환
    {
        yield return new WaitForSeconds(0.5f);
        
        for (int i = 0; i < webs; i++)
        {
            float PivotX = Random.Range(-7.5f, 7.5f);
            float PivotY = Random.Range(-7.5f, 7.5f);

            Vector2 _newPosition = new Vector2(transform.position.x + PivotX, transform.position.y + PivotY);

            GameObject _Web = Instantiate(SpiderWeb, _newPosition, Quaternion.identity);
        }
        yield return null;   
    }

    IEnumerator forthEvent() // 시한폭탄
    {
        Instantiate(TimeBomb, transform.position, Quaternion.identity);
        yield return null;
    }

    Vector3 GenerateRandomPosition()
    {
            // 범위 내에서 무작위 2D 좌표 생성 (원형 범위)
            float angle = Random.Range(0f, Mathf.PI * 2); // 무작위 각도
            float distance = Random.Range(0f, 10); // 무작위 거리
            float x = Mathf.Cos(angle) * distance;
            float y = Mathf.Sin(angle) * distance;

            return new Vector3(x, y, 0); // 2D에서는 Z축을 0으로 설정
    }
}
