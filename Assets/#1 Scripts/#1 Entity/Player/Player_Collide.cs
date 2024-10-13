using System;
using UnityEngine.Tilemaps;
using UnityEngine;

public class Player_Collide : MonoBehaviour
{
    private Player _player;

    public void Start()
    {
        _player = this.GetComponentInParent<Player>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "trap" 
        && !_player.IsContainState(PlayerStates.IsDashing) 
        && !_player.IsContainState(PlayerStates.IsDefencing))
        {
            _player.AddState(PlayerStates.IsDie);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "trap" 
        && !_player.IsContainState(PlayerStates.IsDashing) 
        && !_player.IsContainState(PlayerStates.IsDefencing))
        {
            _player.AddState(PlayerStates.IsDie);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {

    }
}
