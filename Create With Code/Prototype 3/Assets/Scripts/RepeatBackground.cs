using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // private variables
    private Vector3 m_startPos;
    // Start is called before the first frame update
    void Start()
    {
        m_startPos = this.transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x <= -10.0f) {
            this.transform.position = m_startPos;
        }
    }
}
