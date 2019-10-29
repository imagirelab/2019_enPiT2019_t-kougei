using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    float seconds;

    void Update()
    {

        seconds += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enterが押されました");
            Debug.Log("時間をリセットします");
        }

        if (seconds >= 10)
        {
            seconds = 0;
            Debug.Log("10秒間何もアクションされませんでした");
        }
    }
}

















