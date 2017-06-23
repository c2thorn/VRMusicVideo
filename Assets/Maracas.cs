using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SynchronizerData;

public class Maracas : MonoBehaviour
{
    private BeatObserver beatObserver;
    private ParticleSystem particleBurst;

    private ParticleSystem.MainModule main;
    private int beatCounter;

    public bool playing;

    void Start()
    {
        beatObserver = GetComponent<BeatObserver>();
        particleBurst = GetComponent<ParticleSystem>();
        beatCounter = 0;
        main = particleBurst.main;
        playing = true;
    }


    void Update()
    {
        if ((beatObserver.beatMask & BeatType.OnBeat) == BeatType.OnBeat)
        {
            if (beatCounter == 1)
            {
                main.startLifetime = .30f;
                main.startColor = Color.white;
                //Play();
            }
            else if (beatCounter == 2)
            {
                main.startColor = Color.green;
                main.startLifetime = .5f;
                //Play();
            }
            beatCounter = (++beatCounter == 4 ? 0 : beatCounter);
        }
    }

    void Play()
    {
        if (playing)
            particleBurst.Play();
    }
}
