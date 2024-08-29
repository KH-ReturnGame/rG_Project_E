using System.Collections;
using UnityEngine;

/// <summary>
/// 플레이어 움직임 담당 클래스
/// </summary>
public class Player_Movement : MonoBehaviour
{
    // 플레이어
    private Rigidbody2D _playerRigid;
    private Player _player;
    private SpriteRenderer spriteRenderer;
    private Collider2D _playerCollider;
    public GameObject _camera;

    // 움직임
    Vector2 inputVec;
    public float speed = 3f;

    // 대시 관련 변수
    public float dashSpeed = 15f;      // 대시 속도
    public float dashDuration = 0.2f;  // 대시 지속 시간
    public AnimationCurve dashCurve;   // 대시 속도 곡선
    // 맵이동
    Vector3 moveJump = Vector2.zero;

    // 제일 처음 호출
    void Start()
    {
        _playerRigid = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        _playerCollider = GetComponent<Collider2D>();
        _player.AddState(PlayerStates.CanDash);
        if(_player.IsContainState(PlayerStates.IsDashing))
        {
            _player.RemoveState(PlayerStates.CanDash);
        }
        SheetAssigner SA = FindObjectOfType<SheetAssigner>();
		Vector2 tempJump = SA.roomDimensions + SA.gutterSize;
		moveJump = new Vector3(tempJump.x, tempJump.y, 0);
    }
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }


    // 매 프레임 실행
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _player.IsContainState(PlayerStates.CanDash))
        {
            if (!_player.IsContainState(PlayerStates.IsDie))
                StartCoroutine(Dash());
        }
    }

    // 0.02초마다 실행
    void FixedUpdate()
    {
        if (_player.IsContainState(PlayerStates.IsDashing)) // 대시 중에는 기본 움직임 중지
            return;

        if (!_player.IsContainState(PlayerStates.IsDie))
            movement();
    }

    void movement()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        _playerRigid.MovePosition(_playerRigid.position + nextVec);
    }

    IEnumerator Dash()
    {
        // 대시 상태 제거
        _player.RemoveState(PlayerStates.CanDash);

        Vector2 dashDirection = Quaternion.Euler(0, 0, -90f) * transform.up; // 현재 바라보는 방향으로 대시
        float startTime = Time.time;

        _player.AddState(PlayerStates.IsDashing); // 대쉬 상태 돌입

        // 대시 시작
        while (Time.time < startTime + dashDuration)
        {
            float t = (Time.time - startTime) / dashDuration;
            float curveValue = dashCurve.Evaluate(t);
            _playerRigid.velocity = dashDirection * dashSpeed * curveValue;

            yield return null; // 다음 프레임까지 대기
        }

        // 대시 종료
        _playerRigid.velocity = Vector2.zero;
        _player.RemoveState(PlayerStates.IsDashing);

        yield return new WaitForSeconds(0.75f); // 대시 쿨다운

        // 대시 상태 다시 추가
        _player.AddState(PlayerStates.CanDash);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "trap")
        {
            _player.AddState(PlayerStates.IsDie);
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("door")) { // assuming the door has the tag "Door"
			Vector3 doorDirection = Vector3.zero;

			// 문 위치에 따라 이동 방향을 결정합니다.
			if (other.gameObject.name == "DoorU(Clone)") {
				doorDirection = Vector3.up;
                Debug.Log("up");
			} else if (other.gameObject.name == "DoorD(Clone)") {
				doorDirection = Vector3.down;
                Debug.Log("down");
			} else if (other.gameObject.name == "DoorL(Clone)") {
				doorDirection = Vector3.left;
                Debug.Log("Left");
			} else if (other.gameObject.name == "DoorR(Clone)") {
				doorDirection = Vector3.right;
                Debug.Log("Right");
			}

			// 플레이어 위치를 이동시킵니다.
            transform.position += new Vector3(doorDirection.x * moveJump.x, doorDirection.y * moveJump.y, 0);
            _camera.transform.position += new Vector3(doorDirection.x * moveJump.x, doorDirection.y * moveJump.y, 0);
            // 카메라 이동 필요
			// 필요한 경우 여기서 추가적인 맵 로딩 로직을 수행할 수 있습니다.
		}
    }
}
