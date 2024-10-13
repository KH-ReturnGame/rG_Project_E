using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLauncher : MonoBehaviour
{
    public GameObject Arrow;
    public float cooldown;
    public int type; // 1 : 동, 2 : 서, 3 : 남, 4 : 북
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
        GameObject ArrowObj = Object.Instantiate(Arrow, transform.position, Quaternion.identity);
        Arrow _arrow = ArrowObj.GetComponent<Arrow>();
        switch (type)
        {
            case 1: // 동 (East)
                ArrowObj.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case 2: // 서 (West)
                ArrowObj.transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case 3: // 남 (South)
                ArrowObj.transform.rotation = Quaternion.Euler(0, 0, -90);
                break;
            case 4: // 북 (North)
                ArrowObj.transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            default:
                Debug.Log("Invalid direction type");
                break;
        }
        _arrow.ChangeType(type);

        yield return new WaitForSeconds(cooldown); // 쿨다운

        StartCoroutine(LaunchArrow());
    }
}
