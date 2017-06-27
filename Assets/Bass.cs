using UnityEngine;
using System.Collections;
using SynchronizerData;

public class Bass : MonoBehaviour
{
    private BeatObserver beatObserver;

    private int beatCounter;

    public bool playing;
    public float totalSeconds = 0.1f;     // The total of seconds the flash wil last
    public float maxIntensity = 1f;     // The maximum intensity the flash will reach
    private Light myLight;        // Your light
    private IEnumerator coroutine;
    private bool firstBeat;
    private float size;
    public float maxSize = 5f;
    void Start()
    {
        beatObserver = GetComponent<BeatObserver>();
        myLight = GetComponent<Light>();
        beatCounter = 0;
        playing = true;
        firstBeat = true;
        size = 2f;
    }


    void Update()
    {
        if ((beatObserver.beatMask & BeatType.OnBeat) == BeatType.OnBeat)
        {
            if (beatCounter == 24)
                myLight.color = Color.yellow;
            else if (beatCounter == 1)
                myLight.color = Color.cyan;
            else if (beatCounter == 42)
                myLight.color = Color.magenta;
            if (beatCounter != 9 && beatCounter != 20 && beatCounter != 31)
                Play();
            beatCounter++;
            if (beatCounter > 42)
                beatCounter = 0;
        }
        // Rotate the object around its local X axis at 1 degree per second
        transform.Rotate(Vector3.right * Time.deltaTime * 5);

        // ...also rotate around the World's Y axis
        transform.Rotate(Vector3.up * Time.deltaTime * 5);
    }

    public void End()
    {
        myLight.color = Color.cyan;
    }

    void Play()
    {
        if (playing)
        {
            if (!firstBeat)
            {
                StopAllCoroutines();
                size = 2f;
                //myLight.intensity = 0;
                transform.localScale = new Vector3(2, 2, 2);

                coroutine = pulse();
                StartCoroutine(coroutine);
            }
            else
                firstBeat = false;
        }
    }

    public IEnumerator pulse()
    {
        float waitTime = totalSeconds / 2;

        // Get half of the seconds (One half to get brighter and one to get darker)
        while (size < maxSize)
        {
            size += Time.deltaTime / waitTime;        // Increase intensity
            myLight.range = size + .5f;
            transform.localScale = new Vector3(size, size, size);
            yield return null;
        }
        while (size > 2)
        {
            size -= Time.deltaTime / waitTime;        //Decrease intensity
            myLight.range = size + .5f;
            transform.localScale = new Vector3(size, size, size);
            yield return null;
        }
        yield return null;
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