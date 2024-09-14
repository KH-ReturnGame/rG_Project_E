using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float duration;
    private int arrowType;
    private float LaunchSpeed;
    // Start is called before the first frame update
    void Start()
    {
        LaunchSpeed = 0.25f;
        StartCoroutine(DestroyArrow());
    }

    // Update is called once per frame
    void Update()
    {
        switch (arrowType)
        {
            case 1:
                transform.position = new Vector2 (transform.position.x + LaunchSpeed, transform.position.y);
                break;
            case 2:
                transform.position = new Vector2 (transform.position.x - LaunchSpeed, transform.position.y);
                break;
            case 3:
                transform.position = new Vector2 (transform.position.x, transform.position.y - LaunchSpeed);
                break;
            case 4:
                transform.position = new Vector2 (transform.position.x, transform.position.y + LaunchSpeed);
                break;
            default:
                break;
        }
    }

    IEnumerator DestroyArrow()
    {
        yield return new WaitForSeconds(duration);
        Destroy(this.gameObject);
    }

    public void ChangeType(int i)
    {
       arrowType = i;
    }
}
