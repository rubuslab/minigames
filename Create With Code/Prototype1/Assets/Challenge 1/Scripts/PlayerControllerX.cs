using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed = 20.0f;
    public float rotationSpeed = 60.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (Mathf.Abs(horizontalInput) > 0.0001f || Mathf.Abs(verticalInput) > 0.0001f)
        { 

            // move the plane forward at a constant rate
            transform.Translate(Vector3.forward * horizontalInput * speed * Time.deltaTime);

            // tilt the plane up/down based on up/down arrow keys
            // transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
            // rotate with x axis
            transform.Rotate(Vector3.left, rotationSpeed * verticalInput * Time.deltaTime);
        }
    }
}
