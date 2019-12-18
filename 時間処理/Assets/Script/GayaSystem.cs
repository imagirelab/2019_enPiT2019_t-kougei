using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FantomLib
{
    public class GayaSystem : MonoBehaviour
    {
        public LifePoint PL1;
        public LifePoint PL2;
        public VoiceSelector selector;
        public VoiceActor actor;

        StopWatch TimeLimiter;
        AudioSource Gays;
        List<AudioClip> gaya;

        // Start is called before the first frame update
        void Start()
        {
            //AudioSourceコンポーネントを取得し、変数に格納
            Gays = GetComponent<AudioSource>();
            selector = gameObject.GetComponent<VoiceSelector>();
            actor = gameObject.GetComponent<VoiceActor>();
            //TimeLimiter = gameObject.AddComponent<TimeController>();
            //TimeLimiter.limit = 10;
            //TimeLimiter.effect = PlayGaya;
        }

        public void PlayGaya()
        {
            gaya = selector.SelectVoiceList(PL1.getLP(), PL2.getLP());

            actor.SpeakRequest(gaya[Random.Range(0, gaya.Count)]);
        }

        public void TimerReset()
        {
            TimeLimiter.ResetTimer();
        }
    }
}