using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapLava : MonoBehaviour
{
    float cooldown;
    float minX = -10f;
    float maxX = 10f;
    float minY = -5f;
    float maxY = 5f;
    public GameObject _lavaSpark;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = Random.Range(5f, 10f);
        StartCoroutine(Spark());
        StartCoroutine(Spark());
        StartCoroutine(Spark());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spark()
    {
        Vector2 RandPosiotion = GenerateRandomPosition();
        GameObject _spark = Instantiate(_lavaSpark, RandPosiotion, Quaternion.identity);
        yield return new WaitForSeconds(cooldown);

        cooldown = Random.Range(5f, 10f);
        StartCoroutine(Spark());

        yield return null;
    }

    Vector2 GenerateRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(transform.position.x + randomX, transform.position.y + randomY);
    }
}
