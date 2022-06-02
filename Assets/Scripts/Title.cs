using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    //메인 씬으로 이동
    public void LoadingNewScene()
    {
        SceneManager.LoadScene("SlimeKing");
    }

    //게임 나가기
    public void ExitGame()
    {
        Application.Quit();
    }
}

