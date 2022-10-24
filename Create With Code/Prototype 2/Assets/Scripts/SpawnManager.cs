using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // public variables
    public GameObject[] animalPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewRandomAnimal(Quaternion rotation)
    {
        Debug.Log("received NewRandomAnimal method call.");

        int index = (int)(Random.value * animalPrefabs.Length);
        int random_x = (int)(Random.value * 30) - 15; // [-15, 15]
        int random_z = (int)(Random.value * 20) + 10; // [10, 30]

        Instantiate(animalPrefabs[index],
            new Vector3(random_x, 0, random_z),
            rotation);
    }
}
