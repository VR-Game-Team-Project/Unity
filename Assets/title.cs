using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour
{
    public string sceneName = "MainScene"; // 게임화면 이름을 gamestage에

    public void ClickStart()// 마우스 >> oculus
    {
        Debug.Log("로딩"); // 확인
        SceneManager.LoadScene(sceneName);
    }

    /*public void ClickSetting()
    {
        Debug.Log("세팅");
        //미구현
    }

    public void ClickExit()
    {
        Debug.Log("종료");
        Application.Quit();
    }*/
}