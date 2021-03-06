﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	private int missileCount = 0;

    //How much relative 'power' is behind this projectile.
    //Affects how far the player is pushed back
    public float hitScale = 1.0f;

    //How fast this projectile travels
    public float speed = 1.0f;

    //How long the bullet persists until it is automatically destroyed
    public float lifeTime = 1.0f;

	private Rigidbody2D body;
	public GameObject ShieldParticles;
	public GameObject explosion;
	private GameObject ghost;

    /* Contributors: Scott Kauker */
    void Start() {
		body = GetComponent<Rigidbody2D> ();
	}

    // Update is called once per frame
    /* Contributors: Scott Kauker */
    void Update () {
		this.transform.position += this.transform.up * Time.deltaTime * speed;

		lifeTime -= Time.deltaTime;
		if (lifeTime <= 0) {
			Destroy (gameObject);
		}
    }

    /* Contributors: Scott Kauker, Megan Washburn , Alexander Bohlen, Jin Young Jeong*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPlatformerController pc = collision.gameObject.GetComponent<PlayerPlatformerController>();
		if (collision.CompareTag("bullet")) {
			//Explode ();
			Debug.Log("shield collision");
			ShieldParticles.gameObject.SetActive(true);
			Destroy (gameObject);
		}else{
			if (pc == null) return;
			pc.ThrowBack (hitScale);
			// Explosion Animation. Instance of Explosion destroyed with Inspector setting - AB
			Instantiate (explosion, transform.position, Quaternion.Euler (0, 0, 0));
			Destroy (gameObject);
		} 
    }
}
