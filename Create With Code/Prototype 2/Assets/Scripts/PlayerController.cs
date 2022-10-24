using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public variables
    public float speed = 30.0f;
    public float playerHorizontalBoundary = 15.0f;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(horizontalInput) > 0.0001f)
        {
            float x = this.transform.position.x;
            if (x > playerHorizontalBoundary || x < -playerHorizontalBoundary)
            {
                x = playerHorizontalBoundary * x / Mathf.Abs(x);
                Vector3 pos = this.transform.position;
                this.transform.position = new Vector3(x, pos.y, pos.z);
            }
            else
            {
                // move player
                this.transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
            }
        }

        // if spacebar pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }
}
