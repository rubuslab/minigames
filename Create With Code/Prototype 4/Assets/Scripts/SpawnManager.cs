using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // public variables
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefab, SpawnPosition(), enemyPrefab.transform.rotation);
        Instantiate(enemyPrefab, SpawnPosition(), enemyPrefab.transform.rotation);
        Instantiate(enemyPrefab, SpawnPosition(), enemyPrefab.transform.rotation);
        Instantiate(enemyPrefab, SpawnPosition(), enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 SpawnPosition()
    {
        float max = 9.0f;
        float x = Random.Range(-max, max);
        float z = Random.Range(-max, max);
        return new Vector3(x, 0, z);
    }
}
