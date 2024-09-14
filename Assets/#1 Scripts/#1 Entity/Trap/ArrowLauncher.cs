using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLauncher : MonoBehaviour
{
    public GameObject Arrow;
    public float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LaunchArrow());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LaunchArrow()
    {
        GameObject.Instantiate(GameObject Arrow, Vector3 transform.position, Quternian rotation);
        return null;
    }
}
