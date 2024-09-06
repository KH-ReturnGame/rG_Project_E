using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject player;
    float angle;
    public float speed;
    public Rigidbody2D target;
    Rigidbody2D rigid;
    public float distance;
    public Enemy enemy;
    //void Attack();
    void Awake()
    {
        player = GameObject.Find("player 1(Clone)");
        target = player.GetComponent<Rigidbody2D>();
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        angle = Mathf.Atan2(player.transform.position.y - transform.position.y,
                            player.transform.position.x - transform.position.x)
              * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);

        distance = Vector2.Distance(player.transform.position, this.transform.position);
        /*if (distance < 2)
        {
            Attack();
        }*/
    }

    void FixedUpdate()
    {
        
        Vector2 dirVec = target.position - rigid.position;
        if (enemy.IsContainState(EnemyState.IsStun))
        {
            nextvec = nextvec.zero;
        }
        Vector2 nexcVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nexcVec);
    }

    /*void Attack()
    {
        
    }*/
}