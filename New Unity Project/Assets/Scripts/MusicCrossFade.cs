using UnityEngine;
using System.Collections;

public class MusicCrossFade : MonoBehaviour {

    public AudioClip clipA,clipB;
    private AudioSource a,b;
    public float crossFade = 1, crossFadeTarget = 1, crossFadeSpeed = 1;
    public float waveCount = 3;  //need to change waveCount when enemies go down

	// Use this for initialization
	void Start () {
        a = gameObject.AddComponent<AudioSource>();
        a.clip = clipA;
        a.Play();
        b = gameObject.AddComponent<AudioSource>();
        b.clip = clipB;
        b.Play();
	}
	
	// Update is called once per frame
	void Update () 
    {
        //if wavecount <= variable then crossfade
        if (waveCount <= 1)
        {
            crossFade = Mathf.MoveTowards(crossFade, crossFadeTarget, Time.deltaTime * crossFadeSpeed);
            a.volume = crossFade;
            b.volume = 1 - crossFade;
        }
	}
}
