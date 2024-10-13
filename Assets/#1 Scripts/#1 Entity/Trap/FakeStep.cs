using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeStep : MonoBehaviour
{
    GameObject _player_obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _player_obj = other.gameObject;
            Debug.Log("이벤트 발생");
            StartCoroutine(DeBuff());
        }
    }

    IEnumerator DeBuff()
    {
        Player _player = _player_obj.GetComponent<Player>();
        _player.AddState(PlayerStates.IsDebuff);
        
        yield return new WaitForSeconds(5f);

        _player.RemoveState(PlayerStates.IsDebuff);

        yield return null;
    }
}
