using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SynchronizerData;


public class SphereBehavior : MonoBehaviour {


    public Marimbas marimbas;
    public Maracas maracas;
    public Claps claps;
    public Bass bass;

    public Text text;

	public Vector3[] beatPositions;

	private BeatObserver beatObserver;
	private int beatCounter;
    public int totalBeats;

	void Start ()
	{
		beatObserver = GetComponent<BeatObserver>();
		beatCounter = 0;
        totalBeats = 0;
	}

	void Update ()
	{
		if ((beatObserver.beatMask & BeatType.OnBeat) == BeatType.OnBeat) {
			transform.position = beatPositions[beatCounter];
			beatCounter = (++beatCounter == beatPositions.Length ? 0 : beatCounter);
            UpdateTotalBeats();
		}
	}

    void UpdateTotalBeats()
    {
        text.text = totalBeats+"";

        switch (totalBeats)
        {
            case 0:
                maracas.playing = false;
                marimbas.playing = false;
                claps.playing = false;
                bass.playing = false;
                break;
            case 1:
                maracas.playing = true;
                marimbas.playing = true;
                bass.playing = true;
                break;
            case 14:
                maracas.playing = false;
                break;
            case 15:
                marimbas.playing = false;
                bass.playing = false;
                break;
            case 16:
                marimbas.playing = true;
                maracas.playing = true;
                bass.playing = true;
                break;
            case 65:
                claps.playing = true;
                break;
                /*
            case 80:
                claps.playing = false;
                break;
            case 82:
                claps.playing = true;
                break;*/
            case 112:
                maracas.playing = false;
                break;
            case 131:
                marimbas.playing = false;
                bass.playing = false;
                break;
            case 132:
                claps.playing = false;
                break;
            case 133:
                break;
            case 136:
                claps.playing = true;
                marimbas.playing = true;
                break;
            case 137:
                bass.playing = true;
                break;
            case 138:
                claps.playing = false;
                marimbas.playing = false;
                break;
            case 139:
                bass.playing = false;
                break;
            case 145:
                marimbas.playing = true;
                claps.playing = true;
                bass.playing = true;
                break;
            case 147:
                maracas.playing = false;
                marimbas.playing = false;
                claps.playing = false;
                bass.playing = false;
                break;
            case 159:
                marimbas.playing = true;
                bass.playing = true;
                break;
            case 161:
                maracas.playing = true;
                claps.playing = true;
                break;
            case 226:
                maracas.playing = false;
                marimbas.playing = false;
                bass.playing = false;
                break;
        }


        totalBeats++;
    }
}
