using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceSelector : MonoBehaviour
{
    public List<AudioClip> normal;
    public List<AudioClip> panic;

    public List<AudioClip> SelectVoiceList(int LP1, int LP2)
    {
        if (isPanic(LP1, LP2))
        {
            return panic;
        }

        return normal;
    }

    bool isPanic(int LP1, int LP2)
    {
        return LP1 < 1000 && LP2 < 1000 && (Mathf.Abs(LP1 - LP2) < 500);
    }
}
