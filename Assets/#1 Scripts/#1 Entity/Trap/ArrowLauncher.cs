using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLauncher : MonoBehaviour
{
    public GameObject Arrow;
    public float cooldown;
    public int type; // 1 : 동, 2 : 서, 3 : 남, 4 : 북
    public LayerMask layerMask;
    private bool _check;
    // Start is called before the first frame update
    SpriteRenderer _spriteRenderer;
    public Sprite[] _Launchers;
    void Start()
    {
        StartCoroutine(LaunchArrow());
        _check = true;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_check)
        {
            CheckRaycasts();
        }
    }

    IEnumerator LaunchArrow()
    {
        GameObject ArrowObj = Object.Instantiate(Arrow, transform.position, Quaternion.identity);
        Arrow _arrow = ArrowObj.GetComponent<Arrow>();
        switch (type)
        {
            case 1: // 동 (East)
                ArrowObj.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 2: // 서 (West)
                ArrowObj.transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case 3: // 남 (South)
                ArrowObj.transform.rotation = Quaternion.Euler(0, 0, -90);
                break;
            case 4: // 북 (North)
                ArrowObj.transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            default:
                //Debug.Log("Invalid direction type");
                break;
        }
        _arrow.ChangeType(type);

        yield return new WaitForSeconds(cooldown); // 쿨다운

        StartCoroutine(LaunchArrow());
    }

    void CheckRaycasts()
    {
        // 상, 하, 좌, 우 방향 벡터
        Vector2[] directions = { Vector2.up, Vector2.down, Vector2.left, Vector2.right };

        foreach (var direction in directions)
        {
            // 레이캐스트를 특정 방향으로 쏨
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 4f, layerMask);

            if (hit.collider != null)
            {
                if (direction == Vector2.up)
                {
                    type = 3;
                    _spriteRenderer.sprite= _Launchers[2];
                    _check = false;
                }
                else if (direction == Vector2.down)
                {
                    type = 4;
                    _spriteRenderer.sprite = _Launchers[3];
                    _check = false;
                }
                else if (direction == Vector2.left)
                {
                    type = 1;
                    _spriteRenderer.sprite = _Launchers[0];
                    _check = false;
                }
                else if (direction == Vector2.right)
                {
                    type = 2;
                    _spriteRenderer.sprite = _Launchers[1];
                    _check = false;
                }
                else
                {
                    type = 1;
                    _spriteRenderer.sprite = _Launchers[0];
                    _check = false;
                }
            }
            Debug.DrawRay(transform.position, direction * 4f, Color.green);
        }
    }
}
