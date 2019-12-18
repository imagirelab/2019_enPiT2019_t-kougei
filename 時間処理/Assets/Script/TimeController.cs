using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    const float MIN_TIME_LIMIT = 0.1f;

    public float limit = 0;
    public delegate void FireMethod();
    public FireMethod effect = delegate () { };

    bool isActive = true;
    float seconds;

    void Start()
    {
        TimerErrorCheck();
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

    public void ShatDown()
    {
        seconds = 0;
        limit = MIN_TIME_LIMIT;
        isActive = false;
    }

    public void Pause()
    {
        isActive = false;
    }

    public void Resume()
    {
        isActive = true;
    }

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