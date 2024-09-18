using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTrap : MonoBehaviour
{
    int WhatEvent;
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
            Debug.Log("이벤트 발생");
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
                StartCoroutine(thirdEvent());
                break;
            case 4:
                StartCoroutine(forthEvent());
                break;
            default:
                StartCoroutine(firstEvent());
                break;
        }
    }

    IEnumerator firstEvent()
    {
        return null;
    }

    IEnumerator secondEvent()
    {
        return null;
    }

    IEnumerator thirdEvent()
    {
        return null;   
    }

    IEnumerator forthEvent()
    {
        return null;
    }
}
