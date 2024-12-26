using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class range_enemy : MonoBehaviour
{
    Enemy enemy;
    public GameObject bullet;
    void Awake()
    {
        enemy = GetComponent<Enemy>();
        
    }
    
    void Update()
    {
        if (enemy.IsContainState(EnemyStates.IsAttacking))
        {
            Debug.Log("bullet spawn");
            Instantiate(bullet, this.transform.position, Quaternion.identity);
            enemy.RemoveState(EnemyStates.IsAttacking);
        }
        else if (!enemy.IsContainState(EnemyStates.IsAttacking))
        {
            Debug.Log("do not attack");
        }
    }
}
