using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public variables
    public float jumpForce = 10.0f;
    public float gravityModifer = 1.0f;
    public bool isGameOver = false;
    // special audio effect
    public AudioClip jumpSound;
    public AudioClip crashSound;

    // private variables
    private Rigidbody m_playerRB;
    private Animator m_playerAnimator;
    private ParticleSystem m_dirtyRunParticle;
    private bool m_isOnGround = true;
    private AudioSource m_backgroundMusic;
    

    // Start is called before the first frame update
    void Start()
    {
        // get player rigibody reference
        m_playerRB = this.GetComponent<Rigidbody>();
        m_playerAnimator = this.GetComponent<Animator>();
        Physics.gravity *= gravityModifer;
        
        m_dirtyRunParticle = GameObject.Find("FX_DirtSplatter").GetComponent<ParticleSystem>();
        m_backgroundMusic = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // if player pressed spacebar, jump up
        if (m_isOnGround && !isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            // stop run particle when jumping
            m_dirtyRunParticle.Stop();

            Debug.Log("Add jump force: " + jumpForce);
            m_playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            m_isOnGround = false;

            m_playerAnimator.SetTrigger("Jump_trig");

            // play jump sound once
            GetComponent<AudioSource>().PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_isOnGround = true;
        Debug.Log("enter collision tag: " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // stop background music
            m_backgroundMusic.Stop();

            isGameOver = true;
            Debug.Log("isGameOver: " + isGameOver);

            // stop run particle
            m_dirtyRunParticle.Stop();

            // play particle system, dead
            ParticleSystem particle = GameObject.Find("FX_Explosion_Smoke").GetComponent<ParticleSystem>();
            particle.Play();

            // play crash sound once
            GetComponent<AudioSource>().PlayOneShot(crashSound, 1.0f);

            // set animator to death status
            m_playerAnimator.SetBool("Death_b", true);
            m_playerAnimator.SetInteger("DeathType_int", 1);

        }
        else {
            // start run particle
            m_dirtyRunParticle.Play();
        }
    }
}
