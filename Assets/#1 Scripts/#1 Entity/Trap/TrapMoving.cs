using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMoving : MonoBehaviour
{
    public int direction;
    public float speed;
    public GameObject pivot1;
    public GameObject pivot2;

    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
        speed = Random.Range(1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        TrapMove();
    }

    public void TrapMove()
    {
        if(direction == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, pivot1.transform.position, Time.deltaTime * 2 * speed);
        }
        else if(direction == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, pivot2.transform.position, Time.deltaTime * 2 * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.Equals(pivot1))
        {
            direction = 2;
        }
        else if(other.gameObject.Equals(pivot2))
        {
            direction = 1;
        }
    }
}