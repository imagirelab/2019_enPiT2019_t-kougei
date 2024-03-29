﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePoint : MonoBehaviour
{
    public LifeDifferenceJudgment LDJ;
    public Text text;

    public DamageVoice DV;
    public AudioClip damageSE;
    
    public int initial_life = 8000;
    public int life;
    int view_life; //表示用
    bool flag = false;
    AudioSource speaker;

    // Start is called before the first frame update
    void Start()
    {
        speaker = gameObject.AddComponent<AudioSource>();
        life = initial_life;
        view_life = life;
        text.text = view_life.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (life < view_life)
        {
            view_life -= 25;
            if (view_life < life) view_life = life;// 引きすぎたら戻す
            text.text = view_life.ToString();
        }

        else if(life>view_life)
        {
            view_life += 25;
            if (view_life > life) view_life = life;// 足しすぎたら戻す
            text.text = view_life.ToString();
        }
        if(view_life <= 0 && !flag)
        {
            Debug.Log("ライフが0になりました");
            LDJ.LifeDiffJudge();
            flag = true;
        }
        
    }

    public void Damage(int amount)
    {
        life -= amount;
        DV.DamageVoiceSelector(amount);
        speaker.PlayOneShot(damageSE);
    }

    public void SetLP(int LP)
    {
        life = LP;   
    }

    public int getLP()
    {
        return life;
    }
}
