using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSharon : MonoBehaviour
{
    bool IsPowerOn;
    public bool IsGreen;

    float cooldown;
    
    GameObject DetectRange;

    Rigidbody2D _playerRigid;

    public float SpeedThreshold = 0.1f; // 감지할 속도 임계값
    public float detectionRange = 5f;
    // Start is called before the first frame update
    void Start()
    {
        IsPowerOn = true;
        cooldown = Random.Range(2.5f, 5f);
        _playerRigid = GameObject.Find("player 1(Clone)").GetComponent<Rigidbody2D>();
        StartCoroutine(GreenLight());
    }

    // Update is called once per frame
    void Update()
    {
        if(IsPowerOn)
        {
            DetectMovement();
        }
    }

    IEnumerator RedLight()
    {
        // 애니메이터 바꾸기
        IsGreen = false;

        yield return new WaitForSeconds(1.5f);

        StartCoroutine(GreenLight());
    }

    IEnumerator GreenLight()
    {
        // 애니메이터 바꾸기
        IsGreen = true;
        yield return new WaitForSeconds(cooldown);

        cooldown = Random.Range(2.5f, 5f);

        StartCoroutine(RedLight());
    }

    void DetectMovement()
    {
        // 플레이어와 감지 영역 사이의 거리 계산
        float DetectionArea = Vector2.Distance(_playerRigid.transform.position, transform.position);

        // 플레이어가 감지 범위 내에 있는지 확인
        if (DetectionArea <= detectionRange)
        {
            // 플레이어의 속도 벡터를 사용하여 속도 크기 계산
            float playerSpeed = _playerRigid.velocity.magnitude;

            // 속도가 임계값을 넘으면 움직임이 감지된 것으로 처리
            if (playerSpeed > SpeedThreshold && !IsGreen)
            {
                Debug.Log("신호위반 시발련아");
                Player _player = GameObject.Find("player 1(Clone)").GetComponent<Player>();
                _player.AddState(PlayerStates.IsDie);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("kick"))
        {
            IsPowerOn = false;
            Debug.Log("정상화");
            StopCoroutine(GreenLight());
            StopCoroutine(RedLight());
        }
    }
}
