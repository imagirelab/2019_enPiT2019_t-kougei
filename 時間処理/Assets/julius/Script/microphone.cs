using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class microphone : MonoBehaviour
{

    public float vol = 0f;
    public float[] spectrum;
    public float max = 1f;
    public float min = 1f;
    private mic_debug debug_text;

    private float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        GetComponent<AudioSource>().GetOutputData(data, 0);

        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }

        return a / 256;
    }

    // Use this for initialization
    void Start()
    {
        GetComponent<AudioSource>().clip = Microphone.Start(null, true, 999, 44100);  // マイクからのAudio-InをAudioSourceに流す
        GetComponent<AudioSource>().loop = true;                                      // ループ再生にしておく
        //GetComponent<AudioSource>().mute = true;                                      // マイクからの入力音なので音を流す必要がない
        while (!(Microphone.GetPosition("") > 0)) { }             // マイクが取れるまで待つ。空文字でデフォルトのマイクを探してくれる
        GetComponent<AudioSource>().Play();

        spectrum = new float[1024];

        debug_text = GetComponentInChildren<mic_debug>();
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
        vol = GetAveragedVolume();

        if (vol > max)
        {
            max = vol;
        }
        if (vol < min)
        {
            min = vol;
        }
    }
}
