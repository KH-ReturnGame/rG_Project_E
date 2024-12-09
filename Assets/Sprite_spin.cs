using UnityEngine;

public class Sprite_spin : MonoBehaviour
{
    public float rotationSpeed = 30000f;

    void Update()
    {
        // Z축을 기준으로 회전
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
