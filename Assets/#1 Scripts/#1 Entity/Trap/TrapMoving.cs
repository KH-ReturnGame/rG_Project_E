using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMoving : MonoBehaviour
{
    public int direction;
    public GameObject pivot1;
    public GameObject pivot2;

    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
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
            transform.position = Vector3.MoveTowards(transform.position, pivot1.transform.position, Time.deltaTime * 2);
        }
        else if(direction == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, pivot2.transform.position, Time.deltaTime * 2);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.Equals(pivot1))
        {
            direction = 2;
            Debug.Log("Moving to pivot2");
        }
        else if(other.gameObject.Equals(pivot2))
        {
            direction = 1;
        }
    }
}