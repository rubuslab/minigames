using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // public variables
    public float speed = 5.0f;

    // private variables
    private Rigidbody m_enemyRB;
    private GameObject m_player;

    // Start is called before the first frame update
    void Start()
    {
        m_enemyRB = GetComponent<Rigidbody>();
        m_player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (m_player.transform.position - transform.position).normalized;
        m_enemyRB.AddForce(lookDirection * speed);
    }
}
