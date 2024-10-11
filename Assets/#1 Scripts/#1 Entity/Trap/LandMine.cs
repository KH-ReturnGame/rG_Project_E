using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMine : MonoBehaviour // 삥! 하면서 빛나고 지뢰 활성화
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ActiveLandMine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ActiveLandMine()
    {
        yield return null;
    }
}
