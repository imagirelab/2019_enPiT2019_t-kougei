using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serifgg : MonoBehaviour
{

    TimeController TimeLimiter;

    public AudioClip Serif01;
    public AudioClip Serif02;
    private AudioSource AudioContorole;
 

    // Start is called before the first frame update
    void Start()
    {
        TimeLimiter = gameObject.AddComponent<TimeController>();
        TimeLimiter.limit = 6;
        TimeLimiter.effect = Serif;
        AudioContorole = gameObject.AddComponent<AudioSource>();
        AudioContorole.clip = Serif01;
    }

    // Update is called once per frame
    void Serif()
    {
        Debug.Log("セリフが呼ばれました");
        AudioContorole.PlayOneShot(AudioContorole.clip);

        AudioContorole.clip = Serif02;
        TimeLimiter.limit = AudioContorole.clip.length;
        TimeLimiter.ResetTimer();
        TimeLimiter.effect = serif2;
    }

    void serif2()
    {
        Debug.Log("セリフが呼ばれました");
        AudioContorole.PlayOneShot(AudioContorole.clip);
        Destroy(TimeLimiter);
    }
}
