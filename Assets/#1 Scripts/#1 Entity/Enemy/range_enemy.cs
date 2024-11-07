using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class range_enemy : MonoBehaviour
{
    Rigidbody2D rigid;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        
    }
}
