using UnityEngine;
using System.Collections;
using SynchronizerData;

public class Bass : MonoBehaviour
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
        playing = true;
        main = particleBurst.main;

        main.startLifetime = .30f;
    }


    void Update()
    {
        if ((beatObserver.beatMask & BeatType.OnBeat) == BeatType.OnBeat)
        {
            if (beatCounter == 24)
                main.startColor = Color.yellow;
            else if (beatCounter == 2)
                main.startColor = Color.cyan;
            else if (beatCounter == 41)
                main.startColor = Color.magenta;
            Play();
            beatCounter = (++beatCounter == 43 ? 0 : beatCounter);
        }
    }

    void Play()
    {
        if (playing)
            particleBurst.Play();
    }
}