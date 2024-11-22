using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Vector2 dirction = new Vector2();
    bool alive = true;
    int dead = 0;
    float dashspeed = 100;
    GameObject player;
    float angle;
    public float speed;
    Rigidbody2D target;
    Rigidbody2D rigid;
    public float distance;
    public float range;
    public bool fight;
    Enemy enemy;
    void Awake()
    {
        player = GameObject.Find("player 1(Clone)");
        target = player.GetComponent<Rigidbody2D>();
        rigid = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
        StartCoroutine(lifetime());
    }

    IEnumerator lifetime()
    {
        yield return new WaitForSeconds(3);
        alive = false;
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rigid.AddForce(direction * dashspeed, ForceMode2D.Impulse);
        Destroy(this,5);
    }

    void FixedUpdate()
    {
        if (alive)
        {
            movement();
        }
    }

    void movement()
    {
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nexcVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nexcVec);
    }
}