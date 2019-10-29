using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GayaSystem : MonoBehaviour
{
    TimeController TimeLimiter;

    private AudioSource sound01;

    // Start is called before the first frame update
    void Start()
    {
        TimeLimiter = gameObject.AddComponent<TimeController>();
        TimeLimiter.limit = 6;
        TimeLimiter.effect = hogehoge;
        //AudioSourceコンポーネントを取得し、変数に格納
        sound01 = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void hogehoge()
    {
        Debug.Log("hogehoge");
        sound01.PlayOneShot(sound01.clip);
    }
}
