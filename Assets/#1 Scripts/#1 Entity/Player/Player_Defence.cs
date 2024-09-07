using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Defence : MonoBehaviour
{
    Player _player;
    private float _DefenceCooldown;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
        _DefenceCooldown = 2.5f;
        _player.AddState(PlayerStates.CanDefence);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && _player.IsContainState(PlayerStates.CanDefence))
        {
            StartCoroutine(Defence());
        }
    }

    IEnumerator Defence()
    {
        _player.RemoveState(PlayerStates.CanDefence);
        _player.AddState(PlayerStates.IsDefencing);

        Rigidbody2D _rigid = GetComponent<Rigidbody2D>();
        _rigid.velocity = Vector2.zero;

        yield return new WaitForSeconds(_DefenceCooldown);

        _player.AddState(PlayerStates.CanDefence);
        _player.RemoveState(PlayerStates.IsDefencing);

        yield return null;
    }
}
