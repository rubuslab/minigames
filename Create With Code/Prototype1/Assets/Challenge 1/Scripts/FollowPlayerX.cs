﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public GameObject plane;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        // I am(this) the main camera.
        offset = this.transform.position - plane.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offset + plane.transform.position;
    }
}
