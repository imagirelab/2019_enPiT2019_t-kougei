using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageVoice : MonoBehaviour
{
    public AudioClip[] damageVoice;
    VoiceActor actor;

    void Start()
    {
        actor = gameObject.GetComponent<VoiceActor>();
    }

    // Update is called once per frame
    public void DamageVoiceSelector(int damage)
    {
        if (damage >= 4000)
        {
            actor.SpeakRequest(damageVoice[0]);
        }
        else if(damage < 4000)
        {
            actor.SpeakRequest(damageVoice[1]);
        }
    }
}
