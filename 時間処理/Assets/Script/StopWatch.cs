using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch : MonoBehaviour
{
    //使用される特殊な型の宣言
    public delegate void FireMethod();

    //定数
    const float MIN_TIME_LIMIT = 0.1f;
    FireMethod NoEffect = delegate () { };

    //設定する必要のある値
    public float limit = MIN_TIME_LIMIT;
    public FireMethod effect;
    
    //ステータス
    bool isActive = true;
    float seconds;

    void Start()
    {
        TimerErrorCheck();
        effect = NoEffect;
    }

    void Update()
    {
        if (!isActive) return;

        seconds += Time.deltaTime;

        if (seconds >= limit)
        {
            TimerErrorCheck();

            seconds = 0;
            effect();
        }
    }

    
    public void ResetTimer()
    {
        seconds = 0;
    }

    public void ResetTimer(float newlimit)
    {
        seconds = 0;

        if (TimerErrorCheck()) return;

        limit = newlimit;
    }

    //タイマーをしまいます。設定は保存されません。
    public void ShatDown()
    {
        seconds = 0;
        limit = MIN_TIME_LIMIT;
        effect = NoEffect;
        isActive = false;
    }

    //シャットダウンしたタイマーを再度利用します。
    public void ReUse(float Limit, FireMethod Effect, bool start = false)
    {
        limit = Limit;
        effect = Effect;
        isActive = start;
    }

    public void Pause()
    {
        isActive = false;
    }

    public void Resume()
    {
        isActive = true;
    }

    //制限時間が小さすぎるのは明らかに異常なので勝手に直します。
    bool TimerErrorCheck()
    {
        if(limit<MIN_TIME_LIMIT)
        {
            Debug.Log("too short time limit. does not set?");
            limit = MIN_TIME_LIMIT;

            return true;
        }

        return false;
    }
}