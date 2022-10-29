﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    // public variables
    public bool gameOver;
    public float floatForce = 2.0f;
    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    // private variables
    private float gravityModifier = 1.0f;
    private Rigidbody playerRb;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        // get rigibody component
        playerRb = GetComponent<Rigidbody>();
        // Apply a small upward force at the start of the game
        // playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
            Debug.Log("Add player force: " + (Vector3.up * floatForce));
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

}
