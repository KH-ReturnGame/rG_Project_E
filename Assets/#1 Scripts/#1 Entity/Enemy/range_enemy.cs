using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class range_enemy : MonoBehaviour
{
    void Awake()
    {
        int speed = 10;
    }

    void FixedUpdate()
    {
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nexcVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nexcVec);
    }
}
