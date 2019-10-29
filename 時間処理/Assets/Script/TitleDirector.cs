using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleDirector: MonoBehaviour
{
    public TitleVoiceSelector TVS;
    //　スタートボタンを押したら実行する
    public void StartGame()
    {
        TVS.OnClick();
        Invoke("start_game", TVS.playClip_length());
    }

    void start_game()
    {
        SceneManager.LoadScene("SampleScene");
    }
}