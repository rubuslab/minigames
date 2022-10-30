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
    //private bool m_isOnGround = true;
    private AudioSource m_backgroundMusic;

    private int m_continurousJumpCount = 0;
    private int m_scores = 0;

    public void AddScore()
    {
        ++m_scores;
        Debug.Log("Scores: " + m_scores);
    }

    // Start is called before the first frame update
    void Start()
    {
        // get player rigibody reference
        m_playerRB = this.GetComponent<Rigidbody>();
        m_playerAnimator = this.GetComponent<Animator>();
        Physics.gravity *= gravityModifer;
        
        m_dirtyRunParticle = GameObject.Find("FX_DirtSplatter").GetComponent<ParticleSystem>();
        m_backgroundMusic = GameObject.Find("Main Camera").GetComponent<AudioSource>();

        SetPlayerWalk();
    }

    public void SetPlayerWalk()
    {
        // walk mode
        m_playerAnimator.SetFloat("Speed_f", 0.3f);
    }

    public void SetPlayerRun()
    {
        m_playerAnimator.SetFloat("Speed_f", 0.6f);
    }

    // Update is called once per frame
    void Update()
    {
        bool mobileTouched = Input.touchCount > 0 ? Input.GetTouch(0).phase == TouchPhase.Began : false;

        // if player pressed spacebar, jump up
        if (!isGameOver &&
            (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || mobileTouched) &&
            m_continurousJumpCount < 2)
        {
            // stop run particle when jumping
            m_dirtyRunParticle.Stop();

            Debug.Log("Add jump force: " + jumpForce);
            m_playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //m_isOnGround = false;
            m_continurousJumpCount++;

            m_playerAnimator.SetTrigger("Jump_trig");

            // play jump sound once
            GetComponent<AudioSource>().PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
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
        else if (collision.gameObject.CompareTag("Ground")) {
            //m_isOnGround = true;
            m_continurousJumpCount = 0;

            // start run particle
            m_dirtyRunParticle.Play();
        }
    }
}
