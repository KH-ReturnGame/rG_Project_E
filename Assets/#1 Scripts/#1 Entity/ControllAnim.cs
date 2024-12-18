using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllAnim : MonoBehaviour
{
    public GameObject FrontObj;
    public GameObject BackObj;
    public GameObject SideObj;
    Animator EnabledAnim;
    Animator FrontAnim;
    Animator BackAnim;
    Animator SideAnim;
    Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        FrontAnim = FrontObj.GetComponent<Animator>();
        BackAnim = BackObj.GetComponent<Animator>();
        SideAnim = SideObj.GetComponent<Animator>();
        //playerPos = 뭐시기 뭐 우진이가 짠 무브에서 가져와야징;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Mathf.Abs(playerPos.position.x - transform.position.x);
        float deltaY = Mathf.Abs(playerPos.position.y - transform.position.y);
        if(playerPos.position.x > transform.position.x && playerPos.position.y > transform.position.y)
        {
            if(deltaX > deltaY)
            {
                FrontAnim.enabled = false;
                BackAnim.enabled = false;
                SideAnim.enabled = true;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                FrontAnim.enabled = false;
                BackAnim.enabled = true;
                SideAnim.enabled = false;
            }
        }
        else if(playerPos.position.x > transform.position.x && playerPos.position.y < transform.position.y)
        {
            if(deltaX > deltaY)
            {
                FrontAnim.enabled = false;
                BackAnim.enabled = false;
                SideAnim.enabled = true;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                FrontAnim.enabled = true;
                BackAnim.enabled = false;
                SideAnim.enabled = false;
            }
        }
        else if(playerPos.position.x < transform.position.x && playerPos.position.y > transform.position.y)
        {
            if(deltaX > deltaY)
            {
                FrontAnim.enabled = false;
                BackAnim.enabled = false;
                SideAnim.enabled = true;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                FrontAnim.enabled = false;
                BackAnim.enabled = true;
                SideAnim.enabled = false;
            }
        }
        else if(playerPos.position.x < transform.position.x && playerPos.position.y < transform.position.y)
        {
            if(deltaX > deltaY)
            {
                FrontAnim.enabled = false;
                BackAnim.enabled = false;
                SideAnim.enabled = true;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                FrontAnim.enabled = true;
                BackAnim.enabled = false;
                SideAnim.enabled = false;
            }
        }
    }
}
