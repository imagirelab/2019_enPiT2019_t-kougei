using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GayaSystem : MonoBehaviour
{
    TimeController TimeLimiter;

    private AudioSource Gays;

    public List<AudioClip> gaya;

    // Start is called before the first frame update
    void Start()
    {
        //AudioSourceコンポーネントを取得し、変数に格納
        Gays = GetComponent<AudioSource>();

        TimeLimiter = gameObject.AddComponent<TimeController>();
        TimeLimiter.limit = 10;
        TimeLimiter.effect = PlayGaya;
    }

    void PlayGaya()
    {
        Gays.PlayOneShot(gaya[Random.Range(0,gaya.Count-1)]);
    }

    public void TimerReset()
    {
        TimeLimiter.ResetTimer();
    }
}
