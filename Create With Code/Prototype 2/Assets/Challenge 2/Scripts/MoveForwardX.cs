using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardX : MonoBehaviour
{
    // public variables
    public float speed = 10.0f;

    // private variables
    private bool m_tryDestroing = false;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.tag == "Ball" && other.tag == "Dog" && !m_tryDestroing)
        {
            m_tryDestroing = true;
            Destroy(this.gameObject);
            Debug.LogWarning("Destroing ball.");
        }
    }
}
