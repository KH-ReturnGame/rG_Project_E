using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBomb : MonoBehaviour // 시간제한 -> 폭탄 벙
{
    float TimeLimit;
    int speed;
    public GameObject Explode_Range;
    CircleCollider2D explode_Circle;
    // Start is called before the first frame update
    void Start()
    {
        TimeLimit = 2.5f;
        speed = 1;
        explode_Circle = Explode_Range.GetComponent<CircleCollider2D>();
        explode_Circle.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        TimeLimit -= Time.deltaTime * speed;
        if(TimeLimit <= 0)
        {
            Boom();
        }
    }

    void Boom()
    {
        TimeLimit += 5;
        speed = 0;
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        explode_Circle.enabled = true;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
        yield return null;
    }
}
