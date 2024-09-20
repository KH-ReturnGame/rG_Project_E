using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrap : MonoBehaviour
{
    int WhatEvent;
    public GameObject SpiderWeb;
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

    IEnumerator firstEvent() // 화살 발사
    {
        yield return null;
    }

    IEnumerator secondEvent() // 지뢰
    {
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
        yield return null;
    }
}
