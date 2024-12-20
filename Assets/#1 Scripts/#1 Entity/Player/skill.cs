using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    Collider2D _KickCollider;
    Player _player;
    public float KickForce = 100f; // 추가할 힘의 크기
    public Vector2 forceDirection = Vector2.up; // 힘을 가할 방향
    void Start()
    {
        _KickCollider = GetComponent<Collider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _player = this.transform.parent.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!_player.IsContainState(PlayerStates.IsDie))
            {
                if(!_player.IsContainState(PlayerStates.IsDebuff)){
                    StartCoroutine(Kick());
                }
                else{
                    // 킥 불발 소리 재생
                    Debug.Log("응 안돼");
                }
            }
        }
        if (_player.IsContainState(PlayerStates.IsAttacking))
        {
            _KickCollider.enabled = true;
            _spriteRenderer.enabled = true;
        }
        else if(!_player.IsContainState(PlayerStates.IsAttacking))
        {
            _KickCollider.enabled = false;
            _spriteRenderer.enabled = false;
        }
    }

    IEnumerator Kick()
    {
        _player.AddState(PlayerStates.IsAttacking);
        yield return new WaitForSeconds(.3f);//발차는 시간 0.3초
        _player.RemoveState(PlayerStates.IsAttacking);
        yield return null;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "enemy")
        {
            Rigidbody2D rigid = other.gameObject.GetComponent<Rigidbody2D>();
            Vector2 direction = (other.transform.position - transform.position).normalized;

            rigid.AddForce(direction * KickForce, ForceMode2D.Impulse);  
            AudioManager.instance.PlaySFX(AudioManager.SFX_enum.Kick);
            // 법선 방향으로 enemy힘주기
        }
    }

}