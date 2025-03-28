using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Dead : MonoBehaviour
{
    Rigidbody2D rigid;
    Collider2D _collider;
    private Enemy testEnemy;
    ControllAnim _contAnim;
    void Start()
    {
        testEnemy = GetComponent<Enemy>();
        rigid = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _contAnim = GetComponent<ControllAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        if(testEnemy.GetHp() <= 0)
        {
            testEnemy.AddState(EnemyStates.IsDie);
            Destroy(gameObject, 1f);
        }
        if(testEnemy.IsContainState(EnemyStates.IsStun))
        {
            rigid.velocity = new Vector2 (0,0);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "kick")
        {
            testEnemy.AddState(EnemyStates.IsKicked);
            if(testEnemy.IsContainState(EnemyStates.IsWall))
            {
                testEnemy.AddState(EnemyStates.IsStun);
                testEnemy.TakeDamage(1);
                StartCoroutine(Stun());
            }
        }
        else if(collision.gameObject.tag == "powerKick")
        {
            testEnemy.TakeDamage(testEnemy.GetHp());
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "wall" && testEnemy.IsContainState(EnemyStates.IsKicked))
        {          
            testEnemy.AddState(EnemyStates.IsWall);
            testEnemy.AddState(EnemyStates.IsStun);
            testEnemy.RemoveState(EnemyStates.IsKicked);
            testEnemy.TakeDamage(1);
            StartCoroutine(Stun());
        }
        else if(other.gameObject.tag == "trap")
        {
            testEnemy.TakeDamage(1000000);
            testEnemy.AddState(EnemyStates.IsDie);
            _contAnim.EnabledAnim.SetTrigger("die");
            _collider.enabled = false;
        }
    }

    IEnumerator Stun()
    {
        // rigid.velocity = new Vector2 (0,0);
        _contAnim.EnabledAnim.SetTrigger("damage");
        yield return new WaitForSeconds(1.5f);//1.5초 후 기절 풀림
        testEnemy.RemoveState(EnemyStates.IsStun);
        testEnemy.RemoveState(EnemyStates.IsWall);
        testEnemy.RemoveState(EnemyStates.IsKicked);
    }
}