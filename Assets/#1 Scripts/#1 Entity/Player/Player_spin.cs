using UnityEngine;

public class Player_spin : MonoBehaviour
{
    public float rotationSpeed = 5f;
    Player _player;
    void Start()
    {
        _player = GetComponent<Player>();
    }

    void Update()
    {
        if (!_player.IsContainState(PlayerStates.IsDie))
            RotateTowardsMouse();
    }

    void RotateTowardsMouse()
    {
        // 마우스의 월드 좌표 얻기
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Z축은 유지하기 위해 2D 평면에서의 방향 계산
        Vector2 direction = (mousePosition - transform.position).normalized;

        // 플레이어가 바라볼 각도 계산
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // 회전 적용
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
