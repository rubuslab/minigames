using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // public variable
    public GameObject[] obstaclePrefabs;
    public GameObject newPawnObstaclePos;

    // private variables
    private PlayerController m_playerController;

    // Start is called before the first frame update
    void Start()
    {
        m_playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        // start game 3 seconds later
        InvokeRepeating("GameStart", 5.0f, .0f);
    }

    private void GameStart()
    {
        m_playerController.SetPlayerRun();
        InvokeRepeating("NewObstacle", 1.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {        
    }

    private void NewObstacle()
    {
        // if isGameOver, do not spawn new objects any more.
        if (m_playerController.isGameOver) return;

        int index = Random.Range(0, obstaclePrefabs.Length);
        GameObject prefab = obstaclePrefabs[index];
        Vector3 pos = newPawnObstaclePos.transform.position;
        pos.y = 0.1f;

        Instantiate(prefab, pos, prefab.transform.rotation);
    }
}
