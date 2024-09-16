using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapLava : MonoBehaviour
{
    public float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = Random.Range(5f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spark()
    {
        return null;
    }
}
