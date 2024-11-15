using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Meteor : MonoBehaviour
{
    public GameObject METEOR;
    public float spawnRadius = 7.5f;  // Radius in which meteors can spawn
    public float minDistanceBetweenMeteors = 1f;  // Minimum distance to avoid overlap
    public int maxMeteors = 7;  // Max number of meteors
    private List<Vector3> meteorPositions = new List<Vector3>();
    EnemyMove enemyMove;

    // Start is called before the first frame update
    void Start()
    {
        enemyMove = GetComponent<EnemyMove>();
        SpawnMeteors();
    }

    void SpawnMeteors()
    {
        int meteorsSpawned = 0;
        
        while (meteorsSpawned < maxMeteors)
        {
            Vector3 randomPosition = GetRandomPosition();

            if (IsPositionValid(randomPosition))
            {
                GameObject newMeteor = Instantiate(METEOR, randomPosition, Quaternion.identity);
                meteorPositions.Add(randomPosition);
                meteorsSpawned++;
            }
        }
    }

    Vector3 GetRandomPosition()
    {
        return new Vector3(
            Random.Range(-spawnRadius, spawnRadius),
            Random.Range(-spawnRadius, spawnRadius),
            Random.Range(-spawnRadius, spawnRadius)
        );
    }

    bool IsPositionValid(Vector3 position)
    {
        foreach (Vector3 existingPosition in meteorPositions)
        {
            if (Vector3.Distance(position, existingPosition) < minDistanceBetweenMeteors)
            {
                return false;
            }
        }
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}