using UnityEngine;
using System.Collections;
using SynchronizerData;

public class Marimbas : MonoBehaviour
{
    private BeatObserver beatObserver;
    private ParticleSystem particleBurst;

    private ParticleSystem.MainModule main;
    private int beatCounter;
    public Light left;
    public Light right;

    public bool playing;

    private bool rightTurn = false;
    public float totalSeconds = 0.1f;     // The total of seconds the flash wil last
    public float maxIntensity = 1f;     // The maximum intensity the flash will reach
    private IEnumerator coroutine;

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
                ChangeColor(Color.yellow);
            else if (beatCounter == 11)
                ChangeColor(Color.cyan);
            else if (beatCounter == 17)
                ChangeColor(Color.yellow);
            else if (beatCounter == 0)
                ChangeColor(Color.magenta);
            else if (beatCounter == 1)
                ChangeColor(Color.red);

            if (beatCounter != 10 && beatCounter != 19)
                Play();
            beatCounter = (++beatCounter == 20 ? 0 : beatCounter);
        }
    }

    void ChangeColor(Color color)
    {
        left.color = color;
        right.color = color;
    }

    void Play()
    {
        if (playing)
        {
            if (rightTurn)
                coroutine = flashNow(right);
            else
                coroutine = flashNow(left);
            rightTurn = !rightTurn;
            StartCoroutine(coroutine);
            //particleBurst.Play();
        }
    }

    public IEnumerator flashNow(Light myLight)
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