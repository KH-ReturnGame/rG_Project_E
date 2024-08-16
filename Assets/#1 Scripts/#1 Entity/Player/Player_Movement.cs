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
    // 음....
    Vector2 inputVec;
    float speed = 3;
    public bool knuck = false;
    public float x, y;   

    //제일 처음 호출
    void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _player.AddState(PlayerStates.CanDash);
        _playerCollider = GetComponent<Collider2D>();
    }

    //매 프레임 실행
    void Update()
    {
        skilluse();
        x = _playerRigidbody.position.x;
        y = _playerRigidbody.position.y;
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
        Vector2 HorizontalVec = new Vector2(_playerRigidbody.position.x + inputVec.x, _playerRigidbody.position.y);
        Debug.DrawRay(HorizontalVec, Vector2.down, new Color(0, 1, 0));
        RaycastHit2D HrayHit = Physics2D.Raycast(HorizontalVec, Vector2.down, 1, LayerMask.GetMask("platform"));
        Vector2 VerticalVec = new Vector2(_playerRigidbody.position.x, _playerRigidbody.position.y + inputVec.y);
        Debug.DrawRay(VerticalVec, Vector2.left, new Color(0, 1, 0));
        RaycastHit2D VrayHit = Physics2D.Raycast(VerticalVec, Vector2.left, 1, LayerMask.GetMask("platform"));
        if (HrayHit.collider == null)
        {
            inputVec.x = 0;
        }
        if (VrayHit.collider == null)
        {
            inputVec.y = 0;
        }
        Vector2 nextvec = inputVec.normalized * speed * Time.fixedDeltaTime;
        _playerRigidbody.MovePosition(_playerRigidbody.position + nextvec);
        Debug.Log(inputVec.x);
    }
    void skilluse()
    {
        if (Input.GetKeyDown("y"))
        {
            knuck = true;
        }
        else
        {
            knuck = false;
        }
    }
}

