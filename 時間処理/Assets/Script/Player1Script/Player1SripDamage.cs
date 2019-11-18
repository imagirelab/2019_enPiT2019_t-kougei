using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1SripDamage : MonoBehaviour
{
    //テキストに表示
    public Text scoreText = null;
    //ライフの初期値
    //float life = 8000;
    //仮ダメージ
    float damage = 2000;
    //間隔の速さ
    float interval = 1;

    void Start()
    {
        //ToStringでString型にしてテキストに表示
        //scoreText.text = life.ToString();
    }

    //押したらライフが減少する
    public void OnDegScore()
    {
        //ダメージ 1fすすめる
        StartCoroutine(ScoreAnimation(damage, interval));
    }

    // ライフをアニメーションさせる
    IEnumerator ScoreAnimation(float DegScore, float time)
    {
        //前回のライフ
        //float befor = life;
        //今回のライフ
        //float after = life - DegScore;

        //得点加算
        //life -= DegScore;
        //0fを経過時間にする
        float elapsedTime = 0.0f;

        //ライフが０になるまでループさせる
        while (elapsedTime < time)
        {
            float rate = elapsedTime / time;
            // テキストの更新
            scoreText.text = (Player1DisplayLife.Instance.playerLife - DegScore * rate).ToString("f0");

            elapsedTime += Time.deltaTime;
            // 0.01秒待つ
            yield return new WaitForSeconds(0.01f);
        }
        // 最終的な着地のスコア
        Player1DisplayLife.Instance.playerLife -= DegScore;
        scoreText.text = Player1DisplayLife.Instance.playerLife.ToString();
    }
}