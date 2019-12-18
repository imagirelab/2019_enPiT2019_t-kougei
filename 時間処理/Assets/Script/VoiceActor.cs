using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceActor : MonoBehaviour
{
    Stack<AudioClip> queue;
    TimeController timer;
    AudioSource mouth;

    void Start()
    {
        mouth = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if(queue.Count>0)
        {

        }
    }
}
