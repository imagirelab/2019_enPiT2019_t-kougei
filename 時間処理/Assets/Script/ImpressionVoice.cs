using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpressionVoice : MonoBehaviour
{
    public AudioClip[] impressionVoice;
    AudioSource luncher;

    // Start is called before the first frame update
    void Start()
    {
        luncher = gameObject.AddComponent<AudioSource>();
    }

    public void Diff8000()
    {
        luncher.PlayOneShot(impressionVoice[0]);
    }

    public void Diff6000()
    {
        luncher.PlayOneShot(impressionVoice[1]);
    }

    public void Diff4000()
    {
        luncher.PlayOneShot(impressionVoice[2]);
    }

    public void Diff2000()
    {
        luncher.PlayOneShot(impressionVoice[3]);
    }
}
