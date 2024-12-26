using System.Collections;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    // 플레이어
    private Rigidbody2D _playerRigid;
    private Player _player;
    private SpriteRenderer spriteRenderer;
    private Collider2D _playerCollider;
    public Transform _camTransform;
    public Transform _camborderTransform;

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
        GameObject camborder = GameObject.Find("Cam_Border");
        _camborderTransform = camborder.GetComponent<Transform>();

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
            if (!_player.IsContainState(PlayerStates.IsDie)
            && !_player.IsContainState(PlayerStates.IsDefencing))
                StartCoroutine(Dash());
        }
    }

    // 0.02초마다 실행
    void FixedUpdate()
    {
        if (_player.IsContainState(PlayerStates.IsDashing)) // 대시 중에는 기본 움직임 중지
            return;

        if (!_player.IsContainState(PlayerStates.IsDie) 
        && !_player.IsContainState(PlayerStates.IsDefencing))
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
        // 캔 대시 상태 제거
        _player.RemoveState(PlayerStates.CanDash);
        // 마우스 위치를 월드 좌표로 변환
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // 2D 게임에서는 Z 좌표 무시
    
        // 대시 방향 계산
        Vector2 dashDirection = (mousePosition - transform.position).normalized;
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
    void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("door")) { // assuming the door has the tag "Door"
			Vector3 doorDirection = Vector3.zero;

			// 문 위치에 따라 이동 방향을 결정합니다.
			if (other.gameObject.name == "DoorU(Clone)") {
				doorDirection = Vector3.up;
			} else if (other.gameObject.name == "DoorD(Clone)") {
				doorDirection = Vector3.down;
			} else if (other.gameObject.name == "DoorL(Clone)") {
				doorDirection = Vector3.left;
			} else if (other.gameObject.name == "DoorR(Clone)") {
				doorDirection = Vector3.right;
			}

			// 플레이어 위치를 이동시킵니다.
            transform.position += new Vector3(doorDirection.x * moveJump.x * 0.89f, doorDirection.y * moveJump.y * 0.905f, 0);
            _camborderTransform.position += new Vector3(doorDirection.x * moveJump.x, doorDirection.y * moveJump.y, 0);
            _camTransform.position = new Vector3(transform.position.x, transform.position.y, 0);
			// 필요한 경우 여기서 추가적인 맵 로딩 로직을 수행할 수 있습니다.

            LevelGeneration levelGenerator = GameObject.Find("MapManager").GetComponent<LevelGeneration>();
            
            MapSpriteSelector currentRoomMinimap = levelGenerator.minimaps.Find(m => m.type == 1);
            if (currentRoomMinimap != null) {
                currentRoomMinimap.type = 0;
                currentRoomMinimap.PickColor(); // 색상 업데이트
            }
            
            Vector3 miniMapOffset = CalculateMiniMapOffset();//미니맵 오프셋 조정
            Vector3 newRoomPos = miniMapOffset;

            // Debug.Log($"New Room Position: {newRoomPos}");

            // // 미니맵 상의 방 좌표 출력
            // foreach (var minimap in levelGenerator.minimaps) {
            //     Debug.Log($"Minimap Position: {minimap.transform.position}");
            // }

            MapSpriteSelector newRoomMinimap = levelGenerator.minimaps.Find(m => Vector3.Distance(m.transform.position, newRoomPos) < 20f);
            if (newRoomMinimap != null) {
                newRoomMinimap.type = 1;
                newRoomMinimap.PickColor(); // 색상 업데이트
            }
		}
    }
    Vector3 CalculateMiniMapOffset() {
        // Y 좌표 증가율 비율 200 -> 32, X 좌표 증가율 비율 400 -> 64
        float scaleFactor = 6.25f; // X와 Y 둘 다 같은 비율 적용
    
        // 월드 좌표를 미니맵 좌표로 변환
        return new Vector3(310 + _camTransform.position.x / scaleFactor, 950 + _camTransform.position.y / scaleFactor, 0);
    }

    IEnumerator PlayerSlow()
    {
        speed /= 2.5f;
        yield return new WaitForSeconds(2.5f);
        speed *= 2.5f;
    }

    public void Sparked()
    {
        StartCoroutine(PlayerSlow());
    }
}
