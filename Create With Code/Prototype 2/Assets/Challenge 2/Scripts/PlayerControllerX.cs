using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    // public variables
    public GameObject[] ballPrefabs;
    public float speed = 20.0f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spawn ball from player.");
            Vector3 pos = this.transform.position;
            int index = Random.Range(0, ballPrefabs.Length);
            pos.y = ballPrefabs[index].transform.position.y;
            Instantiate(ballPrefabs[index], pos, ballPrefabs[index].transform.rotation);
            // Debug.Log("new ball pos: " + pos);
        }

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(verticalInput) > 0.001f || Mathf.Abs(horizontalInput) > 0.001f)
        {
            transform.Translate(horizontalInput * speed * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime);
        }
    }
}
