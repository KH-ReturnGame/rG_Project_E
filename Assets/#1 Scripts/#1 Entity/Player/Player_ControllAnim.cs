using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_ControllAnim : MonoBehaviour
{
    public GameObject FrontObj;
    public GameObject BackObj;
    public GameObject SideObj;
    private Animator EnabledAnim;
    private Animator FrontAnim;
    private Animator BackAnim;
    private Animator SideAnim;

    // Start is called before the first frame update
    void Start()
    {
        FrontAnim = FrontObj.GetComponent<Animator>();
        BackAnim = BackObj.GetComponent<Animator>();
        SideAnim = SideObj.GetComponent<Animator>();
        EnabledAnim = FrontAnim;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            SetActiveState(false, false, true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            EnabledAnim = SideAnim;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            SetActiveState(false, false, true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            EnabledAnim = SideAnim;
        }
        
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            SetActiveState(false, true, false);
            EnabledAnim = BackAnim;
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            SetActiveState(true, false, false);
            EnabledAnim = FrontAnim;
        }

        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            EnabledAnim.SetBool("Walk", true);
        }
        else
        {
            EnabledAnim.SetBool("Walk", false);
        }
    }

    void SetActiveState(bool front, bool back, bool side)
    {
        FrontObj.SetActive(front);
        BackObj.SetActive(back);
        SideObj.SetActive(side);
    }
}