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
    public float totalSeconds = 0.1f;     // The total of seconds the flash wil last
    public float maxIntensity = 1f;     // The maximum intensity the flash will reach
    private Light myLight;        // Your light
    private IEnumerator coroutine;

    void Start()
    {
        beatObserver = GetComponent<BeatObserver>();
        particleBurst = GetComponent<ParticleSystem>();
        myLight = GetComponent<Light>();
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
                myLight.color = Color.yellow;
            else if (beatCounter == 2)
                myLight.color = Color.cyan;
            else if (beatCounter == 41)
                myLight.color = Color.magenta;
            Play();
            beatCounter = (++beatCounter == 43 ? 0 : beatCounter);
        }
    }

    void Play()
    {
        if (playing)
        {
            coroutine = flashNow();
            StartCoroutine(coroutine);
        }
        //particleBurst.Play();
    }


    public IEnumerator flashNow()
    {
        float waitTime = totalSeconds / 2;
        // Get half of the seconds (One half to get brighter and one to get darker)
        while (myLight.intensity < maxIntensity)
        {
            myLight.intensity += Time.deltaTime / waitTime;        // Increase intensity
            yield return null;
        }
        while (myLight.intensity > 0)
        {
            myLight.intensity -= Time.deltaTime / waitTime;        //Decrease intensity
            yield return null;
        }
        yield return null;
    }
}