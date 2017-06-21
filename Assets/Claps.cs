using UnityEngine;
using System.Collections;
using SynchronizerData;

public class Claps : MonoBehaviour
{

    private BeatObserver beatObserver;
    private ParticleSystem particleBurst;
    public bool playing;

    void Start()
    {
        beatObserver = GetComponent<BeatObserver>();
        particleBurst = GetComponent<ParticleSystem>();
        playing = true;
    }


    void Update()
    {
        if ((beatObserver.beatMask & BeatType.DownBeat) == BeatType.DownBeat)
        {
            Play();
        }
    }

    void Play()
    {
        if (playing)
            particleBurst.Play();
    }
}
