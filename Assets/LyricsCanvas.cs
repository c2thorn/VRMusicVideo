using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LyricsCanvas : MonoBehaviour {
    public RectTransform myRect;
    public float maxHeight = 1.5f;
    public float maxWidth = 3f;
    private float myHeight;
    private float myWidth;
    public float totalSeconds = 5f;
    private IEnumerator coroutine;
    void Start () {
        myRect = GetComponent<RectTransform>();
        myWidth = maxWidth;
        myHeight = maxHeight;
	}

    public void Appear()
    {
        coroutine = grow();
        StartCoroutine(coroutine);
    }

    public void Disappear()
    {
        coroutine = shrink();
        StartCoroutine(coroutine);
    }

    public IEnumerator shrink()
    {
        float waitTime = totalSeconds / 2;

        // Get half of the seconds (One half to get brighter and one to get darker)
        while (myHeight > 0.1f)
        {
            myHeight -= Time.deltaTime / waitTime;
            myRect.sizeDelta = new Vector2(myWidth, myHeight);
            yield return null;
        }
        while (myWidth > 0)
        {
            myWidth -= Time.deltaTime / waitTime;
            myRect.sizeDelta = new Vector2(myWidth, myHeight);
            yield return null;
        }
        yield return null;
    }

    public IEnumerator grow()
    {
        float waitTime = totalSeconds / 2;

        // Get half of the seconds (One half to get brighter and one to get darker)
        while (myWidth < maxWidth)
        {
            myWidth += Time.deltaTime / waitTime;
            myRect.sizeDelta = new Vector2(myWidth, myHeight);
            yield return null;
        }
        while (myHeight < maxHeight)
        {
            myHeight += Time.deltaTime / waitTime;
            myRect.sizeDelta = new Vector2(myWidth, myHeight);
            yield return null;
        }

        yield return null;
    }
}
