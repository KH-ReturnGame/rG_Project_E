using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject WhereToGo;
    bool IsBoom = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, WhereToGo.transform.position, 0.05f);
        
        if(Vector3.Distance(transform.position, WhereToGo.transform.position) < 0.1f)
        {
            StartCoroutine(BOOOM());
        }
    }

    IEnumerator BOOOM()
    {
        IsBoom = true;
        CapsuleCollider2D tr = GetComponent<CapsuleCollider2D>();
        tr.enabled = true;
        yield return new WaitForSeconds(1.5f);
        
        Destroy(transform.parent.gameObject);
        yield return null;
    }
}
