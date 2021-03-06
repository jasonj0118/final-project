﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioSource sfxSource;
	public AudioSource musicSource;
	public static SoundManager instance = null;

	public float lowPitchRange = 0.95f;
	public float highPitchRange = 1.05f;

	// Initalization
	/* Contributors: Megan Washburn */
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		//DontDestroyOnLoad (gameObject);

        sfxSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();
	}

	// For single sound effect audio clips
    /* Contributors: Scott Kauker, Megan Washburn */
	public void PlaySingle (AudioClip clip, float pitch = 1.0f) {
        sfxSource.pitch = pitch;
		sfxSource.PlayOneShot(clip);
	}

	// Randomization of sounds and relative pitch for repeated sfx
	/* Contributors: Megan Washburn */
	public void RandomSfx (params AudioClip [] clips) {
		int randomIndex = Random.Range (0, clips.Length);
		float randomPitch = Random.Range (lowPitchRange, highPitchRange);

		sfxSource.pitch = randomPitch;
		sfxSource.clip = clips [randomIndex];
		sfxSource.Play ();
	}
}
