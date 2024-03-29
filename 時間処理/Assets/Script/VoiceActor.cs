﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceActor : MonoBehaviour
{
    [SerializeField]
    float breath = 0.1f;

    bool isSpeaking = false;
    Stack<AudioClip> queue = new Stack<AudioClip>();
    AudioSource mouth;
    StopWatch timer;

    void Start()
    {
        mouth = gameObject.GetComponent<AudioSource>();
        timer = gameObject.AddComponent<StopWatch>();
        timer.ShatDown();
        timer.effect = Speak;
    }

    //ここに声を渡すと渡した順に喋ってくれます。
    public bool SpeakRequest(AudioClip voice)
    {
        queue.Push(voice);

        //まだ発声中か待機中のボイスがあるならキューに追加するだけ
        if (queue.Count > 1 || isSpeaking)
        {
            return false;
        }

        //特になんもなければそのまま喋る
        Speak();
    
        return true;
    }

    //キューされているセリフをすべて忘れます
    public void Forget()
    {
        queue.Clear();
    }

    //今のセリフの次にvoiceを喋ってくれます。fast=trueなら今のセリフを中断します。未実装。
    public void MastSpeak(AudioClip voice, bool fast)
    {

    }


    void Speak()
    {
        isSpeaking = false;

        //喋ることがないならなんもしない
        if(queue.Count==0)
        {
            timer.ShatDown();
            isSpeaking = false;
            return;
        }

        //喋る
        Debug.Log("speaking...");
        AudioClip next = queue.Pop();
        mouth.PlayOneShot(next);
        isSpeaking = true;

        //次の喋りのタイミングを設定する
        timer.ReUse(next.length + breath, Speak, true);
    }


}
