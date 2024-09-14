using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBlackHole : MonoBehaviour
{
    public float pullForce = 1.5f; // 블랙홀의 당기는 힘
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("enemy"))
        {
            // 블랙홀 중심으로 당기는 방향 계산
            Vector2 direction = transform.position - other.transform.position;
            
            // 캐릭터의 Rigidbody2D에 당기는 힘 추가
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                if(other.CompareTag("Player"))
                {
                    Player _player = other.GetComponent<Player>();
                    _player.AddState(PlayerStates.IsInBlackHole);
                }
                rb.AddForce(direction.normalized * pullForce, ForceMode2D.Force);
                Debug.Log("이창조 ㅄ");                
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player _player = other.GetComponent<Player>();
            _player.RemoveState(PlayerStates.IsInBlackHole);
        }
    }
}
