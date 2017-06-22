using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BassPulse : MonoBehaviour {

    float maxDist = 30f;
    float speed = 200f;

    Light myLight;

	// Use this for initialization
	void Start () {
        myLight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        myLight.range = Mathf.PingPong(Time.time * speed, maxDist);
	}
}
