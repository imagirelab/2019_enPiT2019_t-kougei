using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GayaSystem : MonoBehaviour
{
    TimeController TimeLimiter;

    private AudioSource Gays;

    // Start is called before the first frame update
    void Start()
    {
        //AudioSourceコンポーネントを取得し、変数に格納
        Gays = GetComponent<AudioSource>();

        TimeLimiter = gameObject.AddComponent<TimeController>();
        TimeLimiter.limit = 10;
        TimeLimiter.effect = hogehoge;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void hogehoge()
    {
        Debug.Log("hogehoge");
        Gays.PlayOneShot(Gays.clip);
    }
}
