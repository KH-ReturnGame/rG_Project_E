using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoorOn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        if(other.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }
    
    IEnumerator DoorOn()
    {
        SpriteRenderer DoorSprite = GetComponent<SpriteRenderer>();
        BoxCollider2D DoorCollider = GetComponent<BoxCollider2D>();

        DoorSprite.enabled = true;
        DoorCollider.enabled = true;

        float cool = Random.Range(2.5f, 7.5f);

        yield return new WaitForSeconds(cool);

        StartCoroutine(DoorOff());
        
        yield return null;
    }

    IEnumerator DoorOff()
    {
        SpriteRenderer DoorSprite = GetComponent<SpriteRenderer>();
        BoxCollider2D DoorCollider = GetComponent<BoxCollider2D>();

        DoorSprite.enabled = false;
        DoorCollider.enabled = false;
        
        float cool = Random.Range(2.5f, 5f);

        yield return new WaitForSeconds(cool);

        StartCoroutine(DoorOn());

        yield return null;
    }
}
