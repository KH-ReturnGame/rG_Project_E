using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckAllDie : MonoBehaviour
{
    public GameObject[] gameObjects; // 게임 오브젝트 배열

    void Update()
    {
        CheckIfAllNull();
    }

    void CheckIfAllNull()
    {
        bool allNull = true; // 모든 요소가 null인지 체크하는 변수

        for (int i = 0; i < gameObjects.Length; i++)
        {
            if (gameObjects[i] != null)
            {
                allNull = false;
                break;
            }
        }

        if (allNull)
        {
            SceneManager.LoadScene("End");
        }
        else
        {
            Debug.Log("Not all game objects are null.");
        }
    }
}
