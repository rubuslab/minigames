using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
    }
    
    void Update()
    {
        // random rotate
        transform.Rotate(10.0f * Time.deltaTime, Random.Range(.0f, 1.0f), 0.0f);

        // random mesh material color
        MeshRenderer mesh_r = this.GetComponent<MeshRenderer>();
        mesh_r.material.color = new Color(Random.Range(.0f, 1.0f), Random.Range(.0f, 1.0f), Random.Range(.0f, 1.0f), Random.Range(.0f, 1.0f));

        // random position
        transform.position = new Vector3(Random.Range(-10.0f, 10.0f), this.transform.position.y, Random.Range(-5.0f, 7.0f));

        // random local scale
        transform.localScale = Vector3.one * Random.Range(1.2f, 5.0f);
    }
}
