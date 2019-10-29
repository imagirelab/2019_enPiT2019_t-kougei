using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleVoiceSelector : MonoBehaviour
{
    public AudioClip[] titleVoice;
    AudioSource luncher;
    int rand;

    void Start()
    {
        luncher = gameObject.AddComponent<AudioSource>();
        
        rand = UnityEngine.Random.Range(0, 4);
    }

    // Update is called once per frame
    public void OnClick()
    {
        luncher.PlayOneShot(titleVoice[rand]);
    }

    public float playClip_length()
    {
        return titleVoice[rand].length;
    }
}
