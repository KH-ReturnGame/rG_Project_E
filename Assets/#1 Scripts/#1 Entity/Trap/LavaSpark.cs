using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaSpark : MonoBehaviour
{
    public float Duration;
    // Start is called before the first frame update
    void Start()
    {
        Duration = Random.Range(2.5f, 5f);
        Invoke("LavaSparkDisappear", Duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player_Movement _player = collision.gameObject.GetComponent<Player_Movement>();
            _player.Sparked();
        }
    }

    void LavaSparkDisappear()
    {
        Destroy(gameObject);
    }
}
