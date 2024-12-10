using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    bool alive = true;
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

    //do while alive
    IEnumerator lifetime()
    {
        yield return new WaitForSeconds(3);               //operate after 3s
        alive = false;                                    //stop chasing
        Vector2 direction = (player.transform.position - transform.position).normalized;  //make direction
        rigid.AddForce(direction * dashspeed, ForceMode2D.Impulse);                       //add force
        Destroy(this,5);                                                                  //destroy after 5s
    }

    void FixedUpdate()
    {
        if (alive)
        {
            movement();
        }
    }

    //move while alive
    void movement()
    {
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nexcVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nexcVec);
    }
}