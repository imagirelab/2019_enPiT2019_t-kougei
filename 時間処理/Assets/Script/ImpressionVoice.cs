using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpressionVoice : MonoBehaviour
{
    public AudioClip[] impressionVoice;
    VoiceActor actor;

    // Start is called before the first frame update
    void Start()
    {
        actor = gameObject.GetComponent<VoiceActor>();
    }

    public void Diff8000()
    {
        actor.SpeakRequest(impressionVoice[0]);
    }

    public void Diff6000()
    {
        actor.SpeakRequest(impressionVoice[1]);
    }

    public void Diff4000()
    {
        actor.SpeakRequest(impressionVoice[2]);
    }

    public void Diff2000()
    {
        actor.SpeakRequest(impressionVoice[3]);
    }
}
