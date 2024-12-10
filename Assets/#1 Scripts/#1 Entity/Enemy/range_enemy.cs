using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class range_enemy : MonoBehaviour
{
    Enemy enemy;
    public Transform prefab;
    void Start()
    {
        enemy = this.transform.parent.GetComponent<Enemy>();
    }

    void Update()
    {
        if (enemy.IsContainState(EnemyStates.IsAttacking))
        {
            Instantiate(prefab, new Vector2(this.position), Quaternion.identity);
        }
        else if (!enemy.IsContainState(EnemyStates.IsAttacking))
        {

        }
    }
}
