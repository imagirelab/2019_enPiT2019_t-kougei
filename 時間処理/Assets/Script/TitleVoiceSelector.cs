using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleVoiceSelector : MonoBehaviour
{
    const int TITLE_VOICE_COUNT = 4;
    public AudioClip[] titleVoice;
    AudioSource luncher;
    int voice_id;

    void Start()
    {
        luncher = gameObject.AddComponent<AudioSource>();

        voice_id = UnityEngine.Random.Range(0, TITLE_VOICE_COUNT);
    }

    // Update is called once per frame
    public void OnClick()
    {
        luncher.PlayOneShot(titleVoice[voice_id]);
    }

    public float playClip_length()
    {
        return titleVoice[voice_id].length;
    }
}
