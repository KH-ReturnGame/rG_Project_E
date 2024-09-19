using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
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
    }
    void Update()
    {
        angle = Mathf.Atan2(player.transform.position.y - transform.position.y,
                            player.transform.position.x - transform.position.x)
              * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);

        distance = Vector2.Distance(player.transform.position, this.transform.position);

    }

    void FixedUpdate()
    {
        if (!enemy.IsContainState(EnemyStates.IsKicked) && !enemy.IsContainState(EnemyStates.IsDie) && !enemy.IsContainState(EnemyStates.IsAttacking))
        {
            if (enemy.IsContainState(EnemyStates.IsStun))
            {

            }
            if (distance < range)
            {
                enemy.AddState(EnemyStates.IsAttacking);
                StartCoroutine(attack());
                fight = true;
            }
            else
            {
                movement();
            }
        }
    }

    IEnumerator attack()
    {
        yield return new WaitForSeconds(1.5f);
        enemy.RemoveState(EnemyStates.IsAttacking);
    }

    void movement()
    {
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nexcVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nexcVec);
    }
}