using UnityEngine;

public class WallSpriteManager : MonoBehaviour
{
    public Sprite wallTile;
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
            spriteRenderer.sprite = wallTile;  // 기본 타일
        }
    }

    void Update()
    {
        Debug.DrawRay(transform.position + Vector3.up * 2f, Vector2.up * 0.5f, Color.red);
        Debug.DrawRay(transform.position + Vector3.down * 2f, Vector2.down * 0.5f, Color.red);
        Debug.DrawRay(transform.position + Vector3.left * 2f, Vector2.left * 0.5f, Color.red);
        Debug.DrawRay(transform.position + Vector3.right * 2f, Vector2.right * 0.5f, Color.red);
    }

    bool CheckWall(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3)direction * 2f, direction, 0.5f, LayerMask.GetMask("Wall"));
        return hit.collider != null && hit.collider.gameObject != gameObject;
    }   
}
