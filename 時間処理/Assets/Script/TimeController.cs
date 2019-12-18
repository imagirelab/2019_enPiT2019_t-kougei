using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float limit = 10;
    public delegate void FireMethod();
    public FireMethod effect = delegate () { };

    bool isActive = true;
    float seconds;

    void Update()
    {
        if (!isActive) return;

        seconds += Time.deltaTime;

        if (seconds >= limit)
        {
            seconds = 0;
            Debug.Log(limit + "秒間何もアクションされませんでした");
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
        limit = newlimit;
    }

    public void Pause()
    {
        isActive = false;
    }

    public void Resume()
    {
        isActive = true;
    }
}