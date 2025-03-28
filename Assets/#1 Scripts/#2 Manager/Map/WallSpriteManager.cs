using UnityEngine;

public class WallSpriteManager : MonoBehaviour
{
    public Sprite wallTile;
    public Sprite wallTileDown;    
    public Sprite wallCorner_DL;
    public Sprite wallCorner_DR;
    public Sprite wallCorner_UL;
    public Sprite wallCorner_UR;
    public Sprite wallSide;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateWallSprite();
    }

    void UpdateWallSprite()
    {
        bool up = CheckWall(Vector2.up);
        bool down = CheckWall(Vector2.down);
        bool left = CheckWall(Vector2.left);
        bool right = CheckWall(Vector2.right);
        bool up_down = CheckUpWall(Vector2.up);

        if ((up && left))
        {
            spriteRenderer.sprite = wallCorner_UL;  // 모퉁이일 경우
        }
        else if((up && right))
        {
            spriteRenderer.sprite = wallCorner_UR;  // 모퉁이일 경우
        }
        else if((down && left))
        {
            spriteRenderer.sprite = wallCorner_DL;  // 모퉁이일 경dn
        }
        else if((down && right))
        {
            spriteRenderer.sprite = wallCorner_DR;  // 모퉁이일 경우
        }
        else if (up && down && !right && !left)
        {
            spriteRenderer.sprite = wallSide;
        }
        else if(!up && !down && right && left)
        { 
            if(up_down)
            {
                spriteRenderer.sprite = wallTileDown;
            }
            else
            {
                spriteRenderer.sprite = wallTile;  // 기본 타일
            }
        }
    }

    void Update()
    {
        bool updown_check = CheckUpWall(Vector2.up);
        Debug.DrawRay(transform.position + Vector3.up * 2f, Vector2.up * 0.5f, Color.red);
        Debug.DrawRay(transform.position + Vector3.down * 2f, Vector2.down * 0.5f, Color.red);
        Debug.DrawRay(transform.position + Vector3.left * 2f, Vector2.left * 0.5f, Color.red);
        Debug.DrawRay(transform.position + Vector3.right * 2f, Vector2.right * 0.5f, Color.red);
        Debug.DrawRay(transform.position + Vector3.up * 2f, Vector2.up * 25f, Color.cyan);
        if(updown_check)
        {
            spriteRenderer.sprite = wallTileDown;
        }
    }

    bool CheckWall(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3)direction * 2f, direction, 0.5f, LayerMask.GetMask("Wall"));
        return hit.collider != null && hit.collider.gameObject != gameObject;
    }

    bool CheckUpWall(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3)direction * 2f, direction, 25f, LayerMask.GetMask("Wall"));

        if (hit.collider == null || hit.collider.gameObject == gameObject)
            return false; // Raycast가 아무것도 맞추지 않았거나 자기 자신일 경우

        SpriteRenderer _hitsprite = hit.collider.gameObject.GetComponent<SpriteRenderer>();
        if (_hitsprite == null)
            return false; // SpriteRenderer가 없을 경우

        return _hitsprite.sprite == wallTile; // 타일 스프라이트가 wallTileDown과 같은지 확인
    }
}