using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float spawnLimitXLeft = -32;
    private float spawnLimitXRight = 22;
    private float spawnPosY = 2;

    private float startDelay = 1.0f;
    private float invokeInterval = .1f;
    private float m_spawnInterval = 1f;
    private float m_lastSpawnTime = 0.0f;
 

    private float topScreenZ = 28.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomBall", startDelay, invokeInterval);

        m_lastSpawnTime = 0.0f;
        m_spawnInterval = Random.Range(2.0f, 5.0f);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        if (Time.time < (m_lastSpawnTime + m_spawnInterval)) return;
        m_lastSpawnTime = Time.time;
        m_spawnInterval = Random.Range(2.0f, 5.0f);

        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, topScreenZ);

        // instantiate ball at random spawn location
        Instantiate(dogPrefab, spawnPos, dogPrefab.transform.rotation);

        Debug.Log("Time is: " + Time.time);
    }

}
