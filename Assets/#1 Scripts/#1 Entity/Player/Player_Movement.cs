using System.Collections;
using UnityEngine;

/// <summary>
/// 플레이어 움직임 담당 클래스
/// </summary>
/// <returns></returns>
public class Player_Movement : MonoBehaviour
{
    //플레이어
    private Rigidbody2D _playerRigidbody;
    private Player _player;
    private SpriteRenderer spriteRenderer;
    private Collider2D _playerCollider; 
    // 움직임
    Vector2 inputVec;
    float speed = 3;

    //제일 처음 호출
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _playerCollider = GetComponent<Collider2D>();
        _player.AddState(PlayerStates.CanDash);
    }

    //매 프레임 실행
    void Update()
    {
        
    }

    //0.02초마다 실행  --------------------------------------------------------------------------------
    private void FixedUpdate()
    {
        movement();
    }

    void movement()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
        
        Vector2 nextvec = inputVec.normalized * speed * Time.fixedDeltaTime;
        _playerRigidbody.MovePosition(_playerRigidbody.position + nextvec);
    }
}

