using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // private variables
    private PlayerController m_playerController;
    private float m_defaultSpeed;
    
    // public variables
    public float speed = 10.0f;

    public bool IsSuperSpeed()
    {
        return speed - m_defaultSpeed > 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        m_defaultSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        // if press key E, speed up
        if (Input.GetKeyDown(KeyCode.E))
        {
            speed = m_defaultSpeed * 2.0f;
            Debug.Log("Speed up to: " + speed);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            speed = m_defaultSpeed;
            Debug.Log("Back to normal speed: " + speed);
        }

        if (!m_playerController.isGameOver)
        {
            Vector3 direction = new Vector3(-1, 0, 0);
            this.transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }
}
