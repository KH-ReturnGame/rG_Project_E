using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //public GameObject player;
    //float angle;
    public float speed;
    public Rigidbody2D target;
    Rigidbody2D rigid;



    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    /*void Update()
    {
        angle = Mathf.Atan2(player.transform.position.y - transform.position.y,
                            player.transform.position.x - transform.position.x)
              * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }*/

    void FixedUpdated()
    {
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nexcVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nexcVec);
        rigid.velocity = Vector2.zero;
    }
}