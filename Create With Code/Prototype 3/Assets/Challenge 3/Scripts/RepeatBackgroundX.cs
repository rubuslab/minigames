using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackgroundX : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;

    private void Start()
    {
        startPos = transform.position; // Establish the default starting position 
        float groundWidth = GameObject.Find("Ground").GetComponent<Renderer>().bounds.size.x;
        Debug.Log("groundWidth: " + groundWidth);

        repeatWidth = GetComponent<BoxCollider>().size.x - groundWidth; // Set repeat width to half of the background
    }

    private void Update()
    {
        // If background moves left by its repeat width, move it back to start position
        if (Mathf.Abs(transform.position.x - startPos.x) > repeatWidth)
        {
            transform.position = startPos;
        }
    }
}


