using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutBound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CheckOutOfBound", 1.0f, .5f);
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    private void CheckOutOfBound()
    {
        if (this.transform.position.x < -10.0f || this.transform.position.y < -2.0f)
        {
            Object.Destroy(gameObject);
        }
    }
}
