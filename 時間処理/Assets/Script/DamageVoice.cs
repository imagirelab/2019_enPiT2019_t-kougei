using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageVoice : MonoBehaviour
{
    public AudioClip[] damageVoice;
    AudioSource luncher;

    void Start()
    {
        luncher = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    public void DamageVoiceSelector(int damage)
    {
        if (damage >= 4000)
        {
            luncher.PlayOneShot(damageVoice[0]);
        }
        else if(damage < 4000)
        {
            luncher.PlayOneShot(damageVoice[1]);
        }
    }
}
