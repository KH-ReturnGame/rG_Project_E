using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash_enemy : MonoBehaviour
{
    float dashspeed = 100;
    GameObject player;
    public float speed;
    Rigidbody2D target;
    Rigidbody2D rigid;
    public float distance;
    public float range;
    public bool fight;
    Enemy enemy;
    ControllAnim _contAnim;
    void Start()
    {
        player = GameObject.Find("player 1(Clone)");
        target = player.GetComponent<Rigidbody2D>();
        rigid = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
        _contAnim = GetComponent<ControllAnim>();
    }
    
    void Update()
    {
        distance = Vector2.Distance(player.transform.position, this.transform.position);
    }

    void FixedUpdate()
    {
        if (!enemy.IsContainState(EnemyStates.IsKicked) 
            && !enemy.IsContainState(EnemyStates.IsDie) 
            && !enemy.IsContainState(EnemyStates.IsAttacking)
            && !enemy.IsContainState(EnemyStates.IsStun) 
            && !enemy.IsContainState(EnemyStates.IsDetect))
        {
            if (distance < range)
            {
                StartCoroutine(attack());
                fight = true;
            }
            else
            {
                movement();
            }
        }
    }

    IEnumerator attack()// 대쉬 공격
    {
        enemy.AddState(EnemyStates.IsDetect);

        yield return new WaitForSeconds(1.5f);
        
        enemy.RemoveState(EnemyStates.IsDetect);
        enemy.AddState(EnemyStates.IsAttacking);
        enemy.AddState(EnemyStates.IsKicked);
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rigid.AddForce(direction * dashspeed, ForceMode2D.Impulse);
        _contAnim.EnabledAnim.SetTrigger("attack");
        yield return new WaitForSeconds(1.5f);
        enemy.RemoveState(EnemyStates.IsAttacking);
        enemy.RemoveState(EnemyStates.IsKicked);
    }

    void movement()
    {
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nexcVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nexcVec);
    }
}