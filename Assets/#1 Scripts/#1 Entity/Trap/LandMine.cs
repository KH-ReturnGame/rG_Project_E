using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMine : MonoBehaviour // 삥! 하면서 빛나고 지뢰 활성화
{
    BoxCollider2D LM_Collider;
    SpriteRenderer LM_Sprite;
    // Start is called before the first frame update
    void Start()
    {
        LM_Collider = GetComponent<BoxCollider2D>();
        LM_Sprite = GetComponent<SpriteRenderer>();
        LM_Collider.enabled = false;
        StartCoroutine(ActiveLandMine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ActiveLandMine()
    {
        LM_Sprite.color = new Color(0,1,0,0.8f);
        yield return new WaitForSeconds(1.5f);
        LM_Collider.enabled = true;
        LM_Sprite.color = new Color(0,1,0,0);
        yield return null;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            // 펑 터지는거
        }
    }
}
