using UnityEngine;
using System.Collections;
using SynchronizerData;

public class Marimbas : MonoBehaviour
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
            if (beatCounter == 8)
                main.startColor = Color.yellow;
            else if (beatCounter == 11)
                main.startColor = Color.cyan;
            else if (beatCounter == 17)
                main.startColor = Color.yellow;
            else if (beatCounter == 0)
                main.startColor = Color.magenta;
            else if (beatCounter == 1)
                main.startColor = Color.red;

            if (beatCounter != 10 || beatCounter != 19)
                Play();
            beatCounter = (++beatCounter == 20 ? 0 : beatCounter);
        }
    }

    void Play()
    {
        if (playing)
            particleBurst.Play();
    }
}