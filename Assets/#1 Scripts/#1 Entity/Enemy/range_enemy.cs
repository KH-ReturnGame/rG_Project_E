using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class range_enemy : MonoBehaviour
{
    Enemy enemy;
    public GameObject bullet;
    ControllAnim _contAnim;
    void Awake()
    {
        enemy = GetComponent<Enemy>();
        _contAnim = GetComponent<ControllAnim>();
    }
    
    void Update()
    {
        if (enemy.IsContainState(EnemyStates.IsAttacking))
        {
            Debug.Log("bullet spawn");
            Instantiate(bullet, this.transform.position, Quaternion.identity);
            enemy.RemoveState(EnemyStates.IsAttacking);
            _contAnim.EnabledAnim.SetTrigger("attack");
        }
        else if (!enemy.IsContainState(EnemyStates.IsAttacking))
        {
            Debug.Log("do not attack");
        }
    }
}
