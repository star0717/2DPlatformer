using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ���� ������ �� �ʿ�

public class ChangeScene02 : MonoBehaviour
{
    public string sceneName; //�ҷ��� ��


    //�� �ҷ�����
    public void Load()
    {
        SceneManager.LoadScene(sceneName);
    }
}
