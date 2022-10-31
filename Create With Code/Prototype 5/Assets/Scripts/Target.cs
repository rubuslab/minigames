using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // private variables
    private float m_maxForce = 16.0f;
    private float m_minForce = 12.0f;
    private float m_maxTorque = 10.0f;

    private float m_spawnXRange = 5.0f;
    private float m_spawnYPos = -6.0f;

    private float RandomForce() { return Random.Range(m_minForce, m_maxForce); }
    private float RandomTorque() { return Random.Range(-m_maxTorque, m_maxTorque); }
    private Vector3 RandomSpawnPos() { return new Vector3(Random.Range(-m_spawnXRange, m_spawnXRange), m_spawnYPos); }

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            Object.Destroy(this.gameObject);
        }
        
    }
}
