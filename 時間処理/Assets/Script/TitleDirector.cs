using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleDirector: MonoBehaviour
{
    public TitleVoiceSelector TVS;
    public Button StartButton;

    //　スタートボタンを押したら実行する
    public void StartGame()
    {
        StartButton.interactable = false;
        TVS.OnClick();
        Invoke("start_game", TVS.playClip_length());
    }

    void start_game()
    {
        SceneManager.LoadScene("MainScene");
    }
}