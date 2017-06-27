using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SynchronizerData;


public class SphereBehavior : MonoBehaviour {


    public Marimbas marimbas;
    public Maracas maracas;
    public Claps claps;
    public Bass bass;

    public Text beat_text;
    public Text lyrics_text;

	public Vector3[] beatPositions;

	private BeatObserver beatObserver;
	private int beatCounter;
    public int totalBeats;
    public ParticleSystem space_particles;
    public Rigidbody pizza1;
    public Rigidbody pizza2;
    public Rigidbody pizza3;
    public Rigidbody pizza4;
    public MeshRenderer bass_ball;
    private Shader shader;
    public Transform prefab;
    public LyricsCanvas lyrics_canvas;
    public ParticleSystem yeahyeah;
    public ParticleSystem meee;
    public Rigidbody pullup;
    public Rigidbody wassup;
    public Rigidbody hurrup;

    void Start ()
	{
		beatObserver = GetComponent<BeatObserver>();
		beatCounter = 0;
        totalBeats = 0;
        shader = Shader.Find("FX/Flare");
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
        beat_text.text = totalBeats+"";

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
                pizza2.AddExplosionForce(-3300, new Vector3(10, -20f, 40f), 100, -100);
                break;
            case 16:
                marimbas.playing = true;
                maracas.playing = true;
                bass.playing = true;
                lyrics_text.text = "I gotta pizza on the way, bae, bae";
                break;
            case 19:
                lyrics_text.text = "I'm tryna lay, lay\nLil' lady, ay";
                break;
            case 22:
                lyrics_text.text = "I brought a bouquet of the treefer";
                break;
            case 24:
                lyrics_text.text = "And I'm feelin' like we should d-d-duck away";
                break;
            case 27:
                lyrics_text.text = "Netflix and Dusse";
                break;
            case 29:
                lyrics_text.text = "If I do say so myself";
                break;
            case 31:
                lyrics_text.text = "That ass a creature";
                break;
            case 32:
                pizza3.AddExplosionForce(-3300, new Vector3(-10, -20f, 40f), 100, -100);
                break;
            case 33:
                lyrics_text.text = "Pizza on the way, bae, bae";
                break;
            case 35:
                lyrics_text.text = "I'm tryna lay, lay\nLil' lady, ay";
                break;
            case 38:
                lyrics_text.text = "I brought a bouquet of the treefer";
                break;
            case 40:
                lyrics_text.text = "And I'm feelin' like we should d-d-duck away";
                break;
            case 43:
                lyrics_text.text = "Netflix and Dusse";
                break;
            case 45:
                lyrics_text.text = "And if I do say so myself";
                break;
            case 47:
                lyrics_text.text = "That ass a creature";
                break;
            case 49:
                lyrics_text.text = "Pink Caddy, Pepto Bismol-bile";
                break;
            case 53:
                lyrics_text.text = "Ting named Kali, that ass on Sunset Hill";
                break;
            case 57:
                lyrics_text.text = "A beatiful view\n Unusual, I'm hooked onna reel";
                break;
            case 61:
                lyrics_text.text = "And you a be too\n I'm pookie 'bout that coochie forreal";
                break;
            case 65:
                lyrics_text.text = "Okay cool\nYes I love the way you";
                claps.playing = true;
                break;
            case 68:
                lyrics_text.text = "Nourish the soul\nYou know that ass look like a fuckin' grapefruit";
                break;
            case 72:
                lyrics_text.text = "Hittin' them push ups\nSo when I'm up in that wassup,";
                break;
            case 75:
                lyrics_text.text = "Wassup\nYou get whooped up, uh";
                break;
            case 77:
                lyrics_text.text = "Arch that thang\nLike where I'm from";
                break;
            case 79:
                lyrics_text.text = "Been on my brain, Miss Serotonin";
                break;
            case 81:
                lyrics_text.text = "Livin' la vida with my lavita, feel like Ceddy";
                break;
            case 85:
                lyrics_text.text = "Liberate your limbs, eliminate your limits\nLet me";
                break;
            case 88:
                lyrics_text.text = "You feel just like lemonade on ice when I'm all sweaty";
                break;
            case 92:
                lyrics_text.text = "She like Smino boy I get it already";
                break;
            case 95:
                pizza1.AddExplosionForce(-3300, new Vector3(15, -20f, 40f), 100, -100);
                break;
            case 96:
                lyrics_text.text = "I gotta pizza on the way, bae, bae";
                break;
            case 99:
                lyrics_text.text = "I'm tryna lay, lay\nLil' lady, ay";
                break;
            case 102:
                lyrics_text.text = "I brought a bouquet of the treefer";
                break;
            case 104:
                lyrics_text.text = "And I'm feelin' like we should d-d-duck away";
                break;
            case 107:
                lyrics_text.text = "Netflix and Dusse";
                break;
            case 109:
                lyrics_text.text = "And if I do say so myself";
                break;
            case 111:
                lyrics_text.text = "That ass a creature";
                break;
            case 112:
                pizza4.AddExplosionForce(-3300, new Vector3(-15, -20f, 40f), 100, -100);
                maracas.playing = false;
                break;
            case 113:
                lyrics_text.text = "Pizza on the way, bae, bae";
                break;
            case 115:
                lyrics_text.text = "I'm tryna lay, lay\nLil' lady, ay";
                break;
            case 118:
                lyrics_text.text = "I brought a bouquet of the treefer";
                break;
            case 120:
                lyrics_text.text = "And I'm feelin' like we should d-d-duck away";
                break;
            case 123:
                lyrics_text.text = "Netflix and Dusse";
                break;
            case 125:
                lyrics_text.text = "And if I do say so myself";
                break;
            case 127:
                lyrics_text.text = "That ass a creature";
                break;
            case 129:
                lyrics_text.text = "";
                break;
            case 131:
                marimbas.playing = false;
                bass.playing = false;
                lyrics_canvas.Disappear();
                yeahyeah.Play();
                break;
            case 132:
                claps.playing = false;
                break;
            case 133:
                break;
            case 136:
                marimbas.playing = true;
                break;
            case 137:
                claps.playing = true;
                bass.playing = true;
                break;
            case 138:
                marimbas.playing = false;
                break;
            case 139:
                claps.playing = false;
                bass.playing = false;
                yeahyeah.Play();
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
                yeahyeah.Play();
                break;
            case 152:
                meee.Play();
                break;
            case 155:
                yeahyeah.Play();
                break;
            case 159:
                marimbas.playing = true;
                bass.playing = true;
                break;
            case 161:
                maracas.playing = true;
                claps.playing = true;
                break;
            case 192:
                //Pull up
                pullup.AddForce(Vector3.forward * 6200);
                break;
            case 196:
                //Whats up                
                wassup.AddForce(Vector3.forward * 6200);
                break;
            case 204:
                //Hurr up
                hurrup.AddForce(Vector3.forward * 6200);
                break;
            case 208:
                Destroy(pullup.gameObject);
                Destroy(wassup.gameObject);
                break;
            case 220:
                Destroy(hurrup.gameObject);
                break;
            case 225:
                space_particles.Play();
                break;
            case 226:
                maracas.playing = false;
                marimbas.playing = false;
                bass.playing = false;
                bass_ball.material.shader = shader;
                break;
            case 257:
                claps.playing = false;
                break;
            case 260:
                lyrics_canvas.Appear();
                break;
            case 265:
                claps.playing = true;
                break;
            case 269:
                Instantiate(prefab);
                lyrics_text.text = "Listen to more Smino on\nblkswn";
                break;
            case 332:
                //Song ends
                bass.End();
                break;
        }


        totalBeats++;
    }
}
