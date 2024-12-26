using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee_enemy : MonoBehaviour
{
    Enemy enemy;
    SpriteRenderer spriteRenderer;
    Collider2D AttackCollider;
    void Start()
    {
        AttackCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemy = this.transform.parent.GetComponent<Enemy>();
    }

    void Update()
    {
        if (enemy.IsContainState(EnemyStates.IsAttacking))
        {
            AttackCollider.enabled = true;
            spriteRenderer.enabled = true;
        }
        else if (!enemy.IsContainState(EnemyStates.IsAttacking))
        {
            AttackCollider.enabled = false;
            spriteRenderer.enabled = false;
        }
    }
}
