using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // public variables
    public float speed = 10.0f;

    // private variables
    private PlayerController m_playerController;

    // Start is called before the first frame update
    void Start()
    {
        m_playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_playerController.isGameOver)
        {
            Vector3 direction = new Vector3(-1, 0, 0);
            this.transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }
}
