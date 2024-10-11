using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour // 빨간색 경고 -> 팍하고 가시 나옴
{
    SpriteRenderer Thorn_Sprite;
    PolygonCollider2D Thorn_Collider;
    // Start is called before the first frame update
    void Start()
    {
        Thorn_Sprite = GetComponent<SpriteRenderer>();
        Thorn_Collider = GetComponent<PolygonCollider2D>();
        StartCoroutine(ActiveThorn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ActiveThorn()
    {
        Thorn_Sprite.enabled = false;
        Thorn_Collider.enabled = false;
        yield return new WaitForSeconds(2f);

        Thorn_Sprite.enabled = true;
        Thorn_Collider.enabled = true;
        yield return new WaitForSeconds(1.5f);

        StartCoroutine(ActiveThorn());
        yield return null;
    }
}
