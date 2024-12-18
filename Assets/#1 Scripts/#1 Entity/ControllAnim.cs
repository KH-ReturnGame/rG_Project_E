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
        
    }
}
