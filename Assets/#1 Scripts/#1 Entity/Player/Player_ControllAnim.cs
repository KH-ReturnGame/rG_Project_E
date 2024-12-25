using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ControllAnim : MonoBehaviour
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
                FrontObj.SetActive(false);
                BackObj.SetActive(false);
                SideObj.SetActive(true);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                EnabledAnim = SideAnim;
            }
            else
            {
                FrontObj.SetActive(false);
                BackObj.SetActive(true);
                SideObj.SetActive(false);
                EnabledAnim = BackAnim;
            }
        }
        else if(playerPos.position.x > transform.position.x && playerPos.position.y < transform.position.y)
        {
            if(deltaX > deltaY)
            {
                FrontObj.SetActive(false);
                BackObj.SetActive(false);
                SideObj.SetActive(true);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                EnabledAnim = SideAnim;
            }
            else
            {
                FrontObj.SetActive(true);
                BackObj.SetActive(false);
                SideObj.SetActive(false);
                EnabledAnim = FrontAnim;
            }
        }
        else if(playerPos.position.x < transform.position.x && playerPos.position.y > transform.position.y)
        {
            if(deltaX > deltaY)
            {
                FrontObj.SetActive(false);
                BackObj.SetActive(false);
                SideObj.SetActive(true);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                EnabledAnim = SideAnim;
            }
            else
            {
                FrontObj.SetActive(false);
                BackObj.SetActive(true);
                SideObj.SetActive(false);
                EnabledAnim = BackAnim;
            }
        }
        else if(playerPos.position.x < transform.position.x && playerPos.position.y < transform.position.y)
        {
            if(deltaX > deltaY)
            {
                FrontObj.SetActive(false);
                BackObj.SetActive(false);
                SideObj.SetActive(true);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                EnabledAnim = SideAnim;
            }
            else
            {
                FrontObj.SetActive(true);
                BackObj.SetActive(false);
                SideObj.SetActive(false);
                EnabledAnim = FrontAnim;
            }
        }
    }
}
