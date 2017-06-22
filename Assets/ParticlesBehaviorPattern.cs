﻿using UnityEngine;
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
            main.startLifetime = .30f;
            main.startColor = Color.white;
            particleBurst.Play();
            beatCounter = (++beatCounter == 4 ? 0 : beatCounter);
        }
    }
}