using UnityEngine;
using System.Collections;
using SynchronizerData;

public class ParticlesBehaviorPattern : MonoBehaviour
{
    private BeatObserver beatObserver;
    private ParticleSystem particleBurst;

    private ParticleSystem.MainModule main;
    private int beatCounter;

    void Start()
    {
        beatObserver = GetComponent<BeatObserver>();
        particleBurst = GetComponent<ParticleSystem>();
        beatCounter = 0;
        main = particleBurst.main;
    }


    void Update()
    {
        if ((beatObserver.beatMask & BeatType.OnBeat) == BeatType.OnBeat)
        {
            if (beatCounter == 1)
            {
                main.startLifetime = .30f;
                main.startColor = Color.white;
                particleBurst.Play();
            }
            else if (beatCounter == 2)
            {
                main.startColor = Color.green;
                main.startLifetime = .5f;
                particleBurst.Play();
            }
            beatCounter = (++beatCounter == 4 ? 0 : beatCounter);
        }
    }
}
