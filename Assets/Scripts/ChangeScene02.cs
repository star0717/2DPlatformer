using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // 씬을 변경할 때 필요

public class ChangeScene02 : MonoBehaviour
{
    public string sceneName; //불러울 씬


    //씬 불러오기
    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }
}
