using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    GameObject player;
    public float speed;
    Rigidbody2D target;
    Rigidbody2D rigid;
    public float distance;
    public float range;
    public bool fight;
    Enemy enemy;
    ControllAnim _contAnim;
    public GameObject AttackObj;
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
        if (!enemy.IsContainState(EnemyStates.IsKicked) && !enemy.IsContainState(EnemyStates.IsDie) && !enemy.IsContainState(EnemyStates.IsAttacking)
            && !enemy.IsContainState(EnemyStates.IsStun) && !enemy.IsContainState(EnemyStates.IsDetect))
        {
            if (distance < range)
            {
                StartCoroutine(attack());
                fight = true;
            }
            else
            {
                StopAllCoroutines();
                movement();
            }
        }
    }

    IEnumerator attack()
    {
        enemy.AddState(EnemyStates.IsDetect);
        yield return new WaitForSeconds(1.5f);
        enemy.RemoveState(EnemyStates.IsDetect);

        enemy.AddState(EnemyStates.IsAttacking);
        AttackObj.SetActive(true);
        _contAnim.EnabledAnim.SetTrigger("attack");
        yield return new WaitForSeconds(1.5f);

        AttackObj.SetActive(false);
        enemy.RemoveState(EnemyStates.IsAttacking);
    }

    void movement()
    {
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nexcVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nexcVec);
        _contAnim.EnabledAnim.SetBool("walk", true);
    }
}