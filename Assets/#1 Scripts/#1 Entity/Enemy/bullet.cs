using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    GameObject player;
    float angle;
    public float speed;
    Rigidbody2D target;
    Rigidbody2D rigid;
    public float distance;
    public float range;
    public bool fight;
    Enemy enemy;
    //void Attack();
    void Awake()
    {
        player = GameObject.Find("player 1(Clone)");
        target = player.GetComponent<Rigidbody2D>();
        rigid = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
        StartCoroutin(Life());
    }
    
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (enemy.IsContainState(EnemyStates.IsMove))
        {
            Bmovement();
        }
        else if (enemy.IsContainState(EnemyStates.IsAttacking))
        {
            Amovement();
        }
    }

    void Bmovement()
    {
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nexcVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nexcVec);
    }

    void Amovement()
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rigid.AddForce(direction* dashspeed, ForceMode2D.Impulse);
    }

    IEnumerator Life()
    {
        enemy.AddState(EnemyStates.IsMove);
        yield return new WaitForSeconds(2.0f);
        enemy.RemoveState(EnemyStates.IsMove);
        enemy.AddState(EnemyStates.IsAttacking);

        yield return new WaitForSeconds(1.0f);
        enemy.RemoveState(EnemyStates.IsAttacking);
        enemy.AddState(EnemyStates.IsDie);
    }
}
