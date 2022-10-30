using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public variables
    public float speed = 5.0f;

    // private variables
    private Rigidbody m_playerRB;
    private GameObject m_focalPoint;

    // Start is called before the first frame update
    void Start()
    {
        m_playerRB = GetComponent<Rigidbody>();
        m_focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        if (Mathf.Abs(verticalInput) > 0.0001f)
        {
            m_playerRB.AddForce(m_focalPoint.transform.forward * verticalInput * speed * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
