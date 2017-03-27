using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayHitWoodAudio : MonoBehaviour {
    public AudioSource hitWoodAudio;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Asteroid")
        {
           hitWoodAudio.Play();
        }
            
    }
}
