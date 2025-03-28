using System;
using UnityEngine.Tilemaps;
using UnityEngine;

public class Player_Collide : MonoBehaviour
{
    private Player _player;
    Player_Defence player_Defence;

    public void Start()
    {
        _player = this.GetComponentInParent<Player>();
        player_Defence = GetComponent<Player_Defence>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "trap"
        && !_player.IsContainState(PlayerStates.IsDashing)
        && !_player.IsContainState(PlayerStates.IsDefencing))
        {
            _player.AddState(PlayerStates.IsDie);
        }

        if(collision.gameObject.name == "Arrow(Clone)"
        && _player.IsContainState(PlayerStates.IsDefencing))
        {
            Arrow _arrow = collision.gameObject.GetComponent<Arrow>();
            _arrow.arrowType += 2;
            if(_arrow.arrowType > 4)
            {
                _arrow.arrowType -= 4;
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "trap"
        && !_player.IsContainState(PlayerStates.IsDashing)
        && !_player.IsContainState(PlayerStates.IsDefencing))
        {
            _player.AddState(PlayerStates.IsDie);
        }
        if (other.gameObject.tag == "enemyattack"
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