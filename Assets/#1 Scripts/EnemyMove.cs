using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject player;
    float angle;

    void Update()
    {
        angle = Mathf.Atan2(player.transform.position.y - transform.position.y,
                            player.transform.position.x - transform.position.x)
              * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

    void FixedUpdated()
    {
        Vector2 vec = new Vector2(0, 0);
    }
}