using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBlackHole : MonoBehaviour
{
    public float pullForce = 0.005f; // 블랙홀의 당기는 힘
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
        if (other.CompareTag("Player"))
        {
            if(other.CompareTag("Player"))
            {
                Player _player = other.GetComponent<Player>();
                if(_player.IsContainState(PlayerStates.IsDie)
                || _player.IsContainState(PlayerStates.IsDashing))
                {
                    pullForce = 0f;
                }
                else if(!_player.IsContainState(PlayerStates.IsDie)
                && !_player.IsContainState(PlayerStates.IsDashing))
                {
                    pullForce = 0.005f;
                }
            }
            
            other.transform.position = Vector2.MoveTowards(
                other.transform.position, 
                transform.position, 
                pullForce);
        }
    }
}
