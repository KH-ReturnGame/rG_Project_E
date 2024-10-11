using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour // 빨간색 경고 -> 팍하고 가시 나옴
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ActiveThorn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ActiveThorn()
    {
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(ActiveThorn());
        yield return null;
    }
}
