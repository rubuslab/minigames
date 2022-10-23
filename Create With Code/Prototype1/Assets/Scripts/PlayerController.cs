using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public variables
    public float Speed = 20.0f;
    public float TurnSpeed = 60.0f;

    // methods & functions

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float move_forward_translate = Input.GetAxis("Vertical");
        float move_horizontal_translate = Input.GetAxis("Horizontal");
        if (Mathf.Abs(move_forward_translate) > 0.0001f || Mathf.Abs(move_horizontal_translate) > 0.0001f)
        {
            // move on z axis
            this.transform.Translate(Vector3.forward * move_forward_translate * Speed* Time.deltaTime);
            // turn left or right
            this.transform.Rotate(Vector3.up, move_horizontal_translate * TurnSpeed * Time.deltaTime);
        }
    }
}
