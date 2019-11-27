using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float limit = 10;
    float seconds;
    public delegate void FireMethod();
    public FireMethod effect;

    void Update()
    {
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

}

















