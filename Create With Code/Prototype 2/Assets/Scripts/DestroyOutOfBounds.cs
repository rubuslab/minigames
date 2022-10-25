using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // public variables
    public float lowBounds = -10.0f;

    // private variables
    private int m_showGameOverCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_showGameOverCount == 0 && this.transform.position.z <= lowBounds)
        {
            Debug.LogError("Game Over.");
            ++m_showGameOverCount;
        }
        
    }
}
