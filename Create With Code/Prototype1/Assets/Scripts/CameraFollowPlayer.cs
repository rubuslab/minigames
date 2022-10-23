using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    // public variables
    public GameObject Player;

    // private variables
    private Vector3 m_distanceToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        m_distanceToPlayer = this.transform.position - Player.transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        // move camera to follow the player
        this.transform.position = m_distanceToPlayer + Player.transform.position;
    }
}
